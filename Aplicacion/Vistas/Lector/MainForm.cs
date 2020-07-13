using Aplicacion.Tools;
using AppData;
using DPFP;
using Fingerprint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Aplicacion.Vistas.Lector
{
    public partial class MainForm : Form
    {
        private FingerReader reader { get; set; }
        public bool IsRuning { get; private set; }

        private ConsolaForm m_consola { get; set; }

        public MainForm()
        {
            if (Readers.Collection.Length == 0)
            {
                MessageBox.Show("El lector no esta disponible");
                return;
            }

            InitializeComponent();

            m_consola = new ConsolaForm();
            m_consola.FormClosing += (o, e) => { e.Cancel = true; ((ConsolaForm)o).Hide(); };

            reader = new FingerReader();
            _btnConsole.Click += (o, e) => OnConsole();
            _btnStart.Click += (o, e) => OnStart();
            _btnStop.Click += (o, e) => OnStop();

            reader.OnCaptureEvent += OnCapture;

            _lblState.Text = "Detenido";
            _btnStop.Visible = false;
            _btnStart.Visible = true;

            Text += " " + GetType().Assembly.GetName().Version.ToString();

            m_lblUid.Text = Readers.Collection[0].SerialNumber;
            m_lblFirmeware.Text = Readers.Collection[0].FirmwareVersion.ToString();
            m_lblName.Text = Readers.Collection[0].ProductName;

            OnStart();
        }

        private void OnCapture(Sample sample)
        {
            Beep(1000, 200);
            try
            {
                Program.Debug.Log("Se capturo un dato biometrico");

                bool fingerFind = false;

                foreach (AppData.Empleado empleado in DataContext.Current.Empleado.FindAll())
                {
                    IEnumerable<DatosBiometrico> datosBiometricos = DataContext.Current.DatosBiometricos.Find(x => x.EmpladoId == empleado.Id);
                    IEnumerable<AppData.RegistroHorario> registros = DataContext.Current.RegistroHorarios.Find(x => x.EmpladoId == empleado.Id);
                    List<byte[]> datos = new List<byte[]>();

                    foreach (DatosBiometrico biometrico in datosBiometricos)
                        datos.Add(biometrico.Data);

                    if (reader.Verify(sample, datos))
                    {
                        Program.Debug.Log($"Macheo de datos con empleado {empleado.Nombre} {empleado.Apellido}");

                        AppData.RegistroHorario openRegister = registros.Where(x => x.Estado == Enums.ERegistroEstado.Abierto).Take(1).SingleOrDefault();

                        if (openRegister is object)
                        {
                            openRegister.Salida = DateTime.Now;
                            openRegister.Estado = Enums.ERegistroEstado.Cerrado;
                            Program.Debug.Log($"Se cerro el turno {openRegister.Id}");
                            DataContext.Current.RegistroHorarios.Update(openRegister);

                            double minuts = (openRegister.Salida - openRegister.Entrada).Value.TotalMinutes;
                            if (minuts < 1)
                            {
                                Beep(3000, 500, 4);
                                Program.Debug.Log ($"Se cancelo el turno. El tiempo era de {minuts}");
                                DataContext.Current.RegistroHorarios.Delete(openRegister.Id);
                                return;
                            }

                            Beep(1300, 100, 3);
                            Tools.Audio.PlayAudio(Program.Conf.AudioFingerprintFin);
                        }
                        else
                        {
                            AppData.RegistroHorario reg = new AppData.RegistroHorario
                            {
                                EmpladoId = empleado.Id,
                                Entrada = DateTime.Now,
                                Estado = Enums.ERegistroEstado.Abierto
                            };

                            DataContext.Current.RegistroHorarios.Insert(reg);


                            Program.Debug.Log("Se abrio un nuevo turno");
                            Beep(1500, 50, 6);
                            Tools.Audio.PlayAudio(Program.Conf.AudioFingerprintInicio);                            
                        }
                        fingerFind = true;
                        break;
                    }
                }

                if (!fingerFind)
                {
                    Tools.Audio.PlayAudio(Program.Conf.AudioFingerprintIncorrecto);
                    Beep(1010, 2000);
                }
            }
            catch (Exception ex)
            {
                Program.Debug.Log("Error verificando datos biometrico " + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void Beep(int frequency, int duration, int repeat = 1)
        {
            for(int i = 0; i < repeat; i++)
            {
                Console.Beep(frequency, duration);
            }
        }

        private void OnStop()
        {
            IsRuning = false;
            _lblState.Text = "Detenido";
            _btnStop.Visible = false;
            _btnStart.Visible = true;
            reader.StopCapture();

            Program.Debug.Log("Se detuvo el lector");
        }

        private void OnStart()
        {
            IsRuning = true;
            _lblState.Text = "Iniciado";
            _btnStop.Visible = true;
            _btnStart.Visible = false;
            reader.StartCapture();

            Program.Debug.Log("Se inicio el lector");
        }

        private void OnConsole()
        {
            m_consola.Show();
        }
    }
}
