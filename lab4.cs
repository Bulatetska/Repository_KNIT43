using System;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string Phone { get; set; }

    public void Print()
    {
        Console.WriteLine($"Ім'я: {Name}, Вік: {Age}, Стать: {Gender}, Телефон: {Phone}");
    }
}

class Student
{
    public string LastName { get; set; }
    public int Course { get; set; }
    public string GradeBookNumber { get; set; }

    public Student(string lastName, int course, string gradeBookNumber)
    {
        LastName = lastName;
        Course = course;
        GradeBookNumber = gradeBookNumber;
    }

    public virtual void Print() =>
        Console.WriteLine($"Студент: {LastName}, Курс: {Course}, № залікової: {GradeBookNumber}");
}

class Aspirant : Student
{
    public string DissertationTopic { get; set; }

    public Aspirant(string lastName, int course, string gradeBookNumber, string dissertationTopic)
        : base(lastName, course, gradeBookNumber)
    {
        DissertationTopic = dissertationTopic;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Тема дисертації: {DissertationTopic}");
    }
}

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public double Price { get; set; }

    public Book(string title, string author, double price) =>
        (Title, Author, Price) = (title, author, price);

    public virtual void Print() =>
        Console.WriteLine($"Книга: \"{Title}\", Автор: {Author}, Ціна: {Price} грн");
}

class BookGenre : Book
{
    public string Genre { get; set; }

    public BookGenre(string title, string author, double price, string genre)
        : base(title, author, price) => Genre = genre;

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Жанр: {Genre}");
    }
}

sealed class BookGenrePubl : BookGenre
{
    public string Publisher { get; set; }

    public BookGenrePubl(string title, string author, double price, string genre, string publisher)
        : base(title, author, price, genre) => Publisher = publisher;

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Видавництво: {Publisher}");
    }
}

class Figure
{
    protected string Name;
    public Figure(string name) => Name = name;

    public virtual void Display() => Console.WriteLine($"Фігура: {Name}");
}

class Rectangle : Figure
{
    protected int x1, y1, x2, y2;

    public Rectangle(string name, int x1, int y1, int x2, int y2)
        : base(name) => (this.x1, this.y1, this.x2, this.y2) = (x1, y1, x2, y2);

    public Rectangle() : this("Прямокутник", 0, 0, 1, 1) { }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Координати: ({x1},{y1}) - ({x2},{y2})");
    }

    public virtual int Area() => Math.Abs((x2 - x1) * (y2 - y1));
}

class RectangleColor : Rectangle
{
    private string color;

    public RectangleColor(string name, int x1, int y1, int x2, int y2, string color)
        : base(name, x1, y1, x2, y2) => this.color = color;

    public RectangleColor() : this("Кольоровий прямокутник", 0, 0, 1, 1, "Чорний") { }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Колір: {color}");
    }

    public override int Area() => base.Area();
}

class Program
{
    static void Main()
    {
        // 1
        Person p = new Person { Name = "Влад", Age = 20, Gender = "Чоловік", Phone = "0994298539" };
        p.Print();
        Console.WriteLine();

        // 2
        Student s = new Student("Петренко", 3, "12345");
        Aspirant a = new Aspirant("Шевченко", 5, "98765", "Штучний інтелект");
        s.Print();
        a.Print();
        Console.WriteLine();

        // 3
        BookGenrePubl b = new BookGenrePubl("Відьмак", "Анджей Сапковский", 320, "Фентезі", "КСД");
        b.Print();
        Console.WriteLine();

        // 4
        Figure fig = new Rectangle("Прямокутник 1", 0, 0, 5, 5);
        fig.Display();
        Console.WriteLine($"Площа: {(fig as Rectangle).Area()}");
        Console.WriteLine();

        fig = new RectangleColor("Прямокутник 2", 1, 1, 4, 6, "Червоний");
        fig.Display();
        Console.WriteLine($"Площа: {(fig as Rectangle).Area()}");
    }
}