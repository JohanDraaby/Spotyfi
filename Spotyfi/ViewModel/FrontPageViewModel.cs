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




        public FrontPageViewModel()
        {
            
            var searchResults = Search.For("tunak");
            var tunakAlbum = searchResults.Item2.FirstOrDefault();

            if (tunakAlbum != null)
            {
                RecentAlbum1 = tunakAlbum;
            }

            // Can subscribe to an Albums PropertyChanged event and call this.OnPropertyChanged with the name of 
            // the changed album property.
            // this way we're notifying the ViewModel of the change.
            RecentAlbum1.PropertyChanged += (sender, args) => { this.OnPropertyChanged(nameof(RecentAlbum1)); };

            // To see this works.
            RecentAlbum1.name += " TEST";

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
