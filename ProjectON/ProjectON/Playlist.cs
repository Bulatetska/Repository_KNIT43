using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectON
{
    public class Playlist
    {
        public string Name { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();

        public void Shuffle()
        {
            Random random = new Random();
            Songs = Songs.OrderBy(x => random.Next()).ToList();
        }
        public void AddSong(Song song)
        { Songs.Add(song); }

        public void RemoveSong(Song song)
        {  Songs.Remove(song); }

        public void RemoveSongByIndex(int index)
        {
            if (index >= 0 && index < Songs.Count) { Songs.RemoveAt(index); }
        }

        public void ClearPlaylist()
        { Songs.Clear(); }
    }
}
