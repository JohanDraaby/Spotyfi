using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Spotyfi.Annotations;
using Spotyfi.Model;

namespace Spotyfi.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        private string _mainFrameSource = "/Spotyfi;component/View/FrontPageView.xaml";

        public string MainFrameSource
        {
            get => _mainFrameSource;
            set
            {
                _mainFrameSource = value;
                OnPropertyChanged(nameof(MainFrameSource));
            }
        }


        private readonly MediaPlayer _mediaPlayer;

        private song _currentSong;

        public song CurrentSong
        {
            get => _currentSong;
            set
            {
                _currentSong = value;
                OnPropertyChanged(nameof(CurrentSong));
            }
        }

        private double _playerVolume = 1;

        public double PlayerVolume
        {
            get => _playerVolume;
            set
            {
                _playerVolume = value;
                OnPropertyChanged(nameof(PlayerVolume));
            }
        }


        private string _playButtonSource = "PlayCircleOutline";

        public string PlayButtonSource
        {
            get => _playButtonSource;
            set
            {
                _playButtonSource = value;
                OnPropertyChanged(nameof(PlayButtonSource));
            }
        }





        private bool _isPlaying = false;

        public bool IsPlaying
        {
            get => _isPlaying;
            set
            {
                _isPlaying = value;
                OnPropertyChanged(nameof(IsPlaying));
            }
        }

        private string _SearchBox;
        public string SearchBox
        {
            get { return _SearchBox; }
            set
            {
                _SearchBox = value;
                OnPropertyChanged(nameof(SearchBox));
            }
        }



        //--------------------------------------------------------


        public MainWindowViewModel()
        {
            _mediaPlayer = new MediaPlayer();
            _mediaPlayer.Open(new Uri(@"C:\Users\Velreine\CloudStation\Uddannelse\ZBC\Projekter\Unity Spil Projekt\BackgroundMusic.mp3"));
            _mediaPlayer.Volume = 0.1;

            PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(IsPlaying))
                {
                    if (!_isPlaying)
                    {
                        this.PlayButtonSource = "PlayCircleOutline";
                    }
                    else
                    {
                        this.PlayButtonSource = "PauseCircleOutline";
                        
                    }

                    PlaySongFunc(null);
                }

                if (args.PropertyName == nameof(PlayerVolume))
                {
                    _mediaPlayer.Volume = PlayerVolume / 100;
                }

                if (args.PropertyName == nameof(SearchBox))
                {
                    //var m = Search.For(SearchBox);
                    MainFrameSource = "/Spotyfi;component/View/SearchPageView.xaml";
                    SearchPageViewModel.RecentSearchInput = SearchBox;
                    if (SearchBox == "")
                    {
                        MainFrameSource = "/Spotyfi;component/View/FrontPageView.xaml";

                    }
                }

            };
        }



        //--------------------------------------------------------

        private void PlaySongFunc(object args)
        {

            if (!_isPlaying)
            {
                _mediaPlayer.Pause();
            }
            else
            {
                _mediaPlayer.Play();
            }


        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
