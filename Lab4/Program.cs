using System;

namespace OOP_Tasks
{
    // === 1. Клас Person ===
    class Person
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

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Phone { get => phone; set => phone = value; }

        public void Print()
        {
            Console.WriteLine($"Ім’я: {name}\nВік: {age}\nСтать: {gender}\nТелефон: {phone}");
        }
    }

    // === 2. Класи Student і Aspirant ===
    class Student
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
            Console.WriteLine($"Тема дисертації: {DissertationTopic}");
        }
    }

    // === 3. Класи Book, BookGenre, BookGenrePubl ===
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
            Console.WriteLine($"Назва: {Title}\nАвтор: {Author}\nЦіна: {Price} грн");
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
            Console.WriteLine($"Жанр: {Genre}");
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
            Console.WriteLine($"Видавництво: {Publisher}");
        }
    }

    // === 4. Класи Figure, Rectangle, RectangleColor ===
    class Figure
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

    class Rectangle : Figure
    {
        protected double x1, y1, x2, y2;

        public Rectangle(string name, double x1, double y1, double x2, double y2)
            : base(name)
        {
            this.x1 = x1; this.y1 = y1;
            this.x2 = x2; this.y2 = y2;
        }

        public Rectangle() : this("Прямокутник", 0, 0, 1, 1) { }

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

    class RectangleColor : Rectangle
    {
        public string Color { get; set; }

        public RectangleColor(string name, double x1, double y1, double x2, double y2, string color)
            : base(name, x1, y1, x2, y2)
        {
            Color = color;
        }

        public RectangleColor() : this("Кольоровий прямокутник", 0, 0, 1, 1, "червоний") { }

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

    // === MAIN ===
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n=== МЕНЮ ЗАВДАНЬ ===");
                Console.WriteLine("1. Клас Person");
                Console.WriteLine("2. Класи Student / Aspirant");
                Console.WriteLine("3. Класи Book / BookGenre / BookGenrePubl");
                Console.WriteLine("4. Класи Figure / Rectangle / RectangleColor");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");
                int choice = int.Parse(Console.ReadLine() ?? "0");

                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        RunPerson();
                        break;
                    case 2:
                        RunStudent();
                        break;
                    case 3:
                        RunBook();
                        break;
                    case 4:
                        RunFigure();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Невірний вибір!");
                        break;
                }
            }
        }

        static void RunPerson()
        {
            Person p = new Person("Олександр", 28, "чоловіча", "+380123456789");
            p.Print();
        }

        static void RunStudent()
        {
            Student s = new Student("Іваненко", 2, "AB12345");
            Aspirant a = new Aspirant("Петренко", 5, "CD67890", "Штучний інтелект у медицині");
            s.Print();
            Console.WriteLine();
            a.Print();
        }

        static void RunBook()
        {
            BookGenrePubl b = new BookGenrePubl("Майстер і Маргарита", "М.Булгаков", 350, "Роман", "КСД");
            b.Print();
        }

        static void RunFigure()
        {
            Figure fig;

            fig = new Rectangle("Прямокутник", 0, 0, 3, 4);
            fig.Display();
            Console.WriteLine($"Площа: {(fig as Rectangle)?.Area()}\n");

            fig = new RectangleColor("Кольоровий прямокутник", 1, 1, 5, 6, "синій");
            fig.Display();
            Console.WriteLine($"Площа: {(fig as RectangleColor)?.Area()}");
        }
    }
}
