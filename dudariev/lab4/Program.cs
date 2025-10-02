Task1.Program.Main();
Task2.Program.Main();
Task3.Program.Main();
Task4.Program.Main();

namespace Task1
{
    // 1. Розробити клас Person, який містить відповідні члени для зберігання:
    // імені, віку, статі і телефонного номера.
    // Напишіть функції-члени, які зможуть змінювати ці члени даних індивідуально. Напишіть функцію-член Person :: Print (), яка виводить відформатовані дані про людину.

    enum Sex
    {
        Male,
        Female,
    }

    class Person
    {
        public string Name;
        public int Age;
        public Sex Sex;
        public string PhoneNumber;

        public void SetName(string Name)
        {
            this.Name = Name;
        }

        public void SetAge(int Age)
        {
            this.Age = Age;
        }

        public void SetSex(Sex Sex)
        {
            this.Sex = Sex;
        }

        public void SetPhoneNumber(string PhoneNumber)
        {
            this.PhoneNumber = PhoneNumber;
        }

        public void Print()
        {
            Console.WriteLine("Ім'я - {0}", Name);
            Console.WriteLine("Вік - {0}", Age);
            Console.WriteLine("Стать - {0}", Sex == Sex.Male ? "Чоловік" : "Жінка");
            Console.WriteLine("Номер телефону - {0}", PhoneNumber);
        }
    }

    class Program
    {
        public static void Main()
        {
            Console.WriteLine("1.");
            var person = new Person
            {
                Name = "Степан Гончар",
                Age = 45,
                Sex = Sex.Male,
                PhoneNumber = "+380952358925",
            };
            person.Print();
            Console.WriteLine();

            person.SetAge(12);
            person.Print();
            Console.WriteLine();
        }
    }
}

namespace Task2
{
    // 2. Створити базовий клас Student, що буде містити інформацію про студента (прізвище, курс навчання, номер залікової книги).

    // За допомогою механізму спадкування реалізувати клас Aspirant (аспірант – студент, що готується до захисту кандидатської дисертації).
    // Клас Aspirant є похідним від класу Student.

    // У класах Student і Aspirant необхідно реалізувати наступні елементи:
    // конструктори класів з відповідною кількістю параметрів.
    // У класі Aspirant для доступу до методів класу Student потрібно використовувати ключове слово base;
    // властивості get/set для доступу до полів класу;
    // метод Print(), що виводить інформацію про вміст полів класу.

    class Student
    {
        protected string Surname { get; set; }
        protected int Kurs { get; set; }
        protected int Number { get; set; }

        public Student(string Surname, int Kurs, int Number)
        {
            this.Surname = Surname;
            this.Kurs = Kurs;
            this.Number = Number;
        }

        public virtual void Print()
        {
            Console.WriteLine("Студент");
            Console.WriteLine("Прізвище - {0}", Surname);
            Console.WriteLine("Курс - {0}", Kurs);
            Console.WriteLine("Номер залікової книжки - {0}", Number);
        }
    }

    class Aspirant : Student
    {
        public Aspirant(string Surname, int Kurs, int Number) : base(Surname, Kurs, Number)
        {
        }

        public override void Print()
        {
            Console.WriteLine("Аспірант");
            Console.WriteLine("Прізвище - {0}", base.Surname);
            Console.WriteLine("Курс - {0}", base.Kurs);
            Console.WriteLine("Номер залікової книжки - {0}", base.Number);
        }
    }

    class Program
    {
        public static void Main()
        {
            Console.WriteLine("2.");
            var student = new Student("Гончар", 3, 27304);
            student.Print();
            Console.WriteLine();

            var aspirant = new Aspirant("Вишня", 6, 18364);
            aspirant.Print();
            Console.WriteLine();
        }
    }
}

namespace Task3
{
    // 3. Задано клас Book, що описує книгу. Клас містить наступні елементи:
    // назва книги;
    // прізвище й ім’я автора;
    // вартість книги.
    // У класі Book потрібно реалізувати наступні методи:
    // конструктор з 3 параметрами;
    // властивості get/set для доступу до полів класу;
    // метод Print(), що виводить інформацію про книгу.

    class Book
    {
        string Title { get; set; }
        string Author { get; set; }
        float Price { get; set; }

        public Book(string Title, string Author, float Price)
        {
            this.Title = Title;
            this.Author = Author;
            this.Price = Price;
        }

        public virtual void Print()
        {
            Console.WriteLine("Назва - {0}", Title);
            Console.WriteLine("Автор - {0}", Author);
            Console.WriteLine("Вартість - {0}", Price);
        }
    }

    // Розробити клас BookGenre, що успадковує можливості класу Book і додає поле жанру (genre). У класі BookGenre реалізувати наступні елементи:
    // конструктор з 4 параметрами – реалізує виклик конструктора базового класу;
    // властивість get/set доступу до внутрішнього поля класу;
    // метод Print(), що звертається до методу Print() базового класу Book для виведення інформації про всі поля класу.

