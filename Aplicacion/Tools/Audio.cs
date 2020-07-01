using System.IO;

namespace Aplicacion.Tools
{
    public static class Audio
    {
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
