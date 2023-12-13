using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MusicLibrary
    {
        public List AllSongs { get; set; } = new List();
        public List Playlists { get; set; } = new List();

        public void AddSongToLibrary(Song song)
        {
            AllSongs.Add(song);
        }

        public void RemoveSongFromLibrary(Song song)
        {
            AllSongs.Remove(song);
            // Також слід видалити пісню з усіх плейлистів, де вона може бути
            foreach (var playlist in Playlists)
            {
                playlist.Songs.Remove(song);
            }
        }

        public void CreatePlaylist(string playlistName)
        {
            Playlist newPlaylist = new Playlist { Name = playlistName };
            Playlists.Add(newPlaylist);
        }

        public void RemovePlaylist(Playlist playlist)
        {
            Playlists.Remove(playlist);
        }

        // Додайте інші методи за необхідності, наприклад, отримання інформації про плейлист або пісню
    }
}
