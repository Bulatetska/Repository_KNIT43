using System;

namespace OOP_Tasks
{
    // === 1. Клас Person ===
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }

        public Person(string name, int age, string gender, string phone)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Phone = phone;
        }

        public void Print()
        {
            Console.WriteLine($"Ім’я: {Name}\nВік: {Age}\nСтать: {Gender}\nТелефон: {Phone}");
        }
    }

    // === 2. Класи Student і Aspirant ===

    public class Student
    {
        public string LastName { get; set; }
        public int Course { get; set; }
        public string RecordBookNumber { get; set; }

        public Student(string lastName, int course, string recordBook)
        {
            LastName = lastName;
            Course = course;
            RecordBookNumber = recordBook;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Студент: {LastName}, Курс: {Course}, № залікової: {RecordBookNumber}");
        }
    }

    public class Aspirant : Student
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
            Console.WriteLine($"Тема дисертації: {DissertationTopic}");
        }
    }

    // === 3. Book / BookGenre / BookGenrePubl ===

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
            Console.WriteLine($"Назва: {Title}\nАвтор: {Author}\nЦіна: {Price} грн");
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

    // === 4. Фігури ===

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
        protected double x1, y1, x2, y2;

        public Rectangle(string name, double x1, double y1, double x2, double y2)
            : base(name)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public Rectangle() : this("Прямокутник", 0, 0, 1, 1) {}

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Координати: ({x1}, {y1}) – ({x2}, {y2})");
        }

        public virtual double Area()
        {
            return Math.Abs((x2 - x1) * (y2 - y1));
        }
    }

    public class RectangleColor : Rectangle
    {
        public string Color { get; set; }

        public RectangleColor(string name, double x1, double y1, double x2, double y2, string color)
            : base(name, x1, y1, x2, y2)
        {
            Color = color;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Колір: {Color}");
        }
    }

    // === MAIN ===
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Lab4 code runs.");
        }
    }
}
