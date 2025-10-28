class Person
{
    private string _name;
    private int _age;
    private string _gender;
    private string _phone;

    public Person(string name, int age, string gender, string phone)
    {
        _name = name;
        _age = age;
        _gender = gender;
        _phone = phone;
    }

    public void SetName(string name) => _name = name;
    public void SetAge(int age) => _age = age;
    public void SetGender(string gender) => _gender = gender;
    public void SetPhone(string phone) => _phone = phone;

    public void Print()
    {
        Console.WriteLine("Person:");
        Console.WriteLine("  Name: " + _name);
        Console.WriteLine("  Age: " + _age);
        Console.WriteLine("  Gender: " + _gender);
        Console.WriteLine("  Phone: " + _phone);
        Console.WriteLine();
    }
}

class Student
{
    private string _surname;
    private int _course;
    private string _recordBookNumber;

    public Student(string surname, int course, string recordBookNumber)
    {
        _surname = surname;
        _course = course;
        _recordBookNumber = recordBookNumber;
    }

    public string Surname
    {
        get => _surname;
        set => _surname = value;
    }

    public int Course
    {
        get => _course;
        set => _course = value;
    }

    public string RecordBookNumber
    {
        get => _recordBookNumber;
        set => _recordBookNumber = value;
    }

    public virtual void Print()
    {
        Console.WriteLine("Student:");
        Console.WriteLine("  Surname: " + Surname);
        Console.WriteLine("  Course: " + Course);
        Console.WriteLine("  Record Book N.: " + RecordBookNumber);
        Console.WriteLine();
    }
}

class Aspirant : Student
{
    private string _researchTopic;

    public Aspirant(string surname, int course, string recordBookNumber, string researchTopic)
        : base(surname, course, recordBookNumber)
    {
        _researchTopic = researchTopic;
    }

    public string ResearchTopic
    {
        get => _researchTopic;
        set => _researchTopic = value;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine("Aspirant:");
        Console.WriteLine("  Research topic: " + ResearchTopic);
        Console.WriteLine();
    }
}

class Book
{
    private string _title;
    private string _author;
    private decimal _price;

    public Book(string title, string author, decimal price)
    {
        _title = title;
        _author = author;
        _price = price;
    }

    public string Title
    {
        get => _title;
        set => _title = value;
    }

    public string Author
    {
        get => _author;
        set => _author = value;
    }

    public decimal Price
    {
        get => _price;
        set => _price = value;
    }

    public virtual void Print()
    {
        Console.WriteLine("Book:");
        Console.WriteLine("  Title: " + Title);
        Console.WriteLine("  Author: " + Author);
        Console.WriteLine("  Price: " + Price);
    }
}

class BookGenre : Book
{
    private string _genre;

    public BookGenre(string title, string author, decimal price, string genre)
        : base(title, author, price)
    {
        _genre = genre;
    }

    public string Genre
    {
        get => _genre;
        set => _genre = value;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine("  Genre: " + Genre);
    }
}

sealed class BookGenrePubl : BookGenre
{
    private string _publisher;

    public BookGenrePubl(string title, string author, decimal price, string genre, string publisher)
        : base(title, author, price, genre)
    {
        _publisher = publisher;
    }

    public string Publisher
    {
        get => _publisher;
        set => _publisher = value;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine("  Publisher: " + Publisher);
        Console.WriteLine();
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
        Console.WriteLine("Figure: " + name);
    }
}

class Rectangle : Figure
{
    public double X1 { get; private set; }
    public double Y1 { get; private set; }
    public double X2 { get; private set; }
    public double Y2 { get; private set; }

    public Rectangle(string name, double x1, double y1, double x2, double y2)
        : base(name)
    {
        X1 = x1;
        Y1 = y1;
        X2 = x2;
        Y2 = y2;
    }

    public Rectangle() : this("Rectangle", 0, 0, 1, 1) { }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"  Top-left: ({X1}, {Y1})");
        Console.WriteLine($"  Bottom-right: ({X2}, {Y2})");
    }

    public virtual double Area()
    {
        double width = Math.Abs(X2 - X1);
        double height = Math.Abs(Y2 - Y1);
        return width * height;
    }
}

class RectangleColor : Rectangle
{
    public string Color { get; set; }

    public RectangleColor(string name, double x1, double y1, double x2, double y2, string color)
        : base(name, x1, y1, x2, y2)
    {
        Color = color;
    }

    public RectangleColor() : this("RectangleColor", 0, 0, 1, 1, "White") { }

    public override void Display()
    {
        base.Display();
        Console.WriteLine("  Color: " + Color);
    }

    public override double Area() => base.Area();
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("1. Person");
        var p = new Person("Степан Олейніков", 30, "Чоловік", "+380661484122");
        p.Print();

        p.SetName("Іван Петренко");
        p.SetAge(31);
        p.SetPhone("+380501112244");
        p.Print();

        Console.WriteLine("2. Student / Aspirant");
        Student s = new Student("Шевченко", 3, "1111");
        s.Print();

        Aspirant a = new Aspirant("Коваленко", 5, "2211", "Математичні моделі");
        a.Print();

        Console.WriteLine("3. Book");
        BookGenrePubl bgp = new BookGenrePubl(
            "C#",
            "Іванов І.",
            299.99m,
            "Програмування",
            "Локальне видавництво");
        bgp.Print();

        Console.WriteLine("4. Figure / Rectangle");
        Figure fig;

        Rectangle rect = new Rectangle("Rect1", 0, 0, 3, 4);
        RectangleColor rectColor = new RectangleColor("RectColor1", 1, 1, 5, 6, "Блакитний");

        fig = rect;
        Console.WriteLine("Figure reference -> Rectangle:");
        fig.Display();
        if (fig is Rectangle r)
        {
            Console.WriteLine("  Area: " + r.Area());
        }
        Console.WriteLine();

        fig = rectColor;
        Console.WriteLine("Figure reference -> RectangleColor:");
        fig.Display();
        if (fig is Rectangle rc)
        {
            Console.WriteLine("  Area: " + rc.Area());
        }
    }
}
