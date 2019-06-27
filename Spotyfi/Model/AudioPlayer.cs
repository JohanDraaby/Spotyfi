using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Spotyfi.Model
{

    public class AudioPlayerCurrentSongChangedEventArgs : EventArgs
    {
        public song SongChangedTo { get; set; }

        public AudioPlayerCurrentSongChangedEventArgs(song songChangedTo)
        {
            SongChangedTo = songChangedTo;
        }
    }


    public static class AudioPlayer
    {
        private static bool _initialized = false;

        public static event EventHandler<AudioPlayerCurrentSongChangedEventArgs> AudioPlayerSongChanged;
        public static event EventHandler StartedPlaying;
        public static event EventHandler StoppedPlaying;
        public static event EventHandler PausedPlaying;
        public static event EventHandler EndedPlaying;

        private static readonly MediaPlayer MediaPlayer = new MediaPlayer();

        private static song _currentSong;

        public static song CurrentSong
        {
            get => _currentSong;
            set
            {
                _currentSong = value;
                MediaPlayer.Open(new Uri(Environment.CurrentDirectory + value.path));
                AudioPlayerSongChanged?.Invoke(null, new AudioPlayerCurrentSongChangedEventArgs(value));
            }
        }

        private static void Initialize()
        {
            MediaPlayer.MediaEnded += (sender, args) =>
            {
                EndedPlaying?.Invoke(null, EventArgs.Empty);
            };
        }

        public static void Play()
        {
            if(!_initialized) Initialize();

            MediaPlayer.Play();
            StartedPlaying?.Invoke(null, EventArgs.Empty);
        }

        public static void Pause()
        {
            if (!_initialized) Initialize();

            MediaPlayer.Pause();
            PausedPlaying?.Invoke(null, EventArgs.Empty);
        }

        public static void Stop()
        {
            if (!_initialized) Initialize();

            MediaPlayer.Stop();
            StoppedPlaying?.Invoke(null, EventArgs.Empty);
        }
    }
}
