using Aplicacion.UI;
using System.Windows.Forms;

namespace Aplicacion.Vistas
{
    public partial class InicioForm : Form
    {
        public Efectos FX { get; private set; }
        public MenuControl MainMenu { get; private set; }

        public Usuarios.Control UsuarioControl { get; private set; }
        public Empleado.Control EmpleadoControl { get; private set; }
        public RegistroHorario.Control RegistroHorarioControl { get; private set; }
        public Reportes.Control ReporteControl { get; private set; }
        public Jornada.Control JornadaControl { get; private set; }
        public Configuracion.Control ConfiguracionControl { get; private set; }

        public InicioForm()
        {
            InitializeComponent();

            FX = new Efectos();
            MainMenu = new MenuControl(_panelControls);
            UsuarioControl = new Usuarios.Control();
            EmpleadoControl = new Empleado.Control();
            RegistroHorarioControl = new RegistroHorario.Control();
            ReporteControl = new Reportes.Control();
            JornadaControl = new Jornada.Control();
            ConfiguracionControl = new Configuracion.Control();

            Efectos.ConfigurationFX conf = new Efectos.ConfigurationFX { Transicion = 5 };
            FX.Add(_btnUsers, conf);
            FX.Add(_btnEmpleado, conf);
            FX.Add(_btnReportes, conf);
            FX.Add(_btnJornada, conf);
            FX.Add(_btnConsola, conf);
            FX.Add(_btnConfiguracion, conf);
            FX.Add(_btnSalir, conf);

            MainMenu.SetTitleLabel(_lblTitle);
            MainMenu.Link("RegistroHorario", RegistroHorarioControl);
            MainMenu.Link("Usuarios", _btnUsers, UsuarioControl);
            MainMenu.Link("Empleado", _btnEmpleado, EmpleadoControl);
            MainMenu.Link("Reporte", _btnReportes, ReporteControl);
            MainMenu.Link("Jornada", _btnJornada, JornadaControl);
            MainMenu.Link("Configuración", _btnConfiguracion, ConfiguracionControl);

            MainMenu.HideAll();
            _btnConsola.Click += (o, e) => { new Consola().Show(); };
            _btnSalir.Click += (o, e) => Close();
            Program.UpdateEvent += FX.Update;
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
