using System;

class Person
{
    private string name;
    private int age;
    private string gender;
    private string phone;

    // Конструктор
    public Person(string name, int age, string gender, string phone)
    {
        this.name = name;
        this.age = age;
        this.gender = gender;
        this.phone = phone;
    }

    // Властивості get/set
    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }
    public string Gender { get => gender; set => gender = value; }
    public string Phone { get => phone; set => phone = value; }

    // Метод Print
    public void Print()
    {
        Console.WriteLine($"Person: {Name}, Age: {Age}, Gender: {Gender}, Phone: {Phone}");
    }
}


class Student
{
    public string Surname { get; set; }
    public int Course { get; set; }
    public string RecordBook { get; set; }

    public Student(string surname, int course, string recordBook)
    {
        Surname = surname;
        Course = course;
        RecordBook = recordBook;
    }

    public virtual void Print()
    {
        Console.WriteLine($"Student: {Surname}, Course: {Course}, RecordBook: {RecordBook}");
    }
}

class Aspirant : Student
{
    public string DissertationTopic { get; set; }

    public Aspirant(string surname, int course, string recordBook, string topic)
        : base(surname, course, recordBook)
    {
        DissertationTopic = topic;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Aspirant. Dissertation topic: {DissertationTopic}");
    }
}


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
        Console.WriteLine($"Book: {Title}, Author: {Author}, Price: {Price} UAH");
    }
}

class BookGenre : Book
{
    public string Genre { get; set; }

    public BookGenre(string title, string author, double price, string genre)
        : base(title, author, price)
    {
        Genre = genre;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Genre: {Genre}");
    }
}

sealed class BookGenrePubl : BookGenre
{
    public string Publisher { get; set; }

    public BookGenrePubl(string title, string author, double price, string genre, string publisher)
        : base(title, author, price, genre)
    {
        Publisher = publisher;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Publisher: {Publisher}");
    }
}


class Figure
{
    protected string name;

    public Figure(string name)
    {
        this.name = name;
    }

    public virtual void Display()
    {
        Console.WriteLine($"Figure: {name}");
    }
}

class Rectangle : Figure
{
    protected int x1, y1, x2, y2;

    public Rectangle(string name, int x1, int y1, int x2, int y2) : base(name)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }

    public Rectangle() : this("Rectangle", 0, 0, 1, 1) { }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Coordinates: ({x1},{y1}) - ({x2},{y2})");
    }

    public virtual int Area()
    {
        return Math.Abs((x2 - x1) * (y2 - y1));
    }
}

class RectangleColor : Rectangle
{
    private string color;

    public RectangleColor(string name, int x1, int y1, int x2, int y2, string color)
        : base(name, x1, y1, x2, y2)
    {
        this.color = color;
    }

    public RectangleColor() : this("RectangleColor", 0, 0, 1, 1, "red") { }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Color: {color}");
    }

    public override int Area()
    {
        return base.Area();
    }
}

class Demo
{
    static void Main()
    {
        // 1. Person
        Console.WriteLine("=== Person ===");
        Person p = new Person("Viktoriia", 20, "Female", "+380 000 0000");
        p.Print();
        p.Age = 26;
        p.Print();

        // 2. Student / Aspirant
        Console.WriteLine("\n=== Student & Aspirant ===");
        Student s = new Student("Lawrence", 3, "AB123");
        s.Print();
        Aspirant a = new Aspirant("Shmidt", 5, "XY789", "System Programming");
        a.Print();

        // 3. Books
        Console.WriteLine("\n=== Books ===");
        Book b = new Book("Shutter Island", "Dennis Lehane", 350);
        b.Print();
        BookGenre bg = new BookGenre("One Hundred Names", "Cecelia Ahern", 400, "Fiction");
        bg.Print();
        BookGenrePubl bgp = new BookGenrePubl("Given", "Natsuki Kizu", 240, "Manga", "ТАК");
        bgp.Print();

        // 4. Figures
        Console.WriteLine("\n=== Figures ===");
        Figure fRef;

        fRef = new Rectangle("MyRect", 2, 2, 6, 5);
        fRef.Display();
        Console.WriteLine($"Area = {(fRef as Rectangle).Area()}");

        fRef = new RectangleColor("ColoredRect", 0, 0, 4, 3, "blue");
        fRef.Display();
        Console.WriteLine($"Area = {(fRef as RectangleColor).Area()}");
    }
}
