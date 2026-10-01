using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_5.task_3
{
    internal sealed class BookGenrePubl : BookGenre
    {
        private string publisher;


        public BookGenrePubl(string title, string author, int price, string genre, string publisher)
            : base(title, author, price, genre)
        {
            this.publisher = publisher;
        }


        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Publisher: " + publisher);
        }
    }
}
