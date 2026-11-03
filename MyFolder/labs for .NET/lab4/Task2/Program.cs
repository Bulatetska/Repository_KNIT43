
using System;

class Student
{
    public string Surname { get; set; }
    public int Course { get; set; }
    public string RecordBook { get; set; }

    public Student(string surname, int course, string recordBook)
    {
        Surname = surname;
        Course = course;
        RecordBook = recordBook;
    }

    public virtual void Print()
    {
        Console.WriteLine("Прізвище: " + Surname);
        Console.WriteLine("Курс: " + Course);
        Console.WriteLine("Номер залікової книги: " + RecordBook);
    }
}

class Aspirant : Student
{
    public string Dissertation { get; set; }

    public Aspirant(string surname, int course,
                   string recordBook, string dissertation)
        : base(surname, course, recordBook)
    {
        Dissertation = dissertation;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine("Тема дисертації: " + Dissertation);
    }
}

class Program
{
    static void Main()
    {
        Student student = new Student("Іваненко", 3, "12345");

        Aspirant aspirant = new Aspirant(
            "Петренко", 1, "67890", "Штучний інтелект");

        Console.WriteLine("Студент:");
        student.Print();

        Console.WriteLine("\nАспірант:");
        aspirant.Print();
    }
}
