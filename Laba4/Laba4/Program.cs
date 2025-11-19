using System;

class Person
{/*
Розробити клас Person, який містить відповідні члени для зберігання:
імені, віку, статі і телефонного номера.
Напишіть функції-члени, які зможуть змінювати ці члени даних індивідуально. 
Напишіть функцію-член Person :: Print (),яка виводить відформатовані дані про людину.*/
    private string name;
    private int age;
    private string gender;
    private string phoneNum;
    public Person()
    {
        name = "Unknown";
        age = 0;
        gender = "Unknown";
        phoneNum = "Unknown";
    }
    public Person(string name, int age, string gender, string phoneNum)
    {
        this.name = name;
        this.age = age;
        this.gender = gender;
        this.phoneNum = phoneNum;
    }
    public void SetName(string NewName)
    {
        this.name = NewName;
    }
    public void SetAge(int NewAge)
    {
        if (age < 0) { Console.WriteLine("Age cannot be negative.");
        }
        else
        {
            this.age = NewAge;
        }
    }
    public void SetGender(string NewGender)
    {
        this.gender = NewGender;
    }
    public void SetPhoneNum(string NewPhoneNum)
    {
        this.phoneNum = NewPhoneNum;
    }
    public void Print()
    {
        Console.WriteLine("\nPerson Info");
        Console.WriteLine("Name: " + this.name);
        Console.WriteLine("Age: " + this.age);
        Console.WriteLine("Phone Number: " + this.phoneNum);
    }
}
public class Student
{
    protected string surname;
    protected int course;
    protected string StudentID;
    public Student(string surname, int course, string StudentID)
    {
        this.surname = surname;
        this.course = course;
        this.StudentID = StudentID;
        Console.WriteLine("Student created with (string surname, int course, string StudentID) .");
    }
    public string Surname
    {
        get { return surname; }
        set { surname = value; }
    }
    public int Course
    {
        get { return course; }
        set { course = (value > 0) ? value : course; }
    }
    public string StudentIDProp
    {
        get { return StudentID; }
        set { StudentID = value; }
    }
    public void Print()
    {
        Console.WriteLine("\nStudent Info");
        Console.WriteLine("Surname: " + this.surname);
        Console.WriteLine("Course: " + this.course);
        Console.WriteLine("Student ID: " + this.StudentID);

    }
}
public class Aspirant : Student
{
    protected string DissTop;
    public Aspirant(string surname, int course, string StdentID, string DissTop)
        :base(surname, course, StdentID)
    {
        this.DissTop = DissTop;
        Console.WriteLine("Aspirant created with (string surname, int course, string StdentID, string DissTop) .");
    }
    public string DissTopGS
    {
        get { return DissTop; }
        set { DissTop = value; }
    }
    public new void Print()
    {
        base.Print();
        Console.WriteLine("Dissertation Topic: " + this.DissTop);
    }
}
public class Book
{
    protected string title;
    protected string author;
    protected int price;
    public Book(string title, string author, int price)
    {
        this.title = title;
        this.author = author;
        this.price = price;

    }
    public string Title
    {
        get { return title; }
        set { title = value; }
    }
    public string Author
    {
        get { return author; }
        set { author = value; }
    }
    public int Price
    {
        get { return price; }
        set { price = (value > 0) ? value : price; }
    }
    public void Print()
    {
        Console.WriteLine("\nBook Info");
        Console.WriteLine("Title:" + this.title);
        Console.WriteLine("Author: " + this.author);
        Console.WriteLine("Price: " + this.price);
    }

}
public class BookGenre: Book
{
    protected string genre;
    public BookGenre(string title, string author, int prise, string genre)
        :base(title, author , prise)
    {
        this.genre = genre;
    }
    public string Genre
    {
        get { return genre; }
        set { genre = value; }
    }
    public new void Print()
    {
        base.Print();
        Console.WriteLine("Genre: " + this.genre);
    }
}
public sealed class BookGenrePuble:BookGenre 
{
    protected string publisher;
    public BookGenrePuble(string title, string author, int price, string genre, string publisher)
            : base(title, author, price, genre)
    { this.publisher = publisher; }
    public string Publisher
    {
        get { return publisher; }
        set { publisher = value; }
    }
    public new void Print()
    {
        base.Print();
        Console.WriteLine("Publisher: " + this.publisher);
    }
  }
