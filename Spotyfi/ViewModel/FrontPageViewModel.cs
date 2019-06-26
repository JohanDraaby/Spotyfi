using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spotyfi.Annotations;
using Spotyfi.Model;

namespace Spotyfi.ViewModel
{
    public class FrontPageViewModel : INotifyPropertyChanged
    {

        #region recentAlbumProperties
        private album _recentAlbum1 = new album();

        public album RecentAlbum1
        {
            get => _recentAlbum1;
            set
            {
                _recentAlbum1 = value;
                OnPropertyChanged(nameof(RecentAlbum1));
            }
        }

        private album _recentAlbum2 = new album();

        public album RecentAlbum2
        {
            get => _recentAlbum2;
            set
            {
                _recentAlbum2 = value;
                OnPropertyChanged(nameof(RecentAlbum2));
            }
        }

        private album _recentAlbum3 = new album();

        public album RecentAlbum3
        {
            get => _recentAlbum3;
            set
            {
                _recentAlbum3 = value; 
                OnPropertyChanged(nameof(RecentAlbum3));
            }
        }

        private album _recentAlbum4 = new album();

        public album RecentAlbum4
        {
            get => _recentAlbum4;
            set
            {
                _recentAlbum4 = value; 
                OnPropertyChanged(nameof(RecentAlbum4));
            }
        }
        #endregion

        #region popAlbumProperties
        private album _popAlbum1;
        private album _popAlbum2;
        private album _popAlbum3;
        private album _popAlbum4;
        
        public album PopAlbum1
        {
            get => _popAlbum1;
            set
            {
                _popAlbum1 = value;
                OnPropertyChanged(nameof(PopAlbum1));
            }
        }

        public album PopAlbum2
        {
            get => _popAlbum2;
            set
            {
                _popAlbum2 = value;
                OnPropertyChanged(nameof(PopAlbum2));
            }
        }

        public album PopAlbum3
        {
            get => _popAlbum3;
            set
            {
                _popAlbum3 = value;
                OnPropertyChanged(nameof(PopAlbum3));
            }
        }

        public album PopAlbum4
        {
            get => _popAlbum4;
            set
            {
                _popAlbum4 = value;
                OnPropertyChanged(nameof(PopAlbum4));
            }
        }
        #endregion

        #region forYouAlbumProperties
        private album _forYouAlbum1;
        private album _forYouAlbum2;
        private album _forYouAlbum3;
        private album _forYouAlbum4;

        public album ForYouAlbum1
        {
            get => _forYouAlbum1;
            set
            {
                _forYouAlbum1 = value;
                OnPropertyChanged(nameof(ForYouAlbum1));
            }
        }

        public album ForYouAlbum2
        {
            get => _forYouAlbum2;
            set
            {
                _forYouAlbum2 = value;
                OnPropertyChanged(nameof(ForYouAlbum2));
            }
        }

        public album ForYouAlbum3
        {
            get => _forYouAlbum3;
            set
            {
                _forYouAlbum3 = value;
                OnPropertyChanged(nameof(ForYouAlbum3));
            }
        }

        public album ForYouAlbum4
        {
            get => _forYouAlbum4;
            set
            {
                _forYouAlbum4 = value;
                OnPropertyChanged(nameof(ForYouAlbum4));
            }
        }
        #endregion

        public FrontPageViewModel()
        {

            AssignRandomAlbums();
            SubscribeToAlbumChanges();


        }

        private void AssignRandomAlbums()
        {
            var searchResults = Search.For("");

            Random rng = new Random();

            // Assign random recent albums.
            RecentAlbum1 = searchResults.Item2[rng.Next(0, searchResults.Item2.Count)];
            RecentAlbum2 = searchResults.Item2[rng.Next(0, searchResults.Item2.Count)];
            RecentAlbum3 = searchResults.Item2[rng.Next(0, searchResults.Item2.Count)];
            RecentAlbum4 = searchResults.Item2[rng.Next(0, searchResults.Item2.Count)];

            // Assign random pop albums.
            PopAlbum1 = searchResults.Item2[rng.Next(0, searchResults.Item2.Count)];
            PopAlbum2 = searchResults.Item2[rng.Next(0, searchResults.Item2.Count)];
            PopAlbum3 = searchResults.Item2[rng.Next(0, searchResults.Item2.Count)];
            PopAlbum4 = searchResults.Item2[rng.Next(0, searchResults.Item2.Count)];

            // Assign random for you albums.
            ForYouAlbum1 = searchResults.Item2[rng.Next(0, searchResults.Item2.Count)];
            ForYouAlbum2 = searchResults.Item2[rng.Next(0, searchResults.Item2.Count)];
            ForYouAlbum3 = searchResults.Item2[rng.Next(0, searchResults.Item2.Count)];
            ForYouAlbum4 = searchResults.Item2[rng.Next(0, searchResults.Item2.Count)];
        }

        private void SubscribeToAlbumChanges()
        {
            // Can subscribe to an Albums PropertyChanged event and call this.OnPropertyChanged with the name of 
            // the changed album property.
            // this way we're notifying the ViewModel of the change.
            RecentAlbum1.PropertyChanged += (sender, args) => { this.OnPropertyChanged(nameof(RecentAlbum1)); };
            RecentAlbum2.PropertyChanged += (sender, args) => { this.OnPropertyChanged(nameof(RecentAlbum2)); };
            RecentAlbum3.PropertyChanged += (sender, args) => { this.OnPropertyChanged(nameof(RecentAlbum3)); };
            RecentAlbum4.PropertyChanged += (sender, args) => { this.OnPropertyChanged(nameof(RecentAlbum4)); };

            PopAlbum1.PropertyChanged += (sender, args) => { this.OnPropertyChanged(nameof(PopAlbum1)); };
            PopAlbum2.PropertyChanged += (sender, args) => { this.OnPropertyChanged(nameof(PopAlbum2)); };
            PopAlbum3.PropertyChanged += (sender, args) => { this.OnPropertyChanged(nameof(PopAlbum3)); };
            PopAlbum4.PropertyChanged += (sender, args) => { this.OnPropertyChanged(nameof(PopAlbum4)); };

            ForYouAlbum1.PropertyChanged += (sender, args) => { this.OnPropertyChanged(nameof(RecentAlbum1)); };
            ForYouAlbum2.PropertyChanged += (sender, args) => { this.OnPropertyChanged(nameof(RecentAlbum2)); };
            ForYouAlbum3.PropertyChanged += (sender, args) => { this.OnPropertyChanged(nameof(RecentAlbum3)); };
            ForYouAlbum4.PropertyChanged += (sender, args) => { this.OnPropertyChanged(nameof(RecentAlbum4)); };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
