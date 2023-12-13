using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectON
{
    public class Song
    {
        public string Title { get; set; }   
        public string Artist { get; set; }
        public string FilePath { get; set; }

        public void DisplaySongInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Artist: {Artist}");
            Console.WriteLine($"File Path: {FilePath}");
        }

    }
}
