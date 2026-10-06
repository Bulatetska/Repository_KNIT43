using System;

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
        Console.WriteLine($"Ім'я: {name} | Вік: {age} | Стать: {gender} | Телефон: {phone}");
    }
}

class Student
{
    private string lastName;
    private int course;
    private string recordBookNumber;

    public Student(string lastName, int course, string recordBookNumber)
    {
        this.lastName = lastName;
        this.course = course;
        this.recordBookNumber = recordBookNumber;
    }

    public string LastName { get => lastName; set => lastName = value; }
    public int Course { get => course; set => course = value; }
    public string RecordBookNumber { get => recordBookNumber; set => recordBookNumber = value; }

    public virtual void Print()
    {
        Console.WriteLine($"Студент: {lastName}, Курс: {course}, Залікова книжка: {recordBookNumber}");
    }
}

class Aspirant : Student
{
    private string dissertationTopic;

    public Aspirant(string lastName, int course, string recordBookNumber, string dissertationTopic)
        : base(lastName, course, recordBookNumber)
    {
        this.dissertationTopic = dissertationTopic;
    }

    public string DissertationTopic { get => dissertationTopic; set => dissertationTopic = value; }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"  -> Тема дисертації: {dissertationTopic}");
    }
}

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

    public string Title { get => title; set => title = value; }
    public string Author { get => author; set => author = value; }
    public double Price { get => price; set => price = value; }

    public virtual void Print()
    {
        Console.WriteLine($"Книга: \"{title}\", Автор: {author}, Вартість: {price:F2} грн");
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

    public string Genre { get => genre; set => genre = value; }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"  Жанр: {genre}");
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

    public string Publisher { get => publisher; set => publisher = value; }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"  Видавництво: {publisher}");
    }
}

class Figure
{
    protected string name;

    public Figure(string name) { this.name = name; }

    public virtual void Display()
    {
        Console.WriteLine($"Назва фігури: {name}");
    }
}

class Rectangle : Figure
{
    protected double x1, y1, x2, y2;

    public Rectangle(string name, double x1, double y1, double x2, double y2) : base(name)
    {
        this.x1 = x1; this.y1 = y1; this.x2 = x2; this.y2 = y2;
    }

    public Rectangle() : this("Прямокутник", 0, 0, 1, 1) { }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Координати: ({x1}; {y1}) - ({x2}; {y2})");
    }

    public virtual double Area()
    {
        return Math.Abs(x1 - x2) * Math.Abs(y1 - y2);
    }
}

class RectangleColor : Rectangle
{
    protected string color;

    public RectangleColor(string name, double x1, double y1, double x2, double y2, string color)
        : base(name, x1, y1, x2, y2)
    {
        this.color = color;
    }

    public RectangleColor() : this("Кольоровий прямокутник", 0, 0, 1, 1, "Білий") { }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Колір: {color}");
    }

    public override double Area() => base.Area();
}
class Task5_1
{
    public static void Run()
    {
        Console.WriteLine("ЗАВДАННЯ 1: Person");
        Person p = new Person("Олена", 20, "Жіноча", "+380501112233");
        p.Print();
        p.SetAge(21);
        p.Print();

        Console.WriteLine("\nЗАВДАННЯ 2: Student & Aspirant");
        Student st = new Student("Коваленко", 3, "КВ-102938");
        st.Print();
        Aspirant asp = new Aspirant("Шевченко", 1, "АС-992100", "Дослідження алгоритмів маршрутизації");
        asp.Print();

        Console.WriteLine("\nЗАВДАННЯ 3: Книги (sealed)");
        BookGenrePubl book = new BookGenrePubl("Кобзар", "Тарас Шевченко", 350.0, "Поезія", "А-ба-ба-га-ла-ма-га");
        book.Print();

        Console.WriteLine("\nЗАВДАННЯ 4: Поліморфізм фігур");
        Figure refFigure;
        Rectangle rect = new Rectangle("Прямокутник 1", 1, 2, 5, -4);
        RectangleColor rectColor = new RectangleColor("Синій прямокутник", 0, 5, 4, 1, "Синій");

        refFigure = rect;
        refFigure.Display();
        Console.WriteLine($"Площа: {rect.Area():F2}\n");

        refFigure = rectColor;
        refFigure.Display();
        Console.WriteLine($"Площа: {rectColor.Area():F2}");
    }
}
