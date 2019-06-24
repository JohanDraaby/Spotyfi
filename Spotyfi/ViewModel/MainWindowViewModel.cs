﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Spotyfi.Annotations;
using Spotyfi.Model;

namespace Spotyfi.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

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

        private ICommand _closeApp;

        public ICommand CloseApp
        {
            get { return _closeApp; }
            set { _closeApp = value; }
        }


        //--------------------------------------------------------


        public MainWindowViewModel()
        {
            CloseApp = new DelegateCommand(CloseSpotyfi);
            _mediaPlayer = new MediaPlayer();
            _mediaPlayer.Open(new Uri(@"D:\CloudStation\Uddannelse\ZBC\Projekter\Unity Spil Projekt\BackgroundMusic.mp3"));
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
