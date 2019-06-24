using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotyfi.Model
{
    public static class Search
    {

        public static Tuple<List<song>, List<album>, List<artist>> For(string searchInput)
        {
            spotyfiEntities entities = new spotyfiEntities();

            List<song> songs = entities.songs.Where(s => s.name.ToUpper().Contains(searchInput.ToUpper())).ToList();

            List<album> albums = entities.albums.Where(a => a.name.ToUpper().Contains(searchInput.ToUpper())).ToList();

            List<artist> artists = entities.artists.Where(a => a.artist_name.ToUpper().Contains(searchInput.ToUpper()))
                .ToList();

            // Add missing songs that are part of albums.
            foreach (album album in albums)
            {
                foreach (song song in album.songs)
                {
                    if (!songs.Contains(song))
                        songs.Add(song);
                }
            }

            // Add missing songs that are created by those artists.
            foreach (artist artist in artists)
            {
                foreach (song song in artist.songs)
                {
                    if (!songs.Contains(song))
                        songs.Add(song);
                }
            }

            return new Tuple<List<song>, List<album>, List<artist>>(songs, albums, artists);
        }


    }
}
