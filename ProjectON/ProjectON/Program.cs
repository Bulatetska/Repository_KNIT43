// See https://aka.ms/new-console-template for more information
using ProjectON;

Console.WriteLine("Hello, World!");
Song mySong =  new Song();
mySong.Title = "Title";
mySong.Artist = "Artist";
mySong.FilePath = "Filepath";

mySong.DisplaySongInfo();