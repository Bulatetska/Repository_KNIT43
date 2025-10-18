using System;

namespace MyApp
{
    // Завдання 1
    public class Person
    {
        public string name;
        public int age;
        public string gender;
        public string phoneNumber;

        public Person(string name, int age, string gender, string phoneNumber)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.phoneNumber = phoneNumber;
        }

        public void SetName(string name) => this.name = name;
        public void SetAge(int age) => this.age = age;
        public void SetGender(string gender) => this.gender = gender;
        public void SetPhone(string phone) => this.phoneNumber = phone;

        public void Print()
        {
            Console.WriteLine($"Ім'я: {name}, Вік: {age}, Стать: {gender}, Телефон: {phoneNumber}");
        }
    }

    //Завдання 2
    public class Student
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
            Console.WriteLine($"Студент: {LastName}, Курс: {Course}, Залікова книга: {RecordBook}");
        }
    }

    public class Aspirant : Student
    {
        public string Dissertation { get; set; }

        public Aspirant(string lastName, int course, string recordBook, string dissertation)
            : base(lastName, course, recordBook)
        {
            Dissertation = dissertation;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Дисертація: {Dissertation}");
        }
    }

    // Завдання 3
    public class Book
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

    public class BookGenre : Book
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
            Console.WriteLine($"Жанр: {Genre}");
        }
    }

    public sealed class BookGenrePubl : BookGenre
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
            Console.WriteLine($"Видавництво: {Publisher}");
        }
    }

    // Завдання 4
    public class Figure
    {
        public string Name { get; set; }

        public Figure(string name)
        {
            Name = name;
        }

        public virtual void Display()
        {
            Console.WriteLine($"Фігура: {Name}");
        }
    }

    public class Rectangle : Figure
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }

        public Rectangle(string name, int x1, int y1, int x2, int y2)
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
            Console.WriteLine($"Координати: ({X1},{Y1}), ({X2},{Y2})");
        }

        public virtual int Area()
        {
            return Math.Abs((X2 - X1) * (Y2 - Y1));
        }
    }

    public class RectangleColor : Rectangle
    {
        public string Color { get; set; }

        public RectangleColor(string name, int x1, int y1, int x2, int y2, string color)
            : base(name, x1, y1, x2, y2)
        {
            Color = color;
        }

        public RectangleColor() : this("RectangleColor", 0, 0, 1, 1, "Black") { }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Колір: {Color}");
        }

        public override int Area()
        {
            return base.Area();
        }
    }
}

/*class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== Завдання 1: Person ===");
        Person p = new Person("Микита", 19, "чоловік", "380671234447");
        p.Print();
        p.SetAge(26);
        p.SetPhone("380501112233");
        Console.WriteLine("Після змін:");
        p.Print();

        Console.WriteLine("\n=== Завдання 2: Student/Aspirant ===");
        Student st = new Student("Петренко", 2, "AB123");
        st.Print();
        Aspirant asp = new Aspirant("Бойко", 4, "CD456", "Математичний аналіз");
        asp.Print();

        Console.WriteLine("\n=== Завдання 3: Book ===");
        Book b = new Book("Мистецтво війни", "Сунь-цзи", 377);
        b.Print();
        BookGenre bg = new BookGenre("1984", "Джордж Орвелл", 200, "Антиутопія");
        bg.Print();
        BookGenrePubl bgp = new BookGenrePubl("Кобзар", "Тарас Шевченко", 300, "Поезія", "Основи");
        bgp.Print();

        Console.WriteLine("\n=== Завдання 4: Figure/Rectangle ===");
        Figure f;

        f = new Rectangle("Прямокутник", 0, 0, 5, 3);
        f.Display();
        Console.WriteLine($"Площа: {(f as Rectangle).Area()}");

        f = new RectangleColor("Кольоровий прямокутник", 0, 0, 4, 2, "Жовтий");
        f.Display();
        Console.WriteLine($"Площа: {(f as RectangleColor).Area()}");
    }
}
*/