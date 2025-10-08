using System;

#region Task 1: Person
class Person
{
    private string name;
    private int age;
    private string gender;
    private string phoneNumber;

    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }
    public string Gender { get => gender; set => gender = value; }
    public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

    public Person(string name, int age, string gender, string phoneNumber)
    {
        this.name = name;
        this.age = age;
        this.gender = gender;
        this.phoneNumber = phoneNumber;
    }

    public void Print()
    {
        Console.WriteLine($"Name: {name}, Age: {age}, Gender: {gender}, Phone: {phoneNumber}");
    }
}
#endregion

#region Task 2: Student and Aspirant
class Student
{
    private string surname;
    private int course;
    private string recordBookNumber;

    public string Surname { get => surname; set => surname = value; }
    public int Course { get => course; set => course = value; }
    public string RecordBookNumber { get => recordBookNumber; set => recordBookNumber = value; }

    public Student(string surname, int course, string recordBookNumber)
    {
        this.surname = surname;
        this.course = course;
        this.recordBookNumber = recordBookNumber;
    }

    public virtual void Print()
    {
        Console.WriteLine($"Surname: {surname}, Course: {course}, Record Book: {recordBookNumber}");
    }
}

class Aspirant : Student
{
    public Aspirant(string surname, int course, string recordBookNumber)
        : base(surname, course, recordBookNumber) { }

    public override void Print()
    {
        base.Print();
        Console.WriteLine("This is an Aspirant.");
    }
}
#endregion

#region Task 3: Book, BookGenre, BookGenrePubl
class Book
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

class BookGenre : Book
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

sealed class BookGenrePubl : BookGenre
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
#endregion

#region Task 4: Figure, Rectangle, RectangleColor
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

    public Rectangle(int x1, int y1, int x2, int y2, string name)
        : base(name)
    {
        this.x1 = x1; this.y1 = y1; this.x2 = x2; this.y2 = y2;
    }

    public Rectangle() : this(0, 0, 1, 1, "Rectangle") { }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Coordinates: ({x1},{y1}) to ({x2},{y2})");
    }

    public int Area()
    {
        return (x2 - x1) * (y2 - y1);
    }
}

class RectangleColor : Rectangle
{
    private string color;

    public RectangleColor(int x1, int y1, int x2, int y2, string name, string color)
        : base(x1, y1, x2, y2, name)
    {
        this.color = color;
    }

    public RectangleColor() : this(0, 0, 1, 1, "Colored Rectangle", "Red") { }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Color: {color}");
    }

    public new int Area()
    {
        return base.Area();
    }
}
#endregion

class Program
{
    static void Main()
    {
        // === Task 1: Person ===
        Person p = new Person("Alice", 25, "Female", "+380501234567");
        p.Print();
        Console.WriteLine();

        // === Task 2: Student and Aspirant ===
        Student s = new Student("Ivanov", 2, "RB12345");
        s.Print();
        Aspirant a = new Aspirant("Petrov", 3, "RB54321");
        a.Print();
        Console.WriteLine();

        // === Task 3: Book hierarchy ===
        Book b = new Book("War and Peace", "Tolstoy L.", 20.5);
        b.Print();
        BookGenre bg = new BookGenre("1984", "Orwell G.", 15.0, "Dystopia");
        bg.Print();
        BookGenrePubl bgp = new BookGenrePubl("Harry Potter", "Rowling J.", 25.0, "Fantasy", "Bloomsbury");
        bgp.Print();
        Console.WriteLine();

        // === Task 4: Figure hierarchy ===
        Figure f = new Figure("Generic Figure");
        f.Display();
        Console.WriteLine();

        Figure rect = new Rectangle(0, 0, 4, 5, "My Rectangle");
        rect.Display();
        Console.WriteLine($"Area: {(rect as Rectangle).Area()}");
        Console.WriteLine();

        Figure coloredRect = new RectangleColor(1, 1, 6, 7, "My Colored Rectangle", "Blue");
        coloredRect.Display();
        Console.WriteLine($"Area: {(coloredRect as RectangleColor).Area()}");
    }
}
