using System;

namespace OOP_Examples
{
    // ---------------------------- 1. Person ----------------------------
    public class Person
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Gender { get; set; } = "";
        public string Phone { get; set; } = "";

        public void Print()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Gender: {Gender}, Phone: {Phone}");
        }
    }

    // ---------------------------- 2. Student & Aspirant ----------------------------
    public class Student
    {
        public string Surname { get; set; } = "";
        public int Course { get; set; }
        public string RecordBook { get; set; } = "";

        public Student(string surname, int course, string recordBook)
        {
            Surname = surname;
            Course = course;
            RecordBook = recordBook;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Surname: {Surname}, Course: {Course}, Record Book: {RecordBook}");
        }
    }

    public class Aspirant : Student
    {
        public string ResearchTopic { get; set; } = "";

        public Aspirant(string surname, int course, string recordBook, string topic)
            : base(surname, course, recordBook)
        {
            ResearchTopic = topic;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Research Topic: {ResearchTopic}");
        }
    }

    // ---------------------------- 3. Book, BookGenre, BookGenrePubl ----------------------------
    public class Book
    {
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public decimal Price { get; set; }

        public Book(string title, string author, decimal price)
        {
            Title = title;
            Author = author;
            Price = price;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Title: {Title}, Author: {Author}, Price: {Price}");
        }
    }

    public class BookGenre : Book
    {
        public string Genre { get; set; } = "";

        public BookGenre(string title, string author, decimal price, string genre)
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
        public string Publisher { get; set; } = "";

        public BookGenrePubl(string title, string author, decimal price, string genre, string publisher)
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

    // ---------------------------- 4. Figure, Rectangle, RectangleColor ----------------------------
    public class Figure
    {
        public string Name { get; set; } = "";

        public Figure(string name)
        {
            Name = name;
        }

        public virtual void Display()
        {
            Console.WriteLine($"Figure: {Name}");
        }
    }

    public class Rectangle : Figure
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }

        public Rectangle(double x1, double y1, double x2, double y2, string name)
            : base(name)
        {
            X1 = x1; Y1 = y1; X2 = x2; Y2 = y2;
        }

        public Rectangle() : this(0, 0, 1, 1, "Rectangle") { }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Coordinates: ({X1},{Y1}) - ({X2},{Y2})");
        }

        public virtual double Area()
        {
            return Math.Abs((X2 - X1) * (Y2 - Y1));
        }
    }

    public class RectangleColor : Rectangle
    {
        public string Color { get; set; } = "Red";

        public RectangleColor(double x1, double y1, double x2, double y2, string name, string color)
            : base(x1, y1, x2, y2, name)
        {
            Color = color;
        }

        public RectangleColor() : this(0, 0, 1, 1, "RectangleColor", "Red") { }

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

    // ---------------------------- 5. Vector ----------------------------
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Vector operator -(Vector v) => new Vector(-v.X, -v.Y);
        public static Vector operator +(Vector v1, Vector v2) => new Vector(v1.X + v2.X, v1.Y + v2.Y);
        public static Vector operator *(Vector v, double scalar) => new Vector(v.X * scalar, v.Y * scalar);

        public double Length() => Math.Sqrt(X * X + Y * Y);

        public override bool Equals(object? obj) => obj is Vector v && X == v.X && Y == v.Y;
        public override int GetHashCode() => HashCode.Combine(X, Y);

        public void Print()
        {
            Console.WriteLine($"Vector: ({X}, {Y})");
        }
    }

    // ---------------------------- 6. Main Program ----------------------------
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("===== Lab4 Test =====");

            // 1. Person
            var person = new Person { Name = "Ivan", Age = 25, Gender = "Male", Phone = "+380123456789" };
            person.Print();

            // 2. Student & Aspirant
            var student = new Student("Kulka", 3, "RB123");
            student.Print();
            var aspirant = new Aspirant("Petrov", 1, "RB456", "AI Research");
            aspirant.Print();

            // 3. Book
            var book = new BookGenrePubl("C# in Depth", "Jon Skeet", 45.99m, "Programming", "Manning");
            book.Print();

            // 4. Rectangle
            Figure fig1 = new Rectangle(0, 0, 3, 4, "Rect1");
            Figure fig2 = new RectangleColor(0, 0, 2, 5, "Rect2", "Blue");
            fig1.Display();
            fig2.Display();

            Rectangle r = fig1 as Rectangle;
            Console.WriteLine($"Area of fig1: {r.Area()}");

            RectangleColor rc = fig2 as RectangleColor;
            Console.WriteLine($"Area of fig2: {rc.Area()}");

            // 5. Vector
            Vector v1 = new Vector(3, 4);
            Vector v2 = new Vector(1, -2);

            // Unary minus
            Vector vNeg = -v1; 
            vNeg.Print();

            // Addition
            Vector vSum = vNeg + v2;
            vSum.Print();

            // Multiplication
            Vector vMul = v2 * 2;
            vMul.Print();

            // Length
            Console.WriteLine($"Length of v1: {v1.Length()}");
        }
    }
}
