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
    public class SearchPageViewModel : INotifyPropertyChanged
    {

        private album _searchSongCover1;

        public album SearchSongCover1
        {
            get { return _searchSongCover1; }
            set { _searchSongCover1 = value; }
        }

        private string _searchSongLabel1;

        public string SearchSongLabel1
        {
            get { return _searchSongLabel1; }
            set { _searchSongLabel1 = value; }
        }


        private album _searchSongCover2;

        public album SearchSongCover2
        {
            get { return _searchSongCover2; }
            set { _searchSongCover2 = value; }
        }
        private album _searchSongCover3;

        private string _searchSongLabel2;

        public string SearchSongLabel2
        {
            get { return _searchSongLabel2; }
            set { _searchSongLabel2 = value; }
        }
        public album SearchSongCover3
        {
            get { return _searchSongCover3; }
            set { _searchSongCover3 = value; }
        }

        private string _searchSongLabel3;

        public string SearchSongLabel3
        {
            get { return _searchSongLabel3; }
            set { _searchSongLabel3 = value; }
        }

        private album _searchSongCover4;

        public album SearchSongCover4
        {
            get { return _searchSongCover4; }
            set { _searchSongCover4 = value; }
        }
        private string _searchSongLabel4;

        public string SearchSongLabel4
        {
            get { return _searchSongLabel4; }
            set { _searchSongLabel4 = value; }
        }


        private song _songResult1;

        public song SongResult1
        {
            get => _songResult1;
            set
            {
                _songResult1 = value; 
                OnPropertyChanged(nameof(SongResult1));
            }
        }

        private song _songResult2;

        public song SongResult2
        {
            get => _songResult2;
            set
            {
                _songResult2 = value;
                OnPropertyChanged(nameof(SongResult2));
            }
        }

        private song _songResult3;

        public song SongResult3
        {
            get => _songResult3;
            set
            {
                _songResult3 = value;
                OnPropertyChanged(nameof(SongResult3));
            }
        }

        private song _songResult4;

        public song SongResult4
        {
            get => _songResult4;
            set
            {
                _songResult4 = value;
                OnPropertyChanged(nameof(SongResult4));
            }
        }


        public static string RecentSearchInput { get; set; }

        private List<song> _songResults;

        public List<song> SongResults
        {
            get => _songResults;
            set
            {
                _songResults = value; 
                OnPropertyChanged(nameof(SongResults));
            }
        }

        private List<album> _albumResults;

        public List<album> AlbumResults
        {
            get => _albumResults;
            set
            {
                _albumResults = value;
                OnPropertyChanged(nameof(AlbumResults));
            }
        }

        private List<artist> _artistResults;

        public List<artist> ArtistResults
        {
            get => _artistResults;
            set
            {
                _artistResults = value; 
                OnPropertyChanged(nameof(ArtistResults));
            }
        }

        public SearchPageViewModel()
        {
            Tuple<List<song>, List<album>, List<artist>> searchResults = Search.For(RecentSearchInput);
            SongResults = searchResults.Item1;
            AlbumResults = searchResults.Item2;
            ArtistResults = searchResults.Item3;

            if (SongResults[0] != null)
                SongResult1 = SongResults[0];
            if (SongResults[1] != null)
                SongResult2 = SongResults[1];
            if (SongResults[2] != null)
                SongResult3 = SongResults[2];
            if (SongResults[3] != null)
                SongResult4 = SongResults[3];
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
