using AppData;
using System.Linq;
using System.Windows.Forms;

namespace Aplicacion.Vistas.Usuarios
{
    public partial class FormularioAcceso : Form
    {
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

        public FormularioAcceso()
        {
            InitializeComponent();
            _btnEntrar.Click += (o, e) => OnEntrar();
            _btnCancelar.Click += (o, e) => OnCancelar();
        }

        private void OnCancelar()
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OnEntrar()
        {
            bool exist = DataContext.Current.Usuarios.Find(x => x.Nombre == _txtUser.Text && x.Clave == _txtClave.Text).Count() > 0;
            if (!exist)
            {
                MessageBox.Show("Usuario invalido");
                return;
            }
            DialogResult = DialogResult.Yes;
        }
    }
}
