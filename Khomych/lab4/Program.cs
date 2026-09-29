using System;

namespace OOPTasks
{
    public class Person
    {
        private string name;
        private int age;
        private string gender;
        private string phone;

        // Функції-члени для індивідуальної зміни даних
        public void SetName(string newName) => name = newName;
        public void SetAge(int newAge) => age = newAge;
        public void SetGender(string newGender) => gender = newGender;
        public void SetPhone(string newPhone) => phone = newPhone;

        public void Print()
        {
            Console.WriteLine($"Особа: Ім'я: {name}, Вік: {age}, Стать: {gender}, Телефон: {phone}");
        }
    }

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

        public virtual void Print()
        {
            Console.WriteLine($"Студент: {LastName}, Курс: {Course}, Заліковка: {RecordBookNumber}");
        }
    }

    public class Aspirant : Student
    {
        public Aspirant(string lastName, int course, string recordBookNumber) 
            : base(lastName, course, recordBookNumber)
        {
        }

        public override void Print()
        {
            Console.Write("[Аспірант] ");
            base.Print();
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
            Console.WriteLine($"Книга: '{Title}', Автор: {Author}, Ціна: {Price} грн");
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
            Console.WriteLine($"Видавець: {Publisher}");
        }
    }

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
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }

        public Rectangle(string name, double x1, double y1, double x2, double y2) 
            : base(name)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public Rectangle() : this("Прямокутник (за замовчуванням)", 0, 0, 1, 1)
        {
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Координати: ({X1};{Y1}), ({X2};{Y2})");
        }

        public virtual double Area()
        {
            return Math.Abs(X2 - X1) * Math.Abs(Y2 - Y1);
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

        public RectangleColor() : this("Кольоровий прямокутник (за замовчуванням)", 0, 0, 1, 1, "Чорний")
        {
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Колір: {Color}");
        }

        public override double Area()
        {
            return base.Area();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Завдання 1 ---");
            Person person = new Person();
            person.SetName("Олександр");
            person.SetAge(30);
            person.SetGender("Чоловіча");
            person.SetPhone("+380991234567");
            person.Print();

            Console.WriteLine("\n--- Завдання 2 ---");
            Student student = new Student("Іваненко", 3, "КВ-12345");
            student.Print();
            Aspirant aspirant = new Aspirant("Петренко", 5, "АС-98765");
            aspirant.Print();

            Console.WriteLine("\n--- Завдання 3 ---");
            BookGenrePubl book = new BookGenrePubl("Програмування на C#", "Троєлсен", 1500.50, "Навчальна література", "Вільямс");
            book.Print();

            Console.WriteLine("\n--- Завдання 4 ---");
            Figure figRef;

            Rectangle rect1 = new Rectangle("Мій Прямокутник", 1, 5, 4, 1);
            Rectangle rect2 = new Rectangle(); // Використання конструктора за замовчуванням
            RectangleColor rectColor = new RectangleColor("Червоний Прямокутник", 0, 10, 5, 0, "Червоний");

            figRef = rect1;
            figRef.Display();
            Console.WriteLine($"Площа: {((Rectangle)figRef).Area()}"); 

            Console.WriteLine();

            figRef = rect2;
            figRef.Display();
            Console.WriteLine($"Площа: {((Rectangle)figRef).Area()}");

            Console.WriteLine();

            figRef = rectColor;
            figRef.Display(); 
            Console.WriteLine($"Площа: {((RectangleColor)figRef).Area()}");
        }
    }
}