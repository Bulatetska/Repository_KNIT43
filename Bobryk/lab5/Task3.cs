using System;

class Book
{
    private string title;
    private string author;
    private double price;

    public Book(string title, string author, double price)
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

    public double Price
    {
        get { return price; }
        set { price = value; }
    }

    public void Print()
    {
        Console.WriteLine("Назва: " + title);
        Console.WriteLine("Автор: " + author);
        Console.WriteLine("Ціна: " + price + " грн");
    }
}


class BookGenre : Book
{
    private string genre;

    public BookGenre(string title, string author, double price, string genre)
        : base(title, author, price)
    {
        this.genre = genre;
    }

    public string Genre
    {
        get { return genre; }
        set { genre = value; }
    }

    public new void Print()
    {
        base.Print();
        Console.WriteLine("Жанр: " + genre);
    }
}


sealed class BookGenrePubl : BookGenre
{
    private string publisher;

    public BookGenrePubl(
        string title,
        string author,
        double price,
        string genre,
        string publisher)
        : base(title, author, price, genre)
    {
        this.publisher = publisher;
    }

    public string Publisher
    {
        get { return publisher; }
        set { publisher = value; }
    }

    public new void Print()
    {
        base.Print();
        Console.WriteLine("Видавець: " + publisher);
    }
}


class Program
{
    static void Main()
    {
        Book book = new Book(
            "Кобзар",
            "Тарас Шевченко",
            300
        );

        BookGenre bookGenre = new BookGenre(
            "1234",
            "Джордж Орвелл",
            350,
            "якийсь там"
        );

        BookGenrePubl bookGenrePubl = new BookGenrePubl(
            "Гаррі Поттер",
            "Джоан Роулінг",
            450,
            "Фентезі",
            "абабагаламага"
        );

        Console.WriteLine("Книга:");
        book.Print();

        Console.WriteLine("\nКнига з жанром:");
        bookGenre.Print();

        Console.WriteLine("\nКнига з жанром і видавцем:");
        bookGenrePubl.Print();
    }
}