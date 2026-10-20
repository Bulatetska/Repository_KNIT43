using System;

// ЗАВДАННЯ 1. КЛАС PERSON
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string PhoneNumber { get; set; }

    public Person(string name, int age, string gender, string phoneNumber)
    {
        Name = name;
        Age = age;
        Gender = gender;
        PhoneNumber = phoneNumber;
    }

    // Методи для зміни окремих полів
    public void SetName(string name)
    {
        Name = name;
    }

    public void SetAge(int age)
    {
        Age = age;
    }

    public void SetGender(string gender)
    {
        Gender = gender;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }

    public void Print()
    {
        Console.WriteLine($"Ім'я: {Name}");
        Console.WriteLine($"Вік: {Age}");
        Console.WriteLine($"Стать: {Gender}");
        Console.WriteLine($"Телефон: {PhoneNumber}");
    }
}

// ЗАВДАННЯ 2. КЛАСИ STUDENT ТА ASPIRANT
public class Student
{
    public string LastName { get; set; }
    public int Course { get; set; }
    public string RecordBookNumber { get; set; }

    public Student(string lastName, int course, string recordBookNumber)
    {
        LastName = lastName;
        Course = course;
        RecordBookNumber = recordBookNumber;
    }

    public void Print()
    {
        Console.WriteLine($"Прізвище: {LastName}");
        Console.WriteLine($"Курс навчання: {Course}");
        Console.WriteLine($"Номер залікової книжки: {RecordBookNumber}");
    }
}

public class Aspirant : Student
{
    public string DissertationTopic { get; set; }

    public Aspirant(
        string lastName,
        int course,
        string recordBookNumber,
        string dissertationTopic)
        : base(lastName, course, recordBookNumber)
    {
        DissertationTopic = dissertationTopic;
    }

    public void Print()
    {
        base.Print();

        Console.WriteLine($"Тема дисертації: {DissertationTopic}");
    }
}

// ЗАВДАННЯ 3. КЛАСИ BOOK, BOOKGENRE,
// BOOKGENREPUBL
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }

    public Book(string title, string author, decimal price)
    {
        Title = title;
        Author = author;
        Price = price;
    }

    public void Print()
    {
        Console.WriteLine($"Назва книги: {Title}");
        Console.WriteLine($"Автор: {Author}");
        Console.WriteLine($"Вартість: {Price:F2} грн");
    }
}

public class BookGenre : Book
{
    public string Genre { get; set; }

    public BookGenre(
        string title,
        string author,
        decimal price,
        string genre)
        : base(title, author, price)
    {
        Genre = genre;
    }

    public void Print()
    {
        base.Print();

        Console.WriteLine($"Жанр: {Genre}");
    }
}

//sealed забороняє успадкування від цього класу
public sealed class BookGenrePubl : BookGenre
{
    public string Publisher { get; set; }

    public BookGenrePubl(
        string title,
        string author,
        decimal price,
        string genre,
        string publisher)
        : base(title, author, price, genre)
    {
        Publisher = publisher;
    }

    public void Print()
    {
        base.Print();

        Console.WriteLine($"Видавництво: {Publisher}");
    }
}

// ЗАВДАННЯ 4. КЛАСИ FIGURE, RECTANGLE,
// RECTANGLECOLOR
public class Figure
{
    public string Name { get; set; }

    public Figure(string name)
    {
        Name = name;
    }

    public virtual void Display()
    {
        Console.WriteLine($"Назва фігури: {Name}");
    }
}

public class Rectangle : Figure
{
    public double X1 { get; set; }
    public double Y1 { get; set; }
    public double X2 { get; set; }
    public double Y2 { get; set; }

    public Rectangle(
        string name,
        double x1,
        double y1,
        double x2,
        double y2)
        : base(name)
    {
        X1 = x1;
        Y1 = y1;
        X2 = x2;
        Y2 = y2;
    }

    //Конструктор без параметрів
    public Rectangle()
        : this("Прямокутник", 0, 0, 1, 1)
    {
    }

    public override void Display()
    {
        base.Display();

        Console.WriteLine($"Лівий верхній кут: ({X1}; {Y1})");
        Console.WriteLine($"Правий нижній кут: ({X2}; {Y2})");
    }

    public double Area()
    {
        return Math.Abs(X2 - X1) * Math.Abs(Y2 - Y1);
    }
}

