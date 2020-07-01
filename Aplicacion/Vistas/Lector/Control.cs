using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DPFP;
using Aplicacion.Datos;

namespace Aplicacion.Vistas.Lector
{
    public partial class Control : Form
    {
        private Fingerprint.FingerReader reader { get; set; }
        public bool IsRuning { get; private set; }

        public Control()
        {
            InitializeComponent();
            reader = new Fingerprint.FingerReader();
            _btnConsole.Click += (o, e) => OnConsole();
            _btnStart.Click += (o, e) => OnStart();
            _btnStop.Click += (o, e) => OnStop();
            reader.OnCapture += OnCapture;

            _lblState.Text = "Detenido";
            _btnStop.Enabled = false;
            _btnStart.Enabled = true;

            Text += "V." + GetType().Assembly.GetName().Version.ToString();

            OnStart();
        }

        private void OnCapture(Sample sample)
        {
            try
            {
                Program.Debug.Log(ELogType.Info, "Se capturo un dato biometrico");

                List<Datos.Empleado> empleados = Program.DbContext.Empleado
                       .Include(x => x.DatosBiometricos)
                       .Include(x => x.RegistrosHorario)
                       .ToList();

                bool fingerFind = false;

                foreach (Datos.Empleado empleado in empleados)
                {
                    if (empleado.DatosBiometricos == null || empleado.DatosBiometricos.Count == 0)
                        continue;

                    List<byte[]> datos = new List<byte[]>();
                    empleado.DatosBiometricos.ForEach(x => datos.Add(x.Data));

                    if (reader.Verify(sample, datos.ToList()))
                    {
                        Program.Debug.Log(ELogType.Info, "Macheo de datos con empleado {0} {1}",
                            empleado.Nombre, empleado.Apellido);

                        if (empleado.RegistrosHorario.Where(x => x.Estado == Enums.ERegistroEstado.Abierto).Count() == 1)
                        {
                            Datos.RegistroHorario reg = empleado.RegistrosHorario.Where(x => x.Estado == Enums.ERegistroEstado.Abierto).Single();
                            reg.Salida = DateTime.Now;
                            reg.Estado = Enums.ERegistroEstado.Cerrado;

                            Program.Debug.Log(ELogType.Info, "Se cerro el turno {0}", reg.Id);
                            Tools.Audio.PlayAudio(Program.Conf.AudioFingerprintFin);
                        }
                        else
                        {
                            Datos.RegistroHorario reg = new Datos.RegistroHorario
                            {
                                Entrada = DateTime.Now,
                                Estado = Enums.ERegistroEstado.Abierto
                            };

                            empleado.RegistrosHorario.Add(reg);

                            Program.Debug.Log(ELogType.Info, "Se abrio un nuevo turno");
                            Tools.Audio.PlayAudio(Program.Conf.AudioFingerprintInicio);
                        }
                        fingerFind = true;
                        break;
                    }
                }

                if (!fingerFind)
                    Tools.Audio.PlayAudio(Program.Conf.AudioFingerprintIncorrecto);

                Program.DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Program.Debug.Log(ELogType.Error, "Error verificando datos biometrico " + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void OnStop()
        {
            IsRuning = false;
            _lblState.Text = "Detenido";
            _btnStop.Enabled = false;
            _btnStart.Enabled = true;
            reader.StopCapture();

            Program.Debug.Log(ELogType.Info, "Se detuvo el lector");
        }

        private void OnStart()
        {
            IsRuning = true;
            _lblState.Text = "Iniciado";
            _btnStop.Enabled = true;
            _btnStart.Enabled = false;
            reader.StartCapture();

            Program.Debug.Log(ELogType.Info, "Se inicio el lector");
        }

        private void OnConsole()
        {
            Consola form = new Consola();
            form.Show();
        }
    }
}
