using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Spotyfi.Model
{

    


    public static class AudioPlayer
    {

        public static event EventHandler AudioPlayerSongChanged;
        public static event EventHandler StartedPlaying;
        public static event EventHandler StoppedPlaying;
        public static event EventHandler PausedPlaying;


        private static readonly MediaPlayer MediaPlayer = new MediaPlayer();


        

        private static song _currentSong;

        public static song CurrentSong
        {
            get => _currentSong;
            set
            {
                _currentSong = value;
                MediaPlayer.Open(new Uri(Environment.CurrentDirectory + value.path));
                AudioPlayerSongChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        public static void Play()
        {
            MediaPlayer.Play();
            StartedPlaying?.Invoke(null, EventArgs.Empty);
        }

        public static void Pause()
        {
            MediaPlayer.Pause();
            PausedPlaying?.Invoke(null, EventArgs.Empty);
        }

        public static void Stop()
        {
            MediaPlayer.Stop();
            StoppedPlaying?.Invoke(null, EventArgs.Empty);
        }
    }
}
