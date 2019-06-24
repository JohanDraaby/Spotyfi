using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Spotyfi.Annotations;
using Spotyfi.Model;

namespace Spotyfi.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        private MediaPlayer _mediaPlayer;

        private bool _isPlaying = false;

        public bool IsPlaying
        {
            get { return _isPlaying; }
            set
            {
                _isPlaying = value;
                OnPropertyChanged(nameof(IsPlaying));
            }
        }

        private ICommand _closeApp;

        private ICommand _playSong;

        public ICommand PlaySong
        {
            get { return _playSong; }
            set { _playSong = value; }
        }

        public ICommand CloseApp
        {
            get { return _closeApp; }
            set { _closeApp = value; }
        }


        //--------------------------------------------------------


        public MainWindowViewModel()
        {
            CloseApp = new DelegateCommand(CloseSpotyfi);
            _playSong = new DelegateCommand(PlaySongFunc);
            _mediaPlayer = new MediaPlayer();

            

        }


        //--------------------------------------------------------

        private void PlaySongFunc(object args)
        {
            _mediaPlayer.Open(new Uri(@"D:\CloudStation\Uddannelse\ZBC\Projekter\Unity Spil Projekt\BackgroundMusic.mp3"));
            _mediaPlayer.Play();
            _mediaPlayer.Volume = 20;
        }


        private void CloseSpotyfi(object args)
        {
            Environment.Exit(0);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
