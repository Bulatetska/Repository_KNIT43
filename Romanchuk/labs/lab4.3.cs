using System;
class Program {
	class Book
	{
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }

        public Book(string title, string author, int price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public virtual void Print()
        {
            Console.WriteLine($"\nНазва книги: {this.Title}\nАвтор: {this.Author}\nЦіна: {this.Price}");
        }
	}

    class BookGenre: Book
    {
        public string Genre { get; set; }

        public BookGenre(string title, string author, int price, string genre): base(title, author, price)
        {
            this.Genre = genre;
        }

        public override void Print()
        {      
            base.Print();
            Console.WriteLine($"Жанр: {this.Genre}");
        }
    }

    sealed class BookGenrePubl : BookGenre
    {
        public string Publisher { get; set; }

        public BookGenrePubl(string title, string author, int price, string genre, string publisher): base(title, author, price, genre)
        {
            this.Publisher = publisher;
        }

        public override void Print()
        {      
            base.Print();
            Console.WriteLine($"Видавництво: {this.Publisher}");
        }
    }

	static void Main() {
	    Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 10);
        book1.Print();
        
        BookGenre book2 = new BookGenre("The Great Gatsby", "F. Scott Fitzgerald", 10, "Drama");
        book2.Print();
        
        BookGenrePubl book3 = new BookGenrePubl("The Great Gatsby", "F. Scott Fitzgerald", 10, "Drama", "Scribner");
        book3.Print();
	}
}
