using System;

// ЗАВДАННЯ 1. КЛАС PERSON

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
        Console.WriteLine("Ім'я: " + name);
        Console.WriteLine("Вік: " + age);
        Console.WriteLine("Стать: " + gender);
        Console.WriteLine("Телефон: " + phone);
    }
}


// ЗАВДАННЯ 2. STUDENT / ASPIRANT

class Student
{
    private string surname;
    private int course;
    private string recordBookNumber;

    public Student(string surname, int course, string recordBookNumber)
    {
        this.surname = surname;
        this.course = course;
        this.recordBookNumber = recordBookNumber;
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

    public string RecordBookNumber
    {
        get { return recordBookNumber; }
        set { recordBookNumber = value; }
    }

    public virtual void Print()
    {
        Console.WriteLine("Прізвище: " + surname);
        Console.WriteLine("Курс: " + course);
        Console.WriteLine("Номер залікової книжки: " + recordBookNumber);
    }
}

class Aspirant : Student
{
    private string dissertationTopic;

    public Aspirant(
        string surname,
        int course,
        string recordBookNumber,
        string dissertationTopic)
        : base(surname, course, recordBookNumber)
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
        Console.WriteLine("Тема дисертації: " + dissertationTopic);
    }
}


// ЗАВДАННЯ 3. BOOK

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
        Console.WriteLine("Назва книги: " + title);
        Console.WriteLine("Автор: " + author);
        Console.WriteLine("Вартість: " + price + " грн");
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

    public override void Print()
    {
        base.Print();
        Console.WriteLine("Видавець: " + publisher);
    }
}


// ЗАВДАННЯ 4. FIGURE

class Figure
{
    protected string name;

    public Figure(string name)
    {
        this.name = name;
    }

    public virtual void Display()
    {
        Console.WriteLine("Назва фігури: " + name);
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
        : this("Прямокутник", 0, 0, 1, 1)
    {
    }

    public override void Display()
    {
        base.Display();

        Console.WriteLine("Лівий верхній кут: (" + x1 + "; " + y1 + ")");
        Console.WriteLine("Правий нижній кут: (" + x2 + "; " + y2 + ")");
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
        : this("Кольоровий прямокутник", 0, 0, 1, 1, "Червоний")
    {
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine("Колір: " + color);
    }

    public override double Area()
    {
        return base.Area();
    }
}

// MAIN

class Program
{
    static void Main()
    {
        // ЗАВДАННЯ 1

        Console.WriteLine("ЗАВДАННЯ 1. PERSON");

        Person person = new Person(
            "Катерина",
            19,
            "жіноча",
            "+380986708111"
        );

        person.Print();

        Console.WriteLine("\nПісля зміни даних:");

        person.SetAge(20);
        person.SetPhone("+380501234567");

        person.Print();


        // ЗАВДАННЯ 2

        Console.WriteLine("ЗАВДАННЯ 2. STUDENT / ASPIRANT");

        Student student = new Student(
            "Демидчик",
            3,
            "КНІТ-44"
        );

        Console.WriteLine("\nСтудент:");
        student.Print();

        Aspirant aspirant = new Aspirant(
            "Тижук",
            5,
            "КНІТ-54",
            "Розробка програмного забезпечення"
        );

        Console.WriteLine("\nАспірант:");
        aspirant.Print();


        // ЗАВДАННЯ 3

        Console.WriteLine("ЗАВДАННЯ 3. BOOK");

        Book book = new Book(
            "Північ і південь",
            "Елізавет Гаскем",
            350
        );

        Console.WriteLine("\nКнига:");
        book.Print();

        BookGenre bookGenre = new BookGenre(
            "Гаррі Поттер",
            "Джоан Ролінґ",
            500,
            "Фентезі"
        );

        Console.WriteLine("\nКнига з жанром:");
        bookGenre.Print();

        BookGenrePubl bookGenrePubl = new BookGenrePubl(
            "Володар перснів",
            "Джон Толкін",
            650,
            "Фентезі",
            "А-БА-БА-ГА-ЛА-МА-ГА"
        );

        Console.WriteLine("\nКнига з жанром та видавцем:");
        bookGenrePubl.Print();

        // ЗАВДАННЯ 4
        Console.WriteLine("ЗАВДАННЯ 4. FIGURE");

        Rectangle rectangle = new Rectangle(
            "Прямокутник",
            0,
            0,
            5,
            3
        );

        RectangleColor rectangleColor = new RectangleColor(
            "Кольоровий прямокутник",
            0,
            0,
            4,
            2,
            "Синій"
        );

        // Посилання на базовий клас Figure
        Figure figure;

        Console.WriteLine("\nПрямокутник через посилання Figure:");

        figure = rectangle;
        figure.Display();

        Console.WriteLine("Площа: " + rectangle.Area());


        Console.WriteLine("\nКольоровий прямокутник через посилання Figure:");

        figure = rectangleColor;
        figure.Display();

        Console.WriteLine("Площа: " + rectangleColor.Area());


        // Демонстрація конструкторів без параметрів
        Console.WriteLine("\nПрямокутник за замовчуванням:");

        Rectangle defaultRectangle = new Rectangle();
        defaultRectangle.Display();
        Console.WriteLine("Площа: " + defaultRectangle.Area());


        Console.WriteLine("\nКольоровий прямокутник за замовчуванням:");

        RectangleColor defaultRectangleColor = new RectangleColor();
        defaultRectangleColor.Display();
        Console.WriteLine("Площа: " + defaultRectangleColor.Area());
    }
}