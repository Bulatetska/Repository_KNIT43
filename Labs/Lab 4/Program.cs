using System;

namespace LabOOP
{
    // ====================== 1. Клас Person ======================
    class Person
    {
        // Поля
        private string name;
        private int age;
        private string gender;
        private string phoneNumber;

        // Конструктор
        public Person(string name, int age, string gender, string phoneNumber)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.phoneNumber = phoneNumber;
        }

        // Методи для зміни полів (сеттери)
        public void SetName(string name) => this.name = name;
        public void SetAge(int age) => this.age = age;
        public void SetGender(string gender) => this.gender = gender;
        public void SetPhoneNumber(string phoneNumber) => this.phoneNumber = phoneNumber;

        // Вивід інформації
        public void Print()
        {
            Console.WriteLine("=== Person ===");
            Console.WriteLine($"Ім'я: {name}");
            Console.WriteLine($"Вік: {age}");
            Console.WriteLine($"Стать: {gender}");
            Console.WriteLine($"Телефон: {phoneNumber}");
        }
    }

    // ====================== 2. Student / Aspirant ======================

    class Student
    {
        // Властивості (прізвище, курс, номер заліковки)
        public string LastName { get; set; }
        public int Course { get; set; }
        public string RecordBookNumber { get; set; }

        // Конструктори
        public Student() { }

        public Student(string lastName, int course, string recordBookNumber)
        {
            LastName = lastName;
            Course = course;
            RecordBookNumber = recordBookNumber;
        }

        // Метод виводу
        public virtual void Print()
        {
            Console.WriteLine("=== Student ===");
            Console.WriteLine($"Прізвище: {LastName}");
            Console.WriteLine($"Курс: {Course}");
            Console.WriteLine($"№ залікової книжки: {RecordBookNumber}");
        }
    }

    class Aspirant : Student
    {
        // Додаткове поле – тема дисертації
        public string ThesisTopic { get; set; }

        // Конструктор
        public Aspirant(string lastName, int course, string recordBookNumber, string thesisTopic)
            : base(lastName, course, recordBookNumber)   // виклик конструктора Student
        {
            ThesisTopic = thesisTopic;
        }

        public override void Print()
        {
            Console.WriteLine("=== Aspirant ===");
            base.Print();
            Console.WriteLine($"Тема дисертації: {ThesisTopic}");
        }
    }

    // ====================== 3. Book / BookGenre / BookGenrePubl ======================

    class Book
    {
        public string Title { get; set; }
        public string AuthorFullName { get; set; }
        public decimal Price { get; set; }

        public Book(string title, string authorFullName, decimal price)
        {
            Title = title;
            AuthorFullName = authorFullName;
            Price = price;
        }

        public virtual void Print()
        {
            Console.WriteLine("=== Book ===");
            Console.WriteLine($"Назва: {Title}");
            Console.WriteLine($"Автор: {AuthorFullName}");
            Console.WriteLine($"Вартість: {Price} грн");
        }
    }

    class BookGenre : Book
    {
        public string Genre { get; set; }

        public BookGenre(string title, string authorFullName, decimal price, string genre)
            : base(title, authorFullName, price)    // виклик конструктора Book
        {
            Genre = genre;
        }

        public override void Print()
        {
            Console.WriteLine("=== BookGenre ===");
            base.Print(); // виводимо поля базового класу
            Console.WriteLine($"Жанр: {Genre}");
        }
    }

    // sealed – клас не можна успадкувати
    sealed class BookGenrePubl : BookGenre
    {
        public string Publisher { get; set; }

        public BookGenrePubl(string title, string authorFullName, decimal price,
                             string genre, string publisher)
            : base(title, authorFullName, price, genre)
        {
            Publisher = publisher;
        }

        public override void Print()
        {
            Console.WriteLine("=== BookGenrePubl ===");
            base.Print();
            Console.WriteLine($"Видавництво: {Publisher}");
        }
    }

    // ====================== 4. Figure / Rectangle / RectangleColor ======================

    class Figure
    {
        protected string name;

        public Figure(string name)
        {
            this.name = name;
        }

        public virtual void Display()
        {
            Console.WriteLine($"Фігура: {name}");
        }
    }

    class Rectangle : Figure
    {
        protected double x1, y1, x2, y2;

        // Конструктор з 5 параметрами
        public Rectangle(string name, double x1, double y1, double x2, double y2)
            : base(name)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        // Конструктор без параметрів: this(...)
        public Rectangle() : this("Прямокутник", 0, 0, 1, 1)
        {
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Лівий верхній кут: ({x1}; {y1})");
            Console.WriteLine($"Правий нижній кут: ({x2}; {y2})");
        }

        public virtual double Area()
        {
            double width = Math.Abs(x2 - x1);
            double height = Math.Abs(y2 - y1);
            return width * height;
        }
    }

    class RectangleColor : Rectangle
    {
        private string color;

        public string Color
        {
            get => color;
            set => color = value;
        }

        // Конструктор з 6 параметрами
        public RectangleColor(string name, double x1, double y1, double x2, double y2, string color)
            : base(name, x1, y1, x2, y2)
        {
            this.color = color;
        }

        // Без параметрів – викликає 6-параметровий
        public RectangleColor() : this("Кольоровий прямокутник", 0, 0, 1, 1, "red")
        {
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Колір: {color}");
        }

        public override double Area()
        {
            // викликаємо Area() базового класу
            double area = base.Area();
            return area;
        }
    }

    // ====================== MAIN ======================

    class Program
    {
        static void Main()
        {
            // ---- 1. Person ----
            var p = new Person("Іван", 20, "чоловіча", "+380123456789");
            p.Print();
            Console.WriteLine();

            // ---- 2. Student / Aspirant ----
            var st = new Student("Петренко", 2, "AB12345");
            st.Print();
            Console.WriteLine();

            var asp = new Aspirant("Іваненко", 4, "CD67890", "Машинне навчання");
            asp.Print();
            Console.WriteLine();

            // ---- 3. Book / BookGenre / BookGenrePubl ----
            var book = new Book("Пригоди", "Джо Доу", 250m);
            book.Print();
            Console.WriteLine();

            var bookG = new BookGenre("Фентезі-роман", "Іван Автор", 320m, "Фентезі");
            bookG.Print();
            Console.WriteLine();

            var bookGP = new BookGenrePubl("Наукова книга", "Петро Вчений", 400m,
                                           "Наукова", "Наукове видавництво");
            bookGP.Print();
            Console.WriteLine();

            // ---- 4. Figure / Rectangle / RectangleColor + поліморфізм ----
            Figure figRef; // посилання на базовий клас

            Rectangle r = new Rectangle("Прямокутник 1", 0, 0, 3, 4);
            RectangleColor rc = new RectangleColor("Кольоровий прямокутник 2", 1, 1, 4, 5, "blue");

            // Посилання базового класу може вказувати на об’єкт похідного класу
            figRef = r;
            Console.WriteLine("Виклик через Figure -> Rectangle:");
            figRef.Display();
            // Щоб викликати Area, треба зкастити до Rectangle
            Console.WriteLine($"Площа: {((Rectangle)figRef).Area()}");
            Console.WriteLine();

            figRef = rc;
            Console.WriteLine("Виклик через Figure -> RectangleColor:");
            figRef.Display();
            Console.WriteLine($"Площа: {((RectangleColor)figRef).Area()}");
            Console.WriteLine();

            Console.WriteLine("Натисніть будь-яку клавішу, щоб завершити...");
            Console.ReadKey();
        }
    }
}
