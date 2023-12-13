using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MusicPlayer
    {
        private NAudio.Wave.WaveOutEvent waveOut;
        private NAudio.Wave.AudioFileReader audioFile;

        public MusicPlayer()
        {
            waveOut = new NAudio.Wave.WaveOutEvent();
        }

        public void Play(Song song)
        {
            if (waveOut.PlaybackState == NAudio.Wave.PlaybackState.Playing)
            {
                waveOut.Stop();
            }

            audioFile = new NAudio.Wave.AudioFileReader(song.FilePath);
            waveOut.Init(audioFile);
            waveOut.Play();
        }

        public void Pause()
        {
            if (waveOut.PlaybackState == NAudio.Wave.PlaybackState.Playing)
            {
                waveOut.Pause();
            }
        }


        public void Stop()
        {
            if (waveOut.PlaybackState == NAudio.Wave.PlaybackState.Playing)
            {
                waveOut.Stop();
                audioFile.Dispose();
            }
        }

        public void Volume(float volume)
        {
            if (waveOut != null)
            {
                waveOut.Volume = volume; // Задає гучність від 0 до 1 (0 - тихо, 1 - максимально голосно)
            }
        }

        public void FastForward(int secondsToSkip)
        {
            if (audioFile != null)
            {
                audioFile.CurrentTime += TimeSpan.FromSeconds(secondsToSkip);
           
            }
        }

        public void Rewind(int secondsToSkip)
        {
            if (audioFile != null)
            {
                audioFile.CurrentTime -= TimeSpan.FromSeconds(secondsToSkip);
            }
        }
    }
}
