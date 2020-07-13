using Aplicacion.UI;
using System.Windows.Forms;

namespace Aplicacion.Vistas
{
    public partial class InicioForm : Form
    {
        public Efectos FX { get; private set; }
        public MenuControl MainMenu { get; private set; }

        public Usuarios.MainFormControl UsuarioControl { get; private set; }
        public Empleado.MainFormControl EmpleadoControl { get; private set; }
        public RegistroHorario.MainFormControl RegistroHorarioControl { get; private set; }
        public Reportes.MainFormControl ReporteControl { get; private set; }
        public Jornada.MainFormControl JornadaControl { get; private set; }
        public Configuracion.MainFormControl ConfiguracionControl { get; private set; }

        public InicioForm()
        {
            InitializeComponent();

            FX = new Efectos();
            MainMenu = new MenuControl(_panelControls);
            UsuarioControl = new Usuarios.MainFormControl();
            EmpleadoControl = new Empleado.MainFormControl();
            RegistroHorarioControl = new RegistroHorario.MainFormControl();
            ReporteControl = new Reportes.MainFormControl();
            JornadaControl = new Jornada.MainFormControl();
            ConfiguracionControl = new Configuracion.MainFormControl();

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
            MainMenu.SwithTo("Empleado");
            _btnConsola.Click += (o, e) => { new ConsolaForm().Show(); };
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
