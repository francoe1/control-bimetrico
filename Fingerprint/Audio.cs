using System;
using System.Collections.Generic;
using System.Linq;

namespace Fingerprint
{
    public static class Audio
    {
        public static List<AudioClip> Clips { get; private set; } = new List<AudioClip> { 
            new AudioClip(2, new AudioClip.Wave(2000, 60), new AudioClip.Wave(2100, 80)),
            new AudioClip(2, new AudioClip.Wave(500, 60), new AudioClip.Wave(800, 80), new AudioClip.Wave(400, 60)),
            new AudioClip(3, new AudioClip.Wave(2000, 100), new AudioClip.Wave(2100, 100)),
        };

        public static void PlayClip(int index)
        {
            Clips[index].Play();
        }
    }

    public class AudioClip
    {
        public class Wave
        {
            public int Frequency { get; set; }
            public int Duration { get; set; }

            public Wave(int frequency, int duration)
            {
                Frequency = frequency;
                Duration = duration;
            }
        }

        private List<Wave> m_wave { get; set; } = new List<Wave>();

        public int Duration => m_wave.Sum(x => x.Duration);
        public int Repeat { get; private set; } = 1;

        public AudioClip() { }

        public AudioClip(int repeat, params Wave[] waves)
        {
            Repeat = Math.Max(1, repeat);
            Insert(waves);
        }

        public void Insert(params Wave[] waves)
        {
            m_wave.AddRange(waves);
        }

        public void Play()
        {
            for (int i = 0; i < Repeat; i++)
            {
                foreach (Wave wave in m_wave)
                    Console.Beep(wave.Frequency, wave.Duration);
            }
        }
    }
}
