
using System;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public double Price { get; set; }

    public Book(string title, string author, double price)
    {
        Title = title;
        Author = author;
        Price = price;
    }

    public virtual void Print()
    {
        Console.WriteLine("Назва: " + Title);
        Console.WriteLine("Автор: " + Author);
        Console.WriteLine("Ціна: " + Price);
    }
}

class BookGenre : Book
{
    public string Genre { get; set; }

    public BookGenre(string title, string author,
                     double price, string genre)
        : base(title, author, price)
    {
        Genre = genre;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine("Жанр: " + Genre);
    }
}

sealed class BookGenrePubl : BookGenre
{
    public string Publisher { get; set; }

    public BookGenrePubl(string title, string author,
                         double price, string genre,
                         string publisher)
        : base(title, author, price, genre)
    {
        Publisher = publisher;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine("Видавець: " + Publisher);
    }
}

class Program
{
    static void Main()
    {
        Book book = new Book(
            "Кобзар", "Тарас Шевченко", 250);

        BookGenre bookGenre = new BookGenre(
            "Лісова пісня", "Леся Українка", 180, "Драма");

        BookGenrePubl bookPubl = new BookGenrePubl(
            "Тіні забутих предків",
            "Михайло Коцюбинський",
            200, "Повість", "Фоліо");

        Console.WriteLine("Книга:");
        book.Print();

        Console.WriteLine("\nКнига з жанром:");
        bookGenre.Print();

        Console.WriteLine("\nКнига з жанром і видавцем:");
        bookPubl.Print();
    }
}
