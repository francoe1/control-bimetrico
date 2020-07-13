using AppData;
using System;
using System.Windows.Forms;

namespace Aplicacion.Vistas.Empleado
{
    public partial class BiometricoForm : Form
    {
        private AppData.Empleado _datos { get; set; }
        public AppData.Empleado Datos
        {
            get
            {
                return _datos;
            }
            set
            {
                _datos = value;
                UpdateRegisters();
            }
        }

        private void UpdateRegisters()
        {
            if (Datos is null) return;
            _cblRegistrados.Items.Clear();
            foreach (DatosBiometrico x in DataContext.Current.DatosBiometricos.Find(x => x.EmpladoId == _datos.Id))
                _cblRegistrados.Items.Add(new CbxItem { Id = x.Id, Dedo = x.Dedo, Derecha = x.ManoDerecha });
        }

        private bool m_isCapture = false;
        private Fingerprint.FingerWriter _scaner { get; set; }

        public class CbxItem
        {
            public int Id { get; set; }
            public Enums.EDedo Dedo { get; set; }
            public bool Derecha { get; set; }

            public override string ToString()
            {
                return $"{Dedo} | {(Derecha ? " Derecho" : " Izquierdo")}";
            }
        }


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

        public BiometricoForm()
        {
            InitializeComponent();

            _btnCapturar.Click += (o, e) =>
            {
                if (!OnStartCapture()) return;

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
            m_btn_delete.Click += (o, e) => OnDeleteSelection();
        }

        private void OnDeleteSelection()
        {
            foreach (CbxItem item in _cblRegistrados.CheckedItems)
                DataContext.Current.DatosBiometricos.Delete(item.Id);
            UpdateRegisters();
        }

        private bool OnStartCapture()
        {
            if (_scaner is object) return true;

            try
            {
                _scaner = new Fingerprint.FingerWriter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pueden capturar los datos biometricos en este momento \n" + ex.Message, "¡Atención!");
                return false;
            }

            _scaner.OnStepEvent += (step) =>
            {
                InvokeSafe(() =>
                {
                    _picHuella.Image = _scaner.CaptureImage;
                    _progress.Value += 25;
                });
            };

            _scaner.OnSuccessEvent += (data) =>
            {
                InvokeSafe(() =>
                {
                    Enums.EDedo dedo = (Enums.EDedo)_cbxDedo.SelectedIndex;
                    DataContext.Current.DatosBiometricos.DeleteMany(x => x.EmpladoId == _datos.Id && (x.Dedo == dedo && x.ManoDerecha == _chbManoDerecha.Checked));

                    DataContext.Current.DatosBiometricos.Insert(new DatosBiometrico()
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
                    UpdateRegisters();
                    MessageBox.Show("Registro biometrico completo exitosamente");
                });
            };

            return true;

        }

        private void OnCancelar()
        {
            DialogResult = DialogResult.Cancel;
            if (_scaner is object)
            {
                _scaner.StopCapture();
                _scaner.ReseteCapture();
            }
            Close();
        }

        private void InvokeSafe(Action action)
        {
            Invoke(action);
        }

        private void m_btnManual_Click(object sender, EventArgs e)
        {
            BiometricoManualForm form = new BiometricoManualForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Enums.EDedo dedo = (Enums.EDedo)_cbxDedo.SelectedIndex;
                DataContext.Current.DatosBiometricos.DeleteMany(x => x.EmpladoId == _datos.Id && (x.Dedo == dedo && x.ManoDerecha == _chbManoDerecha.Checked));

                DataContext.Current.DatosBiometricos.Insert(new DatosBiometrico()
                {
                    EmpladoId = _datos.Id,
                    Data = form.Bytes,
                    Dedo = dedo,
                    ManoDerecha = _chbManoDerecha.Checked
                });

                _picHuella.Image = form.Image;
                MessageBox.Show("Registro biometrico completo exitosamente");
                UpdateRegisters();
            }
        }
    }
}
