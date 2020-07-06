using AppData;
using System;
using System.IO;
using System.Windows.Forms;

namespace Aplicacion.Vistas.Configuracion
{
    public partial class Control : UserControl
    {
        public Control()
        {
            InitializeComponent();
            _btnBuscarSonidoIncorrecto.Click += (o, e) => BuscarSonidoIncorrecto();
            _btnBuscarSonidoInicio.Click += (o, e) => BuscarSonidoInicio();
            _btnBuscarSonidoFinalizacion.Click += (o, e) => BuscarSonidoFin();
            _btnProbarSonido.Click += (o, e) => ProbarSonido();
            _btnGuardarAudio.Click += (o, e) => GuardarAudio();
            _btnGuardar.Click += (o, e) => Guardar();

            m_txtDatabaseLocation.Text = DataContext.Current.DataBaseLocation;
        }

        private void Guardar()
        {
            Program.Conf.MaxRegistros = (int)_numMaxRegistros.Value;
            Program.Conf.Save();
        }

        protected override void OnLoad(EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            _txtAudioIncorrecto.Text = Program.Conf.AudioFingerprintIncorrecto;
            _txtAudioInicio.Text = Program.Conf.AudioFingerprintInicio;
            _txtAudioFin.Text = Program.Conf.AudioFingerprintFin;
            _numMaxRegistros.Value = Program.Conf.MaxRegistros;
        }

        private void GuardarAudio()
        {
            if (!string.IsNullOrEmpty(_txtAudioIncorrecto.Text))
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "Resources/audio01" + Path.GetExtension(_txtAudioIncorrecto.Text);
                File.Copy(_txtAudioIncorrecto.Text, path, true);
                Program.Conf.AudioFingerprintIncorrecto = path;
            }

            if (!string.IsNullOrEmpty(_txtAudioInicio.Text))
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "Resources/audio02" + Path.GetExtension(_txtAudioInicio.Text);
                File.Copy(_txtAudioInicio.Text, path, true);
                Program.Conf.AudioFingerprintInicio = path;
            }

            if (!string.IsNullOrEmpty(_txtAudioFin.Text))
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "Resources/audio03" + Path.GetExtension(_txtAudioFin.Text);
                File.Copy(_txtAudioFin.Text, path, true);
                Program.Conf.AudioFingerprintFin = path;
            }

            Program.Conf.Save();
            Cargar();
        }

        private void ProbarSonido()
        {
            if (!string.IsNullOrEmpty(_txtAudioIncorrecto.Text))
            {
                label4.Text = "Escuchando Incorrecto";
                Update();
                Tools.Audio.PlayAudio(_txtAudioIncorrecto.Text);
            }

            if (!string.IsNullOrEmpty(_txtAudioInicio.Text))
            {
                label4.Text = "Escuchando Inicio";
                Update();
                Tools.Audio.PlayAudio(_txtAudioInicio.Text);
            }

            if (!string.IsNullOrEmpty(_txtAudioFin.Text))
            {
                label4.Text = "Escuchando Fin";
                Update();
                Tools.Audio.PlayAudio(_txtAudioFin.Text);
            }

            label4.Text = "";
        }

        private void BuscarSonidoFin()
        {
            string file = BuscarArchivoAudio();
            if (string.IsNullOrEmpty(file))
                return;

            _txtAudioFin.Text = file;
        }

        private void BuscarSonidoInicio()
        {
            string file = BuscarArchivoAudio();
            if (string.IsNullOrEmpty(file))
                return;

            _txtAudioInicio.Text = file;
        }

        private void BuscarSonidoIncorrecto()
        {
            string file = BuscarArchivoAudio();
            if (string.IsNullOrEmpty(file))
                return;

            _txtAudioIncorrecto.Text = file;
        }

        public string BuscarArchivoAudio()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Window Sound | *.wav",
                Multiselect = false
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }

            return string.Empty;
        }
    }
}
