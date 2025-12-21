using System;

// Завдання 1
class Person
{
    private string name;
    private int age;
    private string gender;
    private string phone;

    public Person(string name, int age, string gender, string phone)
    {
        this.name = name;
        this.age = age;
        this.gender = gender;
        this.phone = phone;
    }

    public void SetName(string name) => this.name = name;
    public void SetAge(int age) => this.age = age;
    public void SetGender(string gender) => this.gender = gender;
    public void SetPhone(string phone) => this.phone = phone;

    public void Print()
    {
        Console.WriteLine($"Name: {name}, Age: {age}, Gender: {gender}, Phone: {phone}");
    }
}

// Завдання 2
class Student
{
    public string LastName { get; set; }
    public int Course { get; set; }
    public string RecordBookID { get; set; }

    public Student(string lastName, int course, string recordBookID)
    {
        LastName = lastName;
        Course = course;
        RecordBookID = recordBookID;
    }

    public virtual void Print()
    {
        Console.WriteLine($"Student: {LastName}, Course: {Course}, Record Book: {RecordBookID}");
    }
}

class Aspirant : Student
{
    public string DissertationTopic { get; set; }

    public Aspirant(string lastName, int course, string recordBookID, string dissertation)
        : base(lastName, course, recordBookID)
    {
        DissertationTopic = dissertation;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Dissertation: {DissertationTopic}");
    }
}

// Завдання 3 
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
        Console.WriteLine($"Book: {Title}, Author: {Author}, Price: {Price}");
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

// Завдання 4
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
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }

    public Rectangle() : this(0, 0, 1, 1, "Rectangle") { }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Coordinates: ({x1},{y1}), ({x2},{y2})");
    }

    public virtual int Area()
    {
        return Math.Abs((x2 - x1) * (y2 - y1));
    }
}

class RectangleColor : Rectangle
{
    public string Color { get; set; }

    public RectangleColor(int x1, int y1, int x2, int y2, string name, string color)
        : base(x1, y1, x2, y2, name)
    {
        Color = color;
    }

    public RectangleColor() : this(0, 0, 1, 1, "RectangleColor", "White") { }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Color: {Color}");
    }

    public override int Area()
    {
        return base.Area();
    }
}


class Program
{
    static void Main()
    {
        Figure fig;


        Rectangle rect = new Rectangle(3, 3, 5, 5, "MyRectangle");
        RectangleColor rectColor = new RectangleColor(0, 0, 3, 3, "MyColoredRectangle", "Red");


        fig = rect;
        fig.Display();
        Console.WriteLine($"Area: {rect.Area()}");
        


        fig = rectColor;
        fig.Display();
        Console.WriteLine($"Area: {rectColor.Area()}");
    }
}
