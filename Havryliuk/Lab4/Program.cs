using System;

namespace LabClasses
{
    //1. Person 
    class Person
    {
        private string name;
        private int age;
        private string gender;
        private string phoneNumber;

        public void SetName(string name) => this.name = name;
        public void SetAge(int age) => this.age = age;
        public void SetGender(string gender) => this.gender = gender;
        public void SetPhone(string phone) => this.phoneNumber = phone;

        public void Print()
        {
            Console.WriteLine($"Name: {name}, Age: {age}, Gender: {gender}, Phone: {phoneNumber}");
        }
    }




    //2. Student (Aspirant) 
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
            Console.WriteLine($"Student: {LastName}, Course: {Course}, RecordBook: {RecordBook}");
        }
    }

    class Aspirant : Student
    {
        public string DissertationTopic { get; set; }

        public Aspirant(string lastName, int course, string recordBook, string topic)
            : base(lastName, course, recordBook)
        {
            DissertationTopic = topic;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Dissertation Topic: {DissertationTopic}");
        }
    }





    //3. Book (BookGenre; BookGenrePubl)
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
            Console.WriteLine($"Book: {Title}, Author: {Author}, Price: {Price} UAH");
        }
    }

    class BookGenre : Book
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
            Console.WriteLine($"Genre: {Genre}");
        }
    }

    sealed class BookGenrePubl : BookGenre
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
            Console.WriteLine($"Publisher: {Publisher}");
        }
    }

    //4. Figure (Rectangle; RectangleColor)
    class Figure
    {
        public string Name { get; set; }

        public Figure(string name) => Name = name;

        public virtual void Display() => Console.WriteLine($"Figure: {Name}");
    }

    class Rectangle : Figure
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }

        public Rectangle(string name, int x1, int y1, int x2, int y2) : base(name)
        {
            X1 = x1; Y1 = y1;
            X2 = x2; Y2 = y2;
        }

        public Rectangle() : this("Rectangle", 0, 0, 1, 1) { }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Coordinates: ({X1},{Y1}) - ({X2},{Y2})");
        }

        public virtual int Area() => Math.Abs((X2 - X1) * (Y2 - Y1));
    }

    class RectangleColor : Rectangle
    {
        public string Color { get; set; }

        public RectangleColor(string name, int x1, int y1, int x2, int y2, string color)
            : base(name, x1, y1, x2, y2)
        {
            Color = color;
        }

        public RectangleColor() : this("Colored Rectangle", 0, 0, 1, 1, "Black") { }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Color: {Color}");
        }

        public override int Area()
        {
            int area = base.Area();
            Console.WriteLine($"Area: {area}");
            return area;
        }
    }





    //----Main----
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Person
            Console.WriteLine("=== Person ===");
            Person p = new Person();
            p.SetName("Katya");
            p.SetAge(20);
            p.SetGender("Female");
            p.SetPhone("+380123456789");
            p.Print();

            // 2. Student / Aspirant
            Console.WriteLine("\n=== Student & Aspirant ===");
            Student s = new Student("Petrenko", 3, "12345");
            s.Print();
            Aspirant a = new Aspirant("Ivanenko", 5, "67890", "Philosophy and psyhology");
            a.Print();

            // 3. Book / BookGenre / BookGenrePubl
            Console.WriteLine("\n=== Books ===");
            Book b = new Book("Kim Ji-young. Born 1982", " Cho Nam-Joo", 220);
            b.Print();
            BookGenre bg = new BookGenre("Four Treasures of the Sky", "Jenny Tinghui Zhang", 550, "Novel");
            bg.Print();
            BookGenrePubl bgp = new BookGenrePubl("C# Pro", "Mike Johnson", 600, "IT", "Oxford Press");
            bgp.Print();

            // 4. Figures
            Console.WriteLine("\n=== Figures ===");
            Figure f1 = new Rectangle("Rectangle", 2, 3, 7, 8);
            Figure f2 = new RectangleColor("RectColor", 0, 0, 5, 10, "Red");

            f1.Display(); // Polymorphism
            f2.Display();
        }
    }
}