public class Figure
{
    protected string name;
    public Figure(string name)
    {
        this.name = name;
    }
    public virtual void  Display()
    {
       Console.WriteLine("Figure Name: " + this.name);
    }

}
public class Rectangle: Figure
{
    protected double x1, x2, y1, y2;
    public Rectangle() :this("Rectangle",0,0,1,1)
    {

    }
    public Rectangle( string name, double x1, double y1, double x2, double y2)
        :base(name)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }
    public override void Display()
    {
        base.Display();
        Console.WriteLine($"{"Координати:"} ({x1}, {y1} ,{x2}, {y2})");
    }
    public double Area()
    {
        return Math.Abs((x2 - x1) * (y2 - y1));
    }

}
public class RectangeleColor : Rectangle
{
    protected string color;
    public RectangeleColor() : this("Rectangle", 0, 0, 1, 1,"Red")
    {
    }
    public RectangeleColor(string name, double x1, double y1, double x2, double y2, string color)
        : base( name, x1, y1, x2, y2)
    {
        this.color = color;
    }
    public override void Display()
    {
        base.Display();
        Console.WriteLine($"{"Color:"} {color}");
    }
    public new double Area()
    {
        return base.Area();
    }
}
class Program
{
    static void Main(string[] args)
    {   Console.WriteLine("First Task");
        // Демонстація роботи класу за замовчуванням
        Person person1 = new Person();
        person1.Print();
        // Демонстрація роботи класу з параметрами
        Person person2 = new Person("Yana", 30, "Male", "+88888888");
        person2.Print();
        // Демонстрація роботи функцій-членів для зміни даних
        Person person3 = new Person();
        person3.SetName("Anna");
        person3.SetAge(25);
        person3.SetGender("Female");
        person3.SetPhoneNum("+77777777");
        person3.Print();

        Console.WriteLine("\nSecond Task");
        // Демонстрація роботи класу Student та вивід ф-ції Print()
        Student student = new Student("Smith", 2, "S12345");
        student.Print();
        // Демонстрація роботи класу Aspirant та вивід ф-ції Print() де осовна частина ф-ції взята з класу Student
        Aspirant aspirant = new Aspirant("Johnson", 3, "A67890", "Artificial Intelligence");
        aspirant.Print();

        Console.WriteLine("\n Third Task");
        // Демонстрація роботи класу Book та вивід ф-ції Print()
        Book book= new Book("Kobzar", "Taras Shevchenko", 300);
        book.Print();
        // Демонстрація роботи класу BookGenre та вивід ф-ції Print
        BookGenre genre = new BookGenre("1984", "George Orwell", 250, "Dystopian");
        genre.Print();
        // Демонстрація роботи класу BookGenrePuble та вивід ф-ції Print
        BookGenrePuble puble = new BookGenrePuble("The sweetnes at the bottom of the pie","Alan Brendly", 400, "Detecrive","Old Lion");
        puble.Print();

        Console.WriteLine("\n Fourth Task");
        // Посилання на базовий клас Figure
        Figure refFg;

        // Створення об'єктів
        Rectangle Rect = new Rectangle("Rectangle", 2.5, 3.5, 7.5, 8.5);
        RectangeleColor Rectcolor = new RectangeleColor("Rectangle Color", 1.0, 2.0, 6.0, 5.0, "Red");

        // 1. Поліморфний виклик Display
        refFg = Rect;
        Console.WriteLine("Виклик Display через посилання Figure ,фактично Rectangle:");
        refFg.Display(); 

        // 2. Поліморфний виклик Display
        refFg = Rectcolor;
        Console.WriteLine("\nВиклик Display через посилання Figure, фактично RectangleColor:");
        refFg.Display(); 

       
        Console.WriteLine($"\nПлоща objRect: {Rect.Area()}");
        Console.WriteLine($"Площа objRectColor: {Rectcolor.Area()}");
        Console.WriteLine("Якщо не використовувати virtual and override то змінній refFg буде просто писвоюватися значення. Наприклад  refFg = Rect; Вивід буде Rect");
    }
}