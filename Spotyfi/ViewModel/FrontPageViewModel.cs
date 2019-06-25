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



        public FrontPageViewModel()
        {

            // AssignRandomRecentAlbums();
            SubscribeToAlbumChanges();


        }

        private void AssignRandomRecentAlbums()
        {
            var searchResults = Search.For("");

            Random rng = new Random();

            // Assign random recent albums.
            RecentAlbum1 = searchResults.Item2[rng.Next(0, searchResults.Item2.Count)];
            RecentAlbum2 = searchResults.Item2[rng.Next(0, searchResults.Item2.Count)];
            RecentAlbum3 = searchResults.Item2[rng.Next(0, searchResults.Item2.Count)];
            RecentAlbum4 = searchResults.Item2[rng.Next(0, searchResults.Item2.Count)];
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
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
