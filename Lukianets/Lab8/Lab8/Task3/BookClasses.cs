using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClasses
{
    public class Book
    {
        private string title;
        private string author;
        private double price;

        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public double Price { get => price; set => price = value; }

        public Book(string title, string author, double price)
        {
            this.title = title;
            this.author = author;
            this.price = price;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Title: {title}, Author: {author}, Price: {price}");
        }
    }

    public class BookGenre : Book
    {
        private string genre;

        public string Genre { get => genre; set => genre = value; }

        public BookGenre(string title, string author, double price, string genre)
            : base(title, author, price)
        {
            this.genre = genre;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Genre: {genre}");
        }
    }

    public class BookGenrePubl : BookGenre
    {
        private string publisher;

        public string Publisher { get => publisher; set => publisher = value; }

        public BookGenrePubl(string title, string author, double price, string genre, string publisher)
            : base(title, author, price, genre)
        {
            this.publisher = publisher;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Publisher: {publisher}");
        }
    }
}
