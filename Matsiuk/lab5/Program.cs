using System;

// =========================
// Task 1. Person
// =========================

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

    public void SetName(string name)
    {
        this.name = name;
    }

    public void SetAge(int age)
    {
        this.age = age;
    }

    public void SetGender(string gender)
    {
        this.gender = gender;
    }

    public void SetPhone(string phone)
    {
        this.phone = phone;
    }

    public void Print()
    {
        Console.WriteLine("Person information:");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Gender: {gender}");
        Console.WriteLine($"Phone: {phone}");
    }
}


// =========================
// Task 2. Student / Aspirant
// =========================

class Student
{
    private string surname;
    private int course;
    private string studentBookNumber;

    public Student(string surname, int course, string studentBookNumber)
    {
        this.surname = surname;
        this.course = course;
        this.studentBookNumber = studentBookNumber;
    }

    public string Surname
    {
        get { return surname; }
        set { surname = value; }
    }

    public int Course
    {
        get { return course; }
        set { course = value; }
    }

    public string StudentBookNumber
    {
        get { return studentBookNumber; }
        set { studentBookNumber = value; }
    }

    public virtual void Print()
    {
        Console.WriteLine("Student information:");
        Console.WriteLine($"Surname: {surname}");
        Console.WriteLine($"Course: {course}");
        Console.WriteLine($"Student book number: {studentBookNumber}");
    }
}

class Aspirant : Student
{
    private string dissertationTopic;

    public Aspirant(
        string surname,
        int course,
        string studentBookNumber,
        string dissertationTopic)
        : base(surname, course, studentBookNumber)
    {
        this.dissertationTopic = dissertationTopic;
    }

    public string DissertationTopic
    {
        get { return dissertationTopic; }
        set { dissertationTopic = value; }
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Dissertation topic: {dissertationTopic}");
    }
}


// =========================
// Task 3. Book hierarchy
// =========================

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

    public virtual void Print()
    {
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Author: {author}");
        Console.WriteLine($"Price: {price:F2}");
    }
}

class BookGenre : Book
{
    private string genre;

    public BookGenre(
        string title,
        string author,
        double price,
        string genre)
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
        Console.WriteLine($"Genre: {genre}");
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

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Publisher: {publisher}");
    }
}


// =========================
// Task 4. Figure hierarchy
// =========================

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
    protected double x1;
    protected double y1;
    protected double x2;
    protected double y2;

    public Rectangle(
        string name,
        double x1,
        double y1,
        double x2,
        double y2)
        : base(name)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }

    public Rectangle()
        : this("Rectangle", 0, 0, 1, 1)
    {
    }

    public override void Display()
    {
        base.Display();

        Console.WriteLine($"Top-left corner: ({x1}; {y1})");
        Console.WriteLine($"Bottom-right corner: ({x2}; {y2})");
    }

    public virtual double Area()
    {
        double width = Math.Abs(x2 - x1);
        double height = Math.Abs(y2 - y1);

        return width * height;
    }
}

class RectangleColor : Rectangle
{
    private string color;

    public RectangleColor(
        string name,
        double x1,
        double y1,
        double x2,
        double y2,
        string color)
        : base(name, x1, y1, x2, y2)
    {
        this.color = color;
    }

    public RectangleColor()
        : this("Colored Rectangle", 0, 0, 1, 1, "Red")
    {
    }

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Color: {color}");
    }

    public override double Area()
    {
        return base.Area();
    }
}


// =========================
// Main
// =========================

class Program
{
    static void Main()
    {
        // =========================
        // Task 1
        // =========================

        Console.WriteLine("========== TASK 1 ==========");

        Person person = new Person(
            "John Smith",
            20,
            "Male",
            "+380991234567"
        );

        person.Print();

        Console.WriteLine("\nChanging person data...");

        person.SetAge(21);
        person.SetPhone("+380671112233");

        person.Print();


        // =========================
        // Task 2
        // =========================

        Console.WriteLine("\n========== TASK 2 ==========");

        Student student = new Student(
            "Johnson",
            3,
            "ST12345"
        );

        student.Print();

        Console.WriteLine();

        Aspirant aspirant = new Aspirant(
            "Brown",
            5,
            "AS54321",
            "Artificial Intelligence in Information Systems"
        );

        aspirant.Print();


        // =========================
        // Task 3
        // =========================

        Console.WriteLine("\n========== TASK 3 ==========");

        Book book = new Book(
            "The Great Adventure",
            "Michael Brown",
            450.50
        );

        book.Print();

        Console.WriteLine();

        BookGenre bookGenre = new BookGenre(
            "The Great Adventure",
            "Michael Brown",
            450.50,
            "Adventure"
        );

        bookGenre.Print();

        Console.WriteLine();

        BookGenrePubl bookGenrePubl = new BookGenrePubl(
            "The Great Adventure",
            "Michael Brown",
            450.50,
            "Adventure",
            "Modern Books"
        );

        bookGenrePubl.Print();


        // =========================
        // Task 4
        // =========================

        Console.WriteLine("\n========== TASK 4 ==========");

        Figure figure;

        Rectangle rectangle = new Rectangle(
            "Rectangle",
            0,
            0,
            5,
            3
        );

        RectangleColor rectangleColor = new RectangleColor(
            "Colored Rectangle",
            0,
            0,
            4,
            2,
            "Blue"
        );

        figure = rectangle;

        Console.WriteLine("Rectangle through Figure reference:");
        figure.Display();

        Console.WriteLine($"Area: {rectangle.Area()}");

        Console.WriteLine();

        figure = rectangleColor;

        Console.WriteLine("RectangleColor through Figure reference:");
        figure.Display();

        Console.WriteLine($"Area: {rectangleColor.Area()}");
    }
}