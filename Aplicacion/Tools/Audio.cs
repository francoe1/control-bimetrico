using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Tools
{
    public static class Audio
    {
        private static System.Media.SoundPlayer WavPlayer { get; set; }

        public static void PlayAudio(string file)
        {
            if (!File.Exists(file))
                return;
            string ext = Path.GetExtension(file);

            if (ext.ToLower().Equals(".wav"))
            {
                using (System.Media.SoundPlayer WavPlayer = new System.Media.SoundPlayer())
                {
                    WavPlayer.SoundLocation = file;
                    WavPlayer.PlaySync();
                }
            }
        }
    }
}