    class BookGenre : Book
    {
        string Genre { get; set; }

        public BookGenre(string Title, string Author, float Price, string Genre) : base(Title, Author, Price)
        {
            this.Genre = Genre;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Жанр - {0}", Genre);
        }
    }

    // Розробити клас BookGenrePubl, що успадкований від класу BookGenre. Даний клас додає поле, що містить інформацію про видавця. У класі BookGenrePubl реалізувати наступні елементи:
    // конструктор з 5 параметрами;
    // властивість get/set для доступу до внутрішнього поля класу;
    // метод Print(), що викликає однойменний метод базового класу і виводить на екран інформацію про видавця.
    // Клас BookGenrePubl зробити таким, що не може бути успадкований.

    sealed class BookGenrePubl : BookGenre
    {
        string Publisher { get; set; }

        public BookGenrePubl(string Title, string Author, float Price, string Genre, string Publisher) : base(Title, Author, Price, Genre)
        {
            this.Publisher = Publisher;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Видавець - {0}", Publisher);
        }
    }

    class Program
    {
        public static void Main()
        {
            Console.WriteLine("3.");

            var book = new Book("Title1", "Author1", 123);
            book.Print();
            Console.WriteLine();

            var bookGenre = new BookGenre("Title2", "Author2", 234, "Genre2");
            bookGenre.Print();
            Console.WriteLine();

            var bookGenrePubl = new BookGenrePubl("Title3", "Author3", 345, "Genre3", "Publisher3");
            bookGenrePubl.Print();
            Console.WriteLine();
        }
    }
}

namespace Task4
{
    // 4. Оголосити клас Figure, який містить поле name, яке визначає назву фігури. У класі Figure оголосити наступні методи:
    // конструктор з 1 параметром;
    // метод Display(), який відображає назву фігури.

    class Figure
    {
        string Name;

        public Figure(string Name)
        {
            this.Name = Name;
        }

        public virtual void Display()
        {
            Console.WriteLine("Name = {0}", Name);
        }
    }

    // З класу Figure успадкувати клас Rectangle (прямокутник), який містить наступні поля:
    // координату лівого верхнього кута (x1; y1);
    // координату правого нижнього кута (x2; y2).
    // У класі Rectangle реалізувати наступні методи та функції:
    // конструктор з 5 параметрами, який викликає конструктор базового класу Figure;
    // конструктор без параметрів, який реалізує встановлення координат кутів (0; 0), (1; 1) та викликає конструктор з 5 параметрами з допомогою засобу this;
    // метод Display(), який відображає назву фігури та значення внутрішніх полів. Даний метод звертається до однойменного методу базового класу;
    // метод Area(), який повертає площу прямокутника.

    class Rectangle : Figure
    {
        int x1;
        int y1;
        int x2;
        int y2;

        public Rectangle(string Name, int x1, int y1, int x2, int y2) : base(Name)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public Rectangle() : this("Rectangle", 0, 0, 1, 1)
        {
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("x1 = {0}", x1);
            Console.WriteLine("y1 = {0}", y1);
            Console.WriteLine("x2 = {0}", x2);
            Console.WriteLine("y2 = {0}", y2);
        }

        public virtual int Area()
        {
            return (x2 - x1) * (y2 - y1);
        }
    }

    // З класу Rectangle успадкувати клас RectangleColor. У класі RectangleColor реалізувати поле color (колір) та наступні методи;
    // конструктор з 6 параметрами, який викликає конструктор базового класу Rectangle;
    // конструктор без параметрів, який встановлює координати (0; 0), (1; 1) та викликає конструктор з 6 параметрами з допомогою засобу this;
    // метод Display(), який відображає назву фігури та значення внутрішніх полів. Даний метод звертається до однойменного методу базового класу;
    // метод Area(), який повертає площу прямокутника. У методі викликається метод Area() базового класу.

    class RectangleColor : Rectangle
    {
        string Color;

        public RectangleColor(string Name, int x1, int y1, int x2, int y2, string Color) : base(Name, x1, y1, x2, y2)
        {
            this.Color = Color;
        }

        public RectangleColor() : this("RectangleColor", 0, 0, 1, 1, "Black")
        {
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("Color = {0}", Color);
        }

        public override int Area()
        {
            return base.Area();
        }
    }

    // У функції Main() виконати наступні дії:
    // оголосити посилання на базовий клас Figure;
    // створити екземпляри класів Rectangle та RectangleColor;
    // продемонструвати доступ до методів похідних класів з допомогою посилання на клас Figure

    class Program
    {
        public static void Main()
        {
            Console.WriteLine("4.");

            Figure figure;
            var rectangle = new Rectangle("Rectangle1", 1, 2, 3, 4);
            var rectangleColor = new RectangleColor("Rectangle2", 4, 1, 8, 8, "Red");

            figure = rectangle;
            figure.Display();
            Console.WriteLine();

            figure = rectangleColor;
            figure.Display();
            Console.WriteLine();
        }
    }
}