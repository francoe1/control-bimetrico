using Aplicacion.Datos;
using System;
using System.Windows.Forms;

namespace Aplicacion.Vistas.Empleado
{
    public partial class Biometrico : Form
    {
        private Datos.Empleado _datos { get; set; }
        public Datos.Empleado Datos
        {
            get
            {
                return _datos;
            }
            set
            {
                _datos = value;

                foreach (DatosBiometrico x in Program.DbContext.DatosBiometricos.Find(x => x.EmpladoId == _datos.Id))
                    _cblRegistrados.Items.Add(x.Dedo + ((x.ManoDerecha) ? " Derecho" : " Izquierdo"));
            }
        }
        private bool m_isCapture = false;
        private Fingerprint.FingerWriter _scaner { get; set; }


        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        public Biometrico()
        {
            InitializeComponent();


            _btnCapturar.Click += (o, e) =>
            {
                OnStartCapture();

                if (!m_isCapture)
                {
                    m_isCapture = true;
                    _cbxDedo.Enabled = false;
                    _chbManoDerecha.Enabled = false;
                    _btnCancelar.Enabled = false;
                    _btnCapturar.Text = "Detener";
                    _scaner.StartCapture();
                    _scaner.ReseteCapture();
                }
                else
                {
                    m_isCapture = false;
                    _btnCancelar.Enabled = true;
                    _cbxDedo.Enabled = true;
                    _chbManoDerecha.Enabled = true;
                    _btnCapturar.Text = "Capturar";
                    _picHuella.Image = null;
                    _progress.Value = 0;
                    _scaner.StopCapture();
                }
            };

            _cbxDedo.DataSource = Enum.GetNames(typeof(Enums.EDedo));
            _btnCancelar.Click += (o, e) => OnCancelar();
        }

        private void OnStartCapture()
        {
            if (_scaner is object) return;

            try
            {
                _scaner = new Fingerprint.FingerWriter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pueden capturar los datos biometricos en este momento \n" + ex.Message, "¡Atención!");
                return;
            }

            _scaner.OnStep += (step) =>
            {
                InvokeSafe(() =>
                {
                    _picHuella.Image = _scaner.CaptureImage;
                    _progress.Value += 25;
                });
            };

            _scaner.OnSuccess += (data) =>
            {
                InvokeSafe(() =>
                {
                    Enums.EDedo dedo = (Enums.EDedo)_cbxDedo.SelectedIndex;
                    Program.DbContext.DatosBiometricos.DeleteMany(x => x.EmpladoId == _datos.Id && (x.Dedo == dedo && x.ManoDerecha == _chbManoDerecha.Checked));

                    Program.DbContext.DatosBiometricos.Insert(new DatosBiometrico()
                    {
                        EmpladoId = _datos.Id,
                        Data = data,
                        Dedo = dedo,
                        ManoDerecha = _chbManoDerecha.Checked
                    });

                    m_isCapture = false;
                    _btnCancelar.Enabled = true;
                    _cbxDedo.Enabled = true;
                    _chbManoDerecha.Enabled = true;
                    _btnCapturar.Text = "Capturar";
                    _picHuella.Image = null;
                    _progress.Value = 0;
                    _scaner.StopCapture();
                    _scaner.ReseteCapture();
                    MessageBox.Show("Registro biometrico completo exitosamente");
                });
            };

        }

        private void OnCancelar()
        {
            DialogResult = DialogResult.Cancel;
            _scaner.StopCapture();
            _scaner.ReseteCapture();
            Close();
        }

        private void InvokeSafe(Action action)
        {
            Invoke(action);
        }
    }
}
