using Aplicacion.Datos;
using System;
using System.Threading.Tasks;
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
                if(_datos.DatosBiometricos != null)
                {                       
                    _datos.DatosBiometricos.ForEach(x => 
                    _cblRegistrados.Items.Add(x.Dedo + ((x.ManoDerecha)? " Derecho" : " Izquierdo")));
                }
            }
        }   
        private bool _isCapture = false;
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

            _scaner = new Fingerprint.FingerWriter();

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
                    if (_datos.DatosBiometricos == null)
                        _datos.DatosBiometricos = new System.Collections.Generic.List<DatosBiometrico>();

                    Enums.EDedo dedo = (Enums.EDedo)_cbxDedo.SelectedIndex;
                    _datos.DatosBiometricos.RemoveAll(x => x.Dedo == dedo && x.ManoDerecha == _chbManoDerecha.Checked);

                    _datos.DatosBiometricos.Add(new DatosBiometrico()
                    {
                        Data = data,
                        Dedo = dedo,
                        ManoDerecha = _chbManoDerecha.Checked
                    });

                    _isCapture = false;
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

            _btnCapturar.Click += (o, e) =>
            {
                if (!_isCapture)
                {
                    _isCapture = true;
                    _cbxDedo.Enabled = false;
                    _chbManoDerecha.Enabled = false;
                    _btnCancelar.Enabled = false;
                    _btnCapturar.Text = "Detener";
                    _scaner.StartCapture();
                    _scaner.ReseteCapture();
                }
                else
                {
                    _isCapture = false;
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
