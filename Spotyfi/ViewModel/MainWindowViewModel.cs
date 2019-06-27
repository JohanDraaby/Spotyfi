using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Spotyfi.Annotations;
using Spotyfi.Model;

namespace Spotyfi.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ICommand _playCommand;

        public ICommand PlayCommand
        {
            get => _playCommand;
            set
            {
                _playCommand = value;
                OnPropertyChanged(nameof(PlayCommand));
            }
        }


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

        private double _currentPositionMinutes;

        public double CurrentPositionMinutes
        {
            get => _currentPositionMinutes;
            set
            {
                _currentPositionMinutes = value;
                OnPropertyChanged(nameof(CurrentPositionMinutes));
            }
        }

        public MediaPlayer MediaPlayer => _mediaPlayer;

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
                AudioPlayer.Volume = value / 100;
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

            song myTestSong = new song();
            myTestSong.name = "TESTER SONG";
            myTestSong.path =
                @"/Songs/tunak-tunak-tun-dahler-mendi.mp3";
            album testAlbum = new album();
            testAlbum.image_path = "/Images/Albums/tunaktuncover.jfif";
            List<album> testAlbumList = new List<album>();
            testAlbumList.Add(testAlbum);
            myTestSong.albums = testAlbumList;
            artist testArtist = new artist();
            artist testArtist2 = new artist();
            testArtist.artist_name = "TEST ARTIST 1";
            testArtist2.artist_name = "TEST ARTIST 2";
            List<artist> testArtistList = new List<artist>();
            testArtistList.Add(testArtist);
            testArtistList.Add(testArtist2);
            myTestSong.artists = testArtistList;

            CurrentSong = myTestSong;

            //_mediaPlayer.Open(new Uri(@"C:\Users\Velreine\CloudStation\Uddannelse\ZBC\Projekter\Unity Spil Projekt\BackgroundMusic.mp3"));
            //_mediaPlayer.Open(new Uri(myTestSong.path));
            //_mediaPlayer.Volume = 0.1;
            AudioPlayer.CurrentSong = myTestSong;
            //AudioPlayer.Play();

            PropertyChanged += (sender, args) =>
            {
                
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


            AudioPlayer.PausedPlaying += (sender, args) =>
            {
                IsPlaying = false;
                this.PlayButtonSource = "PlayCircleOutline";
            };
            AudioPlayer.StartedPlaying += (sender, args) =>
            {
                IsPlaying = true;
                this.PlayButtonSource = "PauseCircleOutline";
            };
            AudioPlayer.StoppedPlaying += (sender, args) =>
            {
                IsPlaying = false;
                this.PlayButtonSource = "PlayCircleOutline";
            };
            AudioPlayer.EndedPlaying += (sender, args) =>
            {
                IsPlaying = false;
                this.PlayButtonSource = "PlayCircleOutline";
            };

            AudioPlayer.AudioPlayerSongChanged += (sender, args) =>
            {
                song changedSong = args.SongChangedTo;

                CurrentSong = changedSong;
            };

            this.PlayCommand = new DelegateCommand(PlaySongFunc);

        }




        //--------------------------------------------------------

        private void PlaySongFunc(object args)
        {

            if (IsPlaying)
            {
                AudioPlayer.Pause();
            }
            else
            {
                AudioPlayer.Play();
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
