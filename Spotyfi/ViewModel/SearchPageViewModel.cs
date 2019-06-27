using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Spotyfi.Annotations;
using Spotyfi.Model;

namespace Spotyfi.ViewModel
{
    public class SearchPageViewModel : INotifyPropertyChanged
    {
        private ICommand _playSongCommand;

        public ICommand PlaySongCommand
        {
            get => _playSongCommand;
            set
            {
                _playSongCommand = value;
                OnPropertyChanged(nameof(PlaySongCommand));
            }
        }


        private album _searchAlbumCover1;

        public album SearchAlbumCover1
        {
            get { return _searchAlbumCover1; }
            set
            {
                _searchAlbumCover1 = value;
                OnPropertyChanged(nameof(SearchAlbumCover1));
            }
        }

        private string _searchAlbumLabel1;

        public string SearchAlbumLabel1
        {
            get { return _searchAlbumLabel1; }
            set
            {
                _searchAlbumLabel1 = value;
                OnPropertyChanged(nameof(SearchAlbumLabel1));
            }
        }

        private album _searchAlbumCover2;

        public album SearchAlbumCover2
        {
            get { return _searchAlbumCover2; }
            set
            {
                _searchAlbumCover2 = value;
                OnPropertyChanged(nameof(SearchAlbumCover2));
            }
        }

        private string _searchAlbumLabel2;

        public string SearchAlbumLabel2
        {
            get { return _searchAlbumLabel2; }
            set
            {
                _searchAlbumLabel2 = value;
                OnPropertyChanged(nameof(SearchAlbumLabel2));
            }
        }

        private album _searchAlbumCover3;

        public album SearchAlbumCover3
        {
            get { return _searchAlbumCover3; }
            set
            {
                _searchAlbumCover3 = value;
                OnPropertyChanged(nameof(SearchAlbumCover3));
            }
        }

        private string _searchAlbumLabel3;

        public string SearchAlbumLabel3
        {
            get { return _searchAlbumLabel3; }
            set
            {
                _searchAlbumLabel3 = value;
                OnPropertyChanged(nameof(SearchAlbumLabel3));
            }
        }

        private album _searchAlbumCover4;

        public album SearchAlbumCover4
        {
            get { return _searchAlbumCover4; }
            set
            {
                _searchAlbumCover4 = value;
                OnPropertyChanged(nameof(SearchAlbumCover4));
            }
        }

        private string _searchAlbumLabel4;

        public string SearchAlbumLabel4
        {
            get { return _searchAlbumLabel4; }
            set
            {
                _searchAlbumLabel4 = value;
                OnPropertyChanged(nameof(SearchAlbumLabel4));
            }
        }






        private album _searchSongCover1;

        public album SearchSongCover1
        {
            get { return _searchSongCover1; }
            set
            {
                _searchSongCover1 = value;
                OnPropertyChanged(nameof(SearchSongCover1));
            }
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
            set
            {
                _searchSongCover2 = value;
                OnPropertyChanged(nameof(SearchSongCover2));
            }
        }

        private string _searchSongLabel2;

        public string SearchSongLabel2
        {
            get { return _searchSongLabel2; }
            set { _searchSongLabel2 = value; }
        }

        private album _searchSongCover3;

        public album SearchSongCover3
        {
            get { return _searchSongCover3; }
            set
            {
                _searchSongCover3 = value;
                OnPropertyChanged(nameof(SearchSongCover3));
            }
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
            set
            {
                _searchSongCover4 = value;
                OnPropertyChanged(nameof(SearchSongCover4));
            }
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

            if (SongResults.Count >= 1 && SongResults[0] != null)
                SongResult1 = SongResults[0];
            if (SongResults.Count >= 2 && SongResults[1] != null)
                SongResult2 = SongResults[1];
            if (SongResults.Count >= 3 && SongResults[2] != null)
                SongResult3 = SongResults[2];
            if (SongResults.Count >= 4 && SongResults[3] != null)
                SongResult4 = SongResults[3];

            AssignSearchResult(searchResults);

            PlaySongCommand = new DelegateCommand((args) =>
            {
                var songName = (string) args;



                song foundSong = Search.For(songName).Item1[0];

                if (foundSong != null)
                {
                    MessageBox.Show("I wanted to play: " + foundSong.name);
                }


            });


        }

        private void AssignSearchResult(Tuple<List<song>, List<album>, List<artist>> searchResults)
        {
            if(searchResults.Item1.Count >= 1)
            {
                SearchSongCover1 = searchResults.Item1[0].albums.FirstOrDefault();
                SearchSongLabel1 = searchResults.Item1[0].name;
            }
                
            if (searchResults.Item1.Count >= 2)
            {
                SearchSongCover2 = searchResults.Item1[1].albums.FirstOrDefault();
                SearchSongLabel2 = searchResults.Item1[1].name;
            }
                
            if (searchResults.Item1.Count >= 3)
            {
                SearchSongCover3 = searchResults.Item1[2].albums.FirstOrDefault();
                SearchSongLabel3 = searchResults.Item1[2].name;
            }
                
            if (searchResults.Item1.Count >= 4)
            {
                SearchSongCover4 = searchResults.Item1[3].albums.FirstOrDefault();
                SearchSongLabel4 = searchResults.Item1[3].name;
            }

            if (searchResults.Item2.Count >= 1)
            {
                SearchAlbumCover1 = searchResults.Item2[0];
                SearchAlbumLabel1 = searchResults.Item2[0].name;
            }

            if (searchResults.Item2.Count >= 2)
            {
                SearchAlbumCover2 = searchResults.Item2[1];
                SearchAlbumLabel2 = searchResults.Item2[1].name;
            }

            if (searchResults.Item2.Count >= 3)
            {
                SearchAlbumCover3 = searchResults.Item2[2];
                SearchAlbumLabel3 = searchResults.Item2[2].name;
            }

            if (searchResults.Item2.Count >= 4)
            {
                SearchAlbumCover4 = searchResults.Item2[3];
                SearchAlbumLabel4 = searchResults.Item2[3].name;
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
