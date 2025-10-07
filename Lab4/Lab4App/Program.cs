using System;

namespace Lab4App
{
    // завдання 1 клас людини з основними характеристиками
class Person
{
    private string name; 
    private int age;
    private string gender;
    private string phoneNumber;

    // конструктор який створює обєкт людини і задає значення полів
    public Person(string name, int age, string gender, string phoneNumber)
    {
        this.name = name;
        this.age = age;
        this.gender = gender;
        this.phoneNumber = phoneNumber;
    }

    // методи для зміни окремих полів
    public void SetName(string name) => this.name = name;
    public void SetAge(int age) => this.age = age;
    public void SetGender(string gender) => this.gender = gender;
    public void SetPhone(string phone) => this.phoneNumber = phone;

    // метод для виведення інформації про людину
    public void Print()
    {
        Console.WriteLine($"Ім'я: {name}, Вік: {age}, Стать: {gender}, Телефон: {phoneNumber}");
    }
}

    // завдання 2 клас студент який містить основні дані про студента
class Student
{
    public string LastName { get; set; }
    public int Course { get; set; }
    public string RecordBook { get; set; }

    // конструктор який приймає дані при створенні
    public Student(string lastName, int course, string recordBook)
    {
        LastName = lastName;
        Course = course;
        RecordBook = recordBook;
    }

    // метод для виводу інформації про студента
    public virtual void Print()
    {
        Console.WriteLine($"Студент: {LastName}, Курс: {Course}, Залікова книга: {RecordBook}");
    }
}

    // клас аспірант який наслідує студент і має додаткове поле дисертація
class Aspirant : Student
{
    public string Dissertation { get; set; }

    // конструктор який викликає базовий конструктор і додає дисертацію
    public Aspirant(string lastName, int course, string recordBook, string dissertation)
        : base(lastName, course, recordBook)
    {
        Dissertation = dissertation;
    }

    // перевизначений метод виводу який показує ще і дисертацію
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Дисертація: {Dissertation}");
    }
}

    // завдання 3 клас книга який містить основні дані про книгу
class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public double Price { get; set; }

    // конструктор для створення книги
    public Book(string title, string author, double price)
    {
        Title = title;
        Author = author;
        Price = price;
    }

    // метод який виводить інформацію про книгу
    public virtual void Print()
    {
        Console.WriteLine($"Назва: {Title}, Автор: {Author}, Ціна: {Price} грн");
    }
}

    // клас книга з жанром наслідує від book і додає поле жанр
class BookGenre : Book
{
    public string Genre { get; set; }

    // конструктор який викликає базовий і додає жанр
    public BookGenre(string title, string author, double price, string genre)
        : base(title, author, price)
    {
        Genre = genre;
    }

    // перевизначення методу щоб виводити ще і жанр
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Жанр: {Genre}");
    }
}

    // sealed клас книга з видавництвом означає що від нього не можна наслідуватись
sealed class BookGenrePubl : BookGenre
{
    public string Publisher { get; set; }

    // конструктор який додає поле видавництво
    public BookGenrePubl(string title, string author, double price, string genre, string publisher)
        : base(title, author, price, genre)
    {
        Publisher = publisher;
    }

    // перевизначений метод щоб показувати ще і видавництво
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Видавництво: {Publisher}");
    }
}

    // завдання 4 клас фігура базовий клас для геометричних обєктів
class Figure
{
    public string Name { get; set; }

    // конструктор який задає імя фігури
    public Figure(string name)
    {
        Name = name;
    }

    // вивід назви фігури
    public virtual void Display()
    {
        Console.WriteLine($"Фігура: {Name}");
    }
}

    // клас прямокутник наслідує фігуру і додає координати
class Rectangle : Figure
{
    public int X1 { get; set; }
    public int Y1 { get; set; }
    public int X2 { get; set; }
    public int Y2 { get; set; }

    // конструктор який приймає координати
    public Rectangle(string name, int x1, int y1, int x2, int y2)
        : base(name)
    {
        X1 = x1;
        Y1 = y1;
        X2 = x2;
        Y2 = y2;
    }

    // конструктор за замовчуванням створює стандартний прямокутник
    public Rectangle() : this("Rectangle", 0, 0, 1, 1) { }

    // метод для показу координат прямокутника
    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Координати: ({X1},{Y1}), ({X2},{Y2})");
    }

    // метод для обчислення площі
    public virtual int Area()
    {
        return Math.Abs((X2 - X1) * (Y2 - Y1));
    }
}

    // клас кольоровий прямокутник наслідує rectangle і додає поле колір
class RectangleColor : Rectangle
{
    public string Color { get; set; }

    // конструктор який приймає колір і координати
    public RectangleColor(string name, int x1, int y1, int x2, int y2, string color)
        : base(name, x1, y1, x2, y2)
    {
        Color = color;
    }

    // конструктор за замовчуванням
    public RectangleColor() : this("RectangleColor", 0, 0, 1, 1, "Black") { }

    // метод для показу кольору
    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Колір: {Color}");
    }

    // метод площі не змінений просто викликає базовий
    public override int Area()
    {
        return base.Area();
    }
}

    // головний клас програми який тестує усі попередні класи
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine(" ++++++ Завдання 1: Person ++++++");
        Person p = new Person("Максим", 19, "чоловік", "380681926509");
        p.Print();
        p.SetAge(20);
        p.SetPhone("380501112233");
        Console.WriteLine("Після змін:");
        p.Print();

        Console.WriteLine("\n ++++++ Завдання 2: Student/Aspirant ++++++");
        Student st = new Student("Гілітуха", 2, "AB123");
        st.Print();
        Aspirant asp = new Aspirant("Кузьменко", 4, "CD456", "Мова програмування python");
        asp.Print();

        Console.WriteLine("\n++++++ Завдання 3: Book ++++++");
        Book b = new Book("Мистецтво війни", "Сунь-цзи", 377);
        b.Print();
        BookGenre bg = new BookGenre("1984", "Джордж Орвелл", 200, "Антиутопія");
        bg.Print();
        BookGenrePubl bgp = new BookGenrePubl("Кобзар", "Тарас Шевченко", 300, "Поезія", "Основи");
        bgp.Print();

        Console.WriteLine("\n++++++ Завдання 4: Figure/Rectangle ++++++");
        Figure f;

        f = new Rectangle("Прямокутник", 0, 0, 5, 3);
        f.Display();
        Console.WriteLine($"Площа: {(f as Rectangle).Area()}");

        f = new RectangleColor("Кольоровий прямокутник", 0, 0, 4, 2, "Жовтий");
        f.Display();
        Console.WriteLine($"Площа: {(f as RectangleColor).Area()}");
    }
}
}