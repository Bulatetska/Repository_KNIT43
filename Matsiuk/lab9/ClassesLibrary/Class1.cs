using System;

namespace ClassesLibrary
{
    public class Person
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
            Console.WriteLine("Person information:");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"Phone: {phone}");
        }
    }

    public class Student
    {
        public string Surname { get; set; }
        public int Course { get; set; }
        public string StudentBookNumber { get; set; }

        public Student(string surname, int course, string studentBookNumber)
        {
            Surname = surname;
            Course = course;
            StudentBookNumber = studentBookNumber;
        }

        public virtual void Print()
        {
            Console.WriteLine("Student information:");
            Console.WriteLine($"Surname: {Surname}");
            Console.WriteLine($"Course: {Course}");
            Console.WriteLine($"Student book number: {StudentBookNumber}");
        }
    }

    public class Aspirant : Student
    {
        public string DissertationTopic { get; set; }

        public Aspirant(string surname, int course,
            string studentBookNumber, string dissertationTopic)
            : base(surname, course, studentBookNumber)
        {
            DissertationTopic = dissertationTopic;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Dissertation topic: {DissertationTopic}");
        }
    }

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
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Price: {Price:F2}");
        }
    }

    public class BookGenre : Book
    {
        public string Genre { get; set; }

        public BookGenre(string title, string author,
            double price, string genre)
            : base(title, author, price)
        {
            Genre = genre;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Genre: {Genre}");
        }
    }

    public sealed class BookGenrePubl : BookGenre
    {
        public string Publisher { get; set; }

        public BookGenrePubl(string title, string author,
            double price, string genre, string publisher)
            : base(title, author, price, genre)
        {
            Publisher = publisher;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Publisher: {Publisher}");
        }
    }

    public class Figure
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

    public class Rectangle : Figure
    {
        protected double x1, y1, x2, y2;

        public Rectangle(string name, double x1, double y1,
            double x2, double y2) : base(name)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public Rectangle() : this("Rectangle", 0, 0, 1, 1) { }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Top-left corner: ({x1}; {y1})");
            Console.WriteLine($"Bottom-right corner: ({x2}; {y2})");
        }

        public virtual double Area()
        {
            return Math.Abs(x2 - x1) * Math.Abs(y2 - y1);
        }
    }

    public class RectangleColor : Rectangle
    {
        public string Color { get; set; }

        public RectangleColor(string name, double x1, double y1,
            double x2, double y2, string color)
            : base(name, x1, y1, x2, y2)
        {
            Color = color;
        }

        public RectangleColor()
            : this("Colored Rectangle", 0, 0, 1, 1, "Red") { }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Color: {Color}");
        }

        public override double Area()
        {
            return base.Area();
        }
    }
}