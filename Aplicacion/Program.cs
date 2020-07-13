using Aplicacion.Tools;
using Aplicacion.Vistas;
using Aplicacion.Vistas.Usuarios;
using AppData;
using Fingerprint;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion
{
    public static class Program
    {
        public static event Action UpdateEvent;
        public static Debug Debug { get; private set; }
        public static InicioForm InicioForm { get; private set; }
        public static FormularioAccesoForm FormularioAcceso { get; private set; }
        public static Configuracion Conf { get; private set; }

        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Debug = new Debug();

            StartUpdateTick();

            if (!StartProgram())
            {
                MessageBox.Show("Error al iniciar", "¡Error FATAL!");
                Close();
                return;
            }

            if (IsLector(args))
            {
                SetupLector();
                Application.Run(new Vistas.Lector.MainForm());
                return;
            }

            FingerReader.ReaderStatusCaptureEvent += (e) => Debug.Log("Reader " + e.ToString());
            FingerWriter.ReaderStatusCaptureEvent += (e) => Debug.Log("Writer " + e.ToString());

            FormularioAcceso = new FormularioAccesoForm();
            if (FormularioAcceso.ShowDialog() == DialogResult.Yes)
            {
                InicioForm = new InicioForm();
                Application.Run(InicioForm);
            }

        }

        private static bool IsLector(string[] args)
        {
            if (args is null || args.Length != 1 || args[0] != "onlector") return false;
            return true;            
        }

        private static bool StartProgram()
        {
            SplashForm splash = new SplashForm
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            splash.Show();

            splash.SetVersion(splash.GetType().Assembly.GetName().Version.ToString());
            splash.SetInfo("Conectando con la base de datos");
            splash.SetProgress(10);
            splash.Update();

            splash.SetInfo("Cargando Configuración");
            splash.SetProgress(20);
            splash.Update();

            Conf = new Configuracion();
            Conf.Load();

            splash.SetProgress(30);
            splash.SetInfo("Cargando Usuarios");
            splash.Update();

            if (DataContext.Current.Usuarios.Count() == 0)
            {
                MessageBox.Show("El sistema no encontro ningun usuario para ser utilizado. cree uno a continuación");
                FormularioForm form = new FormularioForm { Datos = new Usuario() };
                if (form.ShowDialog() == DialogResult.Yes)
                    DataContext.Current.Usuarios.Insert(form.Datos);
                else
                    return false;
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
            Fingerprint.Readers.Search();

            Debug.Log($"Se encontraron {Fingerprint.Readers.Collection.Length} lectores");

            if (Fingerprint.Readers.Collection.Length > 0)
            {
                string serial = Fingerprint.Readers.Collection[0].SerialNumber;
                Debug.Log($"Se utilizara el lector {serial} para trabajar");
            }
        }

        private static void StartUpdateTick()
        {
            Timer timer = new Timer { Interval = 10 };
            timer.Tick += (o, e) => UpdateEvent?.Invoke();
            timer.Start();
        }

        internal static void Close()
        {
            Application.ExitThread();
            Application.Exit();
        }
    }
}
