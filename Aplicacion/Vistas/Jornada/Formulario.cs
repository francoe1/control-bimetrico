using System.Windows.Forms;

namespace Aplicacion.Vistas.Jornada
{
    public partial class Formulario : Form
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

        public Datos.Jornada _datos { get; set; }

        public Datos.Jornada Datos
        {
            get
            {
                return _datos;
            }
            set
            {
                _datos = value;
                _txtNombre.Text = _datos.Nombre;
                _numLunes.Value = _datos.Lunes;
                _numMartes.Value = _datos.Martes;
                _numMiercoles.Value = _datos.Miercoles;
                _numJueves.Value = _datos.Jueves;
                _numViernes.Value = _datos.Viernes;
                _numSabado.Value = _datos.Sabado;
                _numDomingo.Value = _datos.Domingo;
                _numPrecioNormal.Value = _datos.PrecioNormal;
                _numPrecioExtra.Value = _datos.PrecioExtra;
            }
        }

        public Formulario()
        {
            InitializeComponent();
            _btnGuardar.Click += (o, e) => OnGuardar();
            _btnCancelar.Click += (o, e) => OnCancelar();
        }

        private void OnCancelar()
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OnGuardar()
        {
            _datos.Nombre = _txtNombre.Text;
            _datos.Lunes = _numLunes.Value;
            _datos.Martes = _numMartes.Value;
            _datos.Miercoles = _numMiercoles.Value;
            _datos.Jueves = _numJueves.Value;
            _datos.Viernes = _numViernes.Value;
            _datos.Sabado = _numSabado.Value;
            _datos.Domingo = _numDomingo.Value;
            _datos.PrecioNormal = _numPrecioNormal.Value;
            _datos.PrecioExtra = _numPrecioExtra.Value;
            DialogResult = DialogResult.Yes;
        }
    }
}
