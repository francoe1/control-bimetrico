using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Datos
{
    public class Configuracion
    {
        public static string FilePath { get { return AppDomain.CurrentDomain.BaseDirectory + "app.conf"; } }

        public string AudioFingerprintIncorrecto = "";
        public string AudioFingerprintInicio = "";
        public string AudioFingerprintFin = "";
        public int MaxRegistros = 250;

        public void Save()
        {
            string[] data = new string[]
            {
                AudioFingerprintIncorrecto,
                AudioFingerprintInicio,
                AudioFingerprintFin,
                MaxRegistros.ToString(),
            };

            File.WriteAllLines(FilePath, data);
        }

        public void Load()
        {
            if (!File.Exists(FilePath))
                Save();

            string[] data = File.ReadAllLines(FilePath);
            AudioFingerprintIncorrecto = data[0];
            AudioFingerprintInicio = data[1];
            AudioFingerprintFin = data[2];
            MaxRegistros = int.Parse(data[3]);
        }
    }
}
