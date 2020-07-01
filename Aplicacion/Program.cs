using Aplicacion.Datos;
using Aplicacion.Tools;
using Aplicacion.Vistas;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion
{
    public class Program
    {
        public static event Action UpdateEvent;
        public static Debug Debug { get; private set; }
        public static DataContext DbContext { get; private set; }
        public static InicioForm InicioForm { get; private set; }
        public static Vistas.Usuarios.FormularioAcceso FormularioAcceso { get; private set; }
        public static Configuracion Conf { get; private set; }


        [STAThread]
        private static void Main(string[] args)
        {
            Debug = new Tools.Debug();
            DbContext = new DataContext();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Program();

            if (args == null || args.Length == 0)
                args = new string[] { "" };

            if (!StartProgram())
            {
                MessageBox.Show("Error al iniciar", "¡Error FATAL!");
                Close();
            }
            else
            {
                if (args.Length > 0 && args[0].ToLower().Equals("onlector"))
                {
                    SetupLector();
                    Application.Run(new Vistas.Lector.Control());
                }
                else if (args.Length > 0 && args[0].ToLower().Equals("updateddbb"))
                {
                    UpdateDDBB();
                }
                else
                {

                    FormularioAcceso = new Vistas.Usuarios.FormularioAcceso();
                    if (FormularioAcceso.ShowDialog() == DialogResult.Yes)
                    {
                        InicioForm = new InicioForm();
                        Application.Run(InicioForm);
                    }
                }
            }
        }

        private static bool StartProgram()
        {
            Splash splash = new Splash
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            splash.Show();

            splash.SetVersion(splash.GetType().Assembly.GetName().Version.ToString());
            splash.SetInfo("Conectando con la base de datos");
            splash.SetProgress(10);
            splash.Update();

            if (!ExistDDBB())
            {
                MessageBox.Show("No se pude establacer la conexión o la base de datos no existe");
                Close();
                return false;
            }

            splash.SetInfo("Cargando Configuración");
            splash.SetProgress(20);
            splash.Update();

            Conf = new Configuracion();
            Conf.Load();

            splash.SetProgress(30);
            splash.SetInfo("Cargando Usuarios");
            splash.Update();
            Task.Delay(100);

            if (DbContext.Usuarios.Count() == 0)
            {
                MessageBox.Show("El sistema no encontro ningun usuario para ser utilizado. cree uno a continuación");
                Vistas.Usuarios.Formulario form = new Vistas.Usuarios.Formulario
                {
                    Datos = new Usuario()
                };
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    DbContext.Usuarios.Insert(form.Datos);
                }
            }

            splash.SetProgress(100);
            splash.SetInfo("Inicilizando");
            Task.Delay(100);
            splash.Update();
            splash.Close();

            return true;
        }

        private static void SetupLector()
        {
            if (!new Fingerprint.FingerReader().AvailableDevice(out string lectorUid))
            {
                Debug.Log("No se encontro el lector biometrico U.A.R.E Fingerprint 4500");
            }
            else
            {
                Debug.Log($"Se detecto un lector UID:{lectorUid}");
            }
        }

        private Program()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer
            {
                Interval = 10
            };
            timer.Tick += (o, e) => UpdateEvent?.Invoke();
            timer.Start();
        }

        internal static void UpdateDDBB()
        {
            /*
            Form form = new Form();
            form.TopMost = true;
            form.Text = "Actualizando Control Biometrico";
            ProgressBar prg = new ProgressBar();
            form.Controls.Add(prg);
            prg.Dock = DockStyle.Fill;
            prg.Value = 0;
            form.Show();

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Migrations.Configuration>());
            prg.Value = 10;
            try
            {
                prg.Value = 20;     
                DbContext.Database.Initialize(true);
                prg.Value = 100;
                MessageBox.Show("La base de datos ha sido actualizada", "¡Actualización!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Close();
            }*/
        }

        internal static bool ExistDDBB()
        {
            return true;
        }

        internal static void Close()
        {
            Application.ExitThread();
            Application.Exit();
        }
    }
}
