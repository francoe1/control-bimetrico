using AppData;
using System.Linq;
using System.Windows.Forms;

namespace Aplicacion.Vistas.Empleado
{
    public partial class FormularioForm : Form
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
                _txtNombre.Text = _datos.Nombre;
                _txtApellido.Text = _datos.Apellido;
                _txtDNI.Text = _datos.Documento;
                _txtDireccion.Text = _datos.Direccion;
                _txtTelefono.Text = _datos.Telefono;
                _txtEmail.Text = _datos.Email;

                if (_datos.Jornada != null)
                    _cbxJornada.SelectedValue = _datos.Jornada.Id;
            }
        }

        public FormularioForm()
        {
            InitializeComponent();
            _btnCancelar.Click += (o, e) => OnCancel();
            _btnGuardar.Click += (o, e) => OnGuardar();
            _btnBiometrico.Click += (o, e) => OnBiometrico();
            _cbxJornada.DataSource = DataContext.Current.Jornadas.FindAll().ToList();
            _cbxJornada.DisplayMember = "Nombre";
            _cbxJornada.ValueMember = "Id";
        }

        private void OnBiometrico()
        {
            BiometricoForm form = new BiometricoForm
            {
                Datos = _datos
            };
            if (form.ShowDialog() != DialogResult.Cancel)
            {

            }
        }

        private void OnGuardar()
        {
            _datos.Nombre = _txtNombre.Text;
            _datos.Apellido = _txtApellido.Text;
            _datos.Documento = _txtDNI.Text;
            _datos.Direccion = _txtDireccion.Text;
            _datos.Telefono = _txtTelefono.Text;
            _datos.Email = _txtEmail.Text;
            if (_cbxJornada.SelectedValue is object)
            {
                int id = (int)_cbxJornada.SelectedValue;
                _datos.Jornada = DataContext.Current.Jornadas.FindById(id);
            }
            DialogResult = DialogResult.Yes;
        }

        private void OnCancel()
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
