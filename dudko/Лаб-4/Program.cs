using System;

// ====================== Завдання 1 ======================
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

    public void SetName(string name) { this.name = name; }
    public void SetAge(int age) { this.age = age; }
    public void SetGender(string gender) { this.gender = gender; }
    public void SetPhone(string phone) { this.phone = phone; }

    public void Print()
    {
        Console.WriteLine("Ім'я: " + name);
        Console.WriteLine("Вік: " + age);
        Console.WriteLine("Стать: " + gender);
        Console.WriteLine("Телефон: " + phone);
    }
}

// ====================== Завдання 2 ======================
class Student
{
    public string LastName { get; set; }
    public int Course { get; set; }
    public string RecordBook { get; set; }

    public Student(string lastName, int course, string recordBook)
    {
        LastName = lastName;
        Course = course;
        RecordBook = recordBook;
    }

    public virtual void Print()
    {
        Console.WriteLine($"Студент: {LastName}, Курс: {Course}, Залікова: {RecordBook}");
    }
}

class Aspirant : Student
{
    public Aspirant(string lastName, int course, string recordBook)
        : base(lastName, course, recordBook)
    {
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine("(Аспірант)");
    }
}

// ====================== Завдання 3 ======================
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
        Console.WriteLine($"Назва: {Title}, Автор: {Author}, Ціна: {Price} грн");
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

    public override void Print()
    {
        base.Print();
        Console.WriteLine("Жанр: " + genre);
    }
}

sealed class BookGenrePubl : BookGenre
{
    private string publisher;

    public BookGenrePubl(string title, string author, double price, string genre, string publisher)
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
        Console.WriteLine("Видавництво: " + publisher);
    }
}

// ====================== Завдання 4 ======================
class Figure
{
    protected string name;

    public Figure(string name)
    {
        this.name = name;
    }

    public virtual void Display()
    {
        Console.WriteLine("Фігура: " + name);
    }
}

class Rectangle : Figure
{
    protected int x1, y1, x2, y2;

    public Rectangle(string name, int x1, int y1, int x2, int y2)
        : base(name)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }

    public Rectangle() : this("Rectangle", 0, 0, 1, 1)
    {
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Координати: ({x1};{y1}) і ({x2};{y2})");
    }

    public virtual int Area()
    {
        int width = Math.Abs(x2 - x1);
        int height = Math.Abs(y2 - y1);
        return width * height;
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

    public RectangleColor() : this("RectangleColor", 0, 0, 1, 1, "Red")
    {
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine("Колір: " + color);
    }

    public override int Area()
    {
        return base.Area();
    }
}

// ====================== Main ======================
class Program
{
    static void Main()
    {
        Console.WriteLine("=== Завдання 1 ===");
        Person p = new Person("Андрій", 25, "Чоловік", "+380123456789");
        p.Print();
        p.SetAge(26);
        p.SetPhone("+380987654321");
        Console.WriteLine("Після змін:");
        p.Print();

        Console.WriteLine("\n=== Завдання 2 ===");
        Student s = new Student("Петренко", 2, "AB123");
        Aspirant a = new Aspirant("Іванов", 3, "XY987");
        s.Print();
        a.Print();

        Console.WriteLine("\n=== Завдання 3 ===");
        BookGenrePubl b = new BookGenrePubl("Тіні забутих предків", "Коцюбинський", 300, "Роман", "А-БА-БА-ГА-ЛА-МА-ГА");
        b.Print();

        Console.WriteLine("\n=== Завдання 4 ===");
        Figure f;
        f = new Rectangle("Прямокутник", 0, 0, 4, 3);
        f.Display();

        RectangleColor rc = new RectangleColor("Кольоровий прямокутник", 1, 1, 5, 6, "Синій");
        Figure f2 = rc;
        f2.Display();
        Console.WriteLine("Площа: " + rc.Area());
    }
}