public class RectangleColor : Rectangle
{
    public string Color { get; set; }

    public RectangleColor(
        string name,
        double x1,
        double y1,
        double x2,
        double y2,
        string color)
        : base(name, x1, y1, x2, y2)
    {
        Color = color;
    }

    // Конструктор без параметрів
    public RectangleColor()
        : this("Кольоровий прямокутник", 0, 0, 1, 1, "Червоний")
    {
    }

    public override void Display()
    {
        base.Display();

        Console.WriteLine($"Колір: {Color}");
    }

    public double Area()
    {
        return base.Area();
    }
}




class Program
{
    static void Main()
    {
        // ЗАВДАННЯ 1
        Console.WriteLine("==================================");
        Console.WriteLine("ЗАВДАННЯ 1. КЛАС PERSON");
        Console.WriteLine("==================================");

        Person person = new Person(
            "Андрій",
            20,
            "Чоловіча",
            "+380991234567"
        );

        person.Print();

        Console.WriteLine("\nЗміна віку та телефону:");

        person.SetAge(21);
        person.SetPhoneNumber("+380671112233");

        person.Print();



        // ЗАВДАННЯ 2
        Console.WriteLine("\n==================================");
        Console.WriteLine("ЗАВДАННЯ 2. STUDENT ТА ASPIRANT");
        Console.WriteLine("==================================");

        Student student = new Student(
            "Петренко",
            3,
            "KN-12345"
        );

        Console.WriteLine("\nІнформація про студента:");
        student.Print();

        Aspirant aspirant = new Aspirant(
            "Іваненко",
            5,
            "AS-54321",
            "Методи штучного інтелекту"
        );

        Console.WriteLine("\nІнформація про аспіранта:");
        aspirant.Print();



        // ЗАВДАННЯ 3
        Console.WriteLine("\n==================================");
        Console.WriteLine("ЗАВДАННЯ 3. BOOK");
        Console.WriteLine("==================================");

        Book book = new Book(
            "Основи програмування",
            "Іван Петренко",
            350.50m
        );

        Console.WriteLine("\nІнформація про книгу:");
        book.Print();

        BookGenre bookGenre = new BookGenre(
            "Таємниці Всесвіту",
            "Олена Коваль",
            420.00m,
            "Науково-популярна література"
        );

        Console.WriteLine("\nІнформація про книгу з жанром:");
        bookGenre.Print();

        BookGenrePubl bookGenrePubl = new BookGenrePubl(
            "Пригоди мандрівника",
            "Максим Шевченко",
            275.90m,
            "Пригоди",
            "Видавництво Світ"
        );

        Console.WriteLine("\nКнига з жанром і видавництвом:");
        bookGenrePubl.Print();

        //ЗАВДАННЯ 4
        Console.WriteLine("\n==================================");
        Console.WriteLine("ЗАВДАННЯ 4. ГЕОМЕТРИЧНІ ФІГУРИ");
        Console.WriteLine("==================================");

        //Посилання на базовий клас
        Figure figure;


        Rectangle rectangle = new Rectangle(
            "Прямокутник",
            2,
            3,
            8,
            7
        );

        figure = rectangle;

        Console.WriteLine("\nЗвичайний прямокутник:");
        figure.Display();

        if (figure is Rectangle r)
        {
            Console.WriteLine($"Площа: {r.Area()}");
        }


        RectangleColor rectangleColor = new RectangleColor(
            "Кольоровий прямокутник",
            1,
            1,
            5,
            4,
            "Синій"
        );

        figure = rectangleColor;

        Console.WriteLine("\nКольоровий прямокутник:");
        figure.Display();

        if (figure is RectangleColor rc)
        {
            Console.WriteLine($"Площа: {rc.Area()}");
        }

        //Демонстрація конструкторів без параметрів
        Console.WriteLine("\nПрямокутник за замовчуванням:");
        Rectangle defaultRectangle = new Rectangle();
        defaultRectangle.Display();
        Console.WriteLine($"Площа: {defaultRectangle.Area()}");

        Console.WriteLine("\nКольоровий прямокутник за замовчуванням:");
        RectangleColor defaultColorRectangle = new RectangleColor();
        defaultColorRectangle.Display();
        Console.WriteLine($"Площа: {defaultColorRectangle.Area()}");

        Console.WriteLine("\nУсі завдання виконано.");
    }
}