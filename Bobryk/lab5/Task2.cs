using System;

class Student
{
    private string surname;
    private int course;
    private string book;

    public Student(string surname, int course, string book)
    {
        this.surname = surname;
        this.course = course;
        this.book = book;
    }

    public string Surname
    {
        get { return surname; }
        set { surname = value; }
    }

    public int Course
    {
        get { return course; }
        set { course = value; }
    }

    public string Book
    {
        get { return book; }
        set { book = value; }
    }

    public void Print()
    {
        Console.WriteLine("Прізвище: " + surname);
        Console.WriteLine("Курс: " + course);
        Console.WriteLine("Номер залікової книги: " + book);
    }
}

class Aspirant : Student
{
    private string dis;

    public Aspirant(string surname, int course, string book, string dis)
        : base(surname, course, book)
    {
        this.dis = dis;
    }

    public string Dis
    {
        get { return dis; }
        set { dis = value; }
    }

    public new void Print()
    {
        base.Print();
        Console.WriteLine("Тема дисертації: " + dis);
    }
}

class Program
{
    static void Main()
    {
        Student student = new Student("Бобрик", 3, "KB12345");

        Aspirant aspirant = new Aspirant(
            "Петренко",
            5,
            "AS54321",
            "Штучний інтелект"
        );

        Console.WriteLine("Студент:");
        student.Print();

        Console.WriteLine();

        Console.WriteLine("Аспірант:");
        aspirant.Print();
    }
}