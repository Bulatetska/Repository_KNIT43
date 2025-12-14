using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_Examples
{
    // ---------------------------- 1. Person ----------------------------
    class Person
    {
        private string name;
        private int age;
        private string gender;
        private string phone;

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Phone { get => phone; set => phone = value; }

        public void Print()
        {
            Console.WriteLine($"Name: {name}, Age: {age}, Gender: {gender}, Phone: {phone}");
        }
    }

    // ---------------------------- 2. Student & Aspirant ----------------------------
    class Student
    {
        private string surname;
        private int course;
        private string recordBook;

        public string Surname { get => surname; set => surname = value; }
        public int Course { get => course; set => course = value; }
        public string RecordBook { get => recordBook; set => recordBook = value; }

        public Student(string surname, int course, string recordBook)
        {
            this.surname = surname;
            this.course = course;
            this.recordBook = recordBook;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Surname: {surname}, Course: {course}, Record Book: {recordBook}");
        }
    }

    class Aspirant : Student
    {
        private string researchTopic;
        public string ResearchTopic { get => researchTopic; set => researchTopic = value; }

        public Aspirant(string surname, int course, string recordBook, string topic)
            : base(surname, course, recordBook)
        {
            this.researchTopic = topic;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Research Topic: {researchTopic}");
        }
    }

    // ---------------------------- 3. Book, BookGenre, BookGenrePubl ----------------------------
    class Book
    {
        private string title;
        private string author;
        private decimal price;

        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public decimal Price { get => price; set => price = value; }

        public Book(string title, string author, decimal price)
        {
            this.title = title;
            this.author = author;
            this.price = price;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Title: {title}, Author: {author}, Price: {price}");
        }
    }

    class BookGenre : Book
    {
        private string genre;
        public string Genre { get => genre; set => genre = value; }

        public BookGenre(string title, string author, decimal price, string genre)
            : base(title, author, price)
        {
            this.genre = genre;
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
        public string Publisher { get => publisher; set => publisher = value; }

        public BookGenrePubl(string title, string author, decimal price, string genre, string publisher)
            : base(title, author, price, genre)
        {
            this.publisher = publisher;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Publisher: {publisher}");
        }
    }

    // ---------------------------- 4. Figure, Rectangle, RectangleColor ----------------------------
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
        protected double x1, y1, x2, y2;

        public Rectangle(double x1, double y1, double x2, double y2, string name)
            : base(name)
        {
            this.x1 = x1; this.y1 = y1; this.x2 = x2; this.y2 = y2;
        }

        public Rectangle() : this(0, 0, 1, 1, "Rectangle") { }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Coordinates: ({x1},{y1}) - ({x2},{y2})");
        }

        public double Area()
        {
            return Math.Abs((x2 - x1) * (y2 - y1));
        }
    }

    class RectangleColor : Rectangle
    {
        private string color;

        public RectangleColor(double x1, double y1, double x2, double y2, string name, string color)
            : base(x1, y1, x2, y2, name)
        {
            this.color = color;
        }

        public RectangleColor() : this(0, 0, 1, 1, "RectangleColor", "Red") { }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Color: {color}");
        }

        public new double Area()
        {
            return base.Area();
        }
    }

    // ---------------------------- Main Program ----------------------------
    class Program
    {
        static void Main()
        {
            Console.WriteLine("===== Task 1: Person =====");
            Person p = new Person { Name = "Ivan", Age = 25, Gender = "Male", Phone = "+380123456789" };
            p.Print();

            Console.WriteLine("\n===== Task 2: Student & Aspirant =====");
            Student s = new Student("Kulka", 3, "RB123");
            s.Print();
            Aspirant a = new Aspirant("Petrov", 1, "RB456", "AI Research");
            a.Print();

            Console.WriteLine("\n===== Task 3: Books =====");
            BookGenrePubl book = new BookGenrePubl("C# in Depth", "Jon Skeet", 45.99m, "Programming", "Manning");
            book.Print();

            Console.WriteLine("\n===== Task 4: Figures =====");
            Figure fig1 = new Rectangle(0, 0, 3, 4, "Rect1");
            Figure fig2 = new RectangleColor(0, 0, 2, 5, "Rect2", "Blue");

            fig1.Display();
            fig2.Display();

            Rectangle rect = fig1 as Rectangle;
            Console.WriteLine($"Area of fig1: {rect.Area()}");

            RectangleColor rectColor = fig2 as RectangleColor;
            Console.WriteLine($"Area of fig2: {rectColor.Area()}");
        }
    }
}
