using Aplicacion.Datos;
using DPFP;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

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
                Program.Debug.Log("Se capturo un dato biometrico");

                bool fingerFind = false;

                foreach (Datos.Empleado empleado in Program.DbContext.Empleado.FindAll())
                {
                    IEnumerable<DatosBiometrico> datosBiometricos = Program.DbContext.DatosBiometricos.Find(x => x.EmpladoId == empleado.Id);
                    IEnumerable<Datos.RegistroHorario> registros = Program.DbContext.RegistroHorarios.Find(x => x.EmpladoId == empleado.Id);
                    List<byte[]> datos = new List<byte[]>();

                    foreach (DatosBiometrico biometrico in datosBiometricos)
                        datos.Add(biometrico.Data);

                    if (reader.Verify(sample, datos.ToList()))
                    {
                        Program.Debug.Log($"Macheo de datos con empleado {empleado.Nombre} {empleado.Apellido}");

                        Datos.RegistroHorario openRegister = registros.Take(1).SingleOrDefault(x => x.Estado == Enums.ERegistroEstado.Abierto);

                        if (openRegister is object)
                        {
                            openRegister.Salida = DateTime.Now;
                            openRegister.Estado = Enums.ERegistroEstado.Cerrado;
                            Program.Debug.Log($"Se cerro el turno {openRegister.Id}");
                            Program.DbContext.RegistroHorarios.Update(openRegister);
                            Tools.Audio.PlayAudio(Program.Conf.AudioFingerprintFin);
                        }
                        else
                        {
                            Datos.RegistroHorario reg = new Datos.RegistroHorario
                            {
                                EmpladoId = empleado.Id,
                                Entrada = DateTime.Now,
                                Estado = Enums.ERegistroEstado.Abierto
                            };

                            Program.DbContext.RegistroHorarios.Insert(reg);

                            Program.Debug.Log("Se abrio un nuevo turno");
                            Tools.Audio.PlayAudio(Program.Conf.AudioFingerprintInicio);
                        }
                        fingerFind = true;
                        break;
                    }
                }

                if (!fingerFind)
                    Tools.Audio.PlayAudio(Program.Conf.AudioFingerprintIncorrecto);
            }
            catch (Exception ex)
            {
                Program.Debug.Log("Error verificando datos biometrico " + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void OnStop()
        {
            IsRuning = false;
            _lblState.Text = "Detenido";
            _btnStop.Enabled = false;
            _btnStart.Enabled = true;
            reader.StopCapture();

            Program.Debug.Log("Se detuvo el lector");
        }

        private void OnStart()
        {
            IsRuning = true;
            _lblState.Text = "Iniciado";
            _btnStop.Enabled = true;
            _btnStart.Enabled = false;
            reader.StartCapture();

            Program.Debug.Log("Se inicio el lector");
        }

        private void OnConsole()
        {
            Consola form = new Consola();
            form.Show();
        }
    }
}
