using Aplicacion.Tools;
using Aplicacion.Vistas;
using AppData;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion
{
    public class Program
    {
        public static event Action UpdateEvent;
        public static Debug Debug { get; private set; }
        public static InicioForm InicioForm { get; private set; }
        public static Vistas.Usuarios.FormularioAcceso FormularioAcceso { get; private set; }
        public static Configuracion Conf { get; private set; }

        [STAThread]
        private static void Main(string[] args)
        {            
            Debug = new Debug();
            {
                IEnumerable<DatosBiometrico> data = DataContext.Current.DatosBiometricos.FindAll();

                foreach(DatosBiometrico bioA in data)
                {
                   foreach(DatosBiometrico bioB in data)
                    {
                        if (bioA.Id == bioB.Id) continue;

                        if (bioA.Data == bioB.Data)
                        {
                            MessageBox.Show($"Existen {bioA.EmpladoId} datos biometrico repetidos");
                            break;
                        }
                    }
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Program();

            if (args == null || args.Length == 0)
                args = new string[] { "" };


            args = new string[] { "onlector" };

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
                Vistas.Usuarios.Formulario form = new Vistas.Usuarios.Formulario
                {
                    Datos = new Usuario()
                };
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    DataContext.Current.Usuarios.Insert(form.Datos);
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
            Fingerprint.Readers.Search();

            Debug.Log($"Se encontraron {Fingerprint.Readers.Collection.Length} lectores");

            if (Fingerprint.Readers.Collection.Length > 0)
            {
                string serial = Fingerprint.Readers.Collection[0].SerialNumber;
                Debug.Log($"Se utilizara el lector {serial} para trabajar");
            }
        }

        private Program()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer
            {
                Interval = 1000
            };
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
