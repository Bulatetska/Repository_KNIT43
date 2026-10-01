using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_5.task_3
{
    internal class BookGenre : Book
    {
        protected string genre;


        public BookGenre(string title, string author, int price, string genre)
            : base(title, author, price)
        {
            this.genre = genre;
        }


        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Genre: " + genre);
        }
    }
}
