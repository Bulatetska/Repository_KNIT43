using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_5.task_3
{
    internal class Book
    {
        protected string title;
        protected string author;
        protected int price;


        public Book(string title, string author, int price)
        {
            this.title = title;
            this.author = author;
            this.price = price;
        }


        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }


        public virtual void Print()
        {
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Author: " + author);
            Console.WriteLine("Price: " + price);
        }
    }
}
