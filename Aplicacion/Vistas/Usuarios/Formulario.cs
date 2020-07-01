using Aplicacion.UI;
using System.Windows.Forms;

namespace Aplicacion.Vistas.Usuarios
{
    public partial class Formulario : Form
    {
        private Datos.Usuario _datos { get; set; }
        public Datos.Usuario Datos
        {
            get
            {
                return _datos;
            }
            set
            {
                _datos = value;
                _txtNombre.Text = _datos.Nombre;
                _txtEmail.Text = _datos.Email;
                _txtClave.Text = _datos.Clave;
            }
        }

        public Efectos FX { get; set; }
        public Efectos.ConfigurationFX ConfFX = new Efectos.ConfigurationFX();

        public Formulario()
        {
            InitializeComponent();
            FX = new Efectos();
            ConfFX.Transicion = 3;

            FX.Add(_btnCancel, ConfFX);
            FX.Add(_btnSave, ConfFX);

            _btnCancel.Click += (o, e) => Cancel();
            _btnSave.Click += (o, e) => Save();
        }

        private void Save()
        {
            if (!_txtEmail.IsEmail())
            {
                MessageBox.Show("Email invalido");
                return;
            }

            _datos.Nombre = _txtNombre.Text;
            _datos.Email = _txtEmail.Text;
            _datos.Clave = _txtClave.Text;
            DialogResult = DialogResult.Yes;
        }

        private void Cancel()
        {
            DialogResult = DialogResult.Cancel;
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
    }
}
