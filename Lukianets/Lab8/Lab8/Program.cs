using System;
using PersonClass;
using StudentClasses;
using BookClasses;
using FigureClasses;

class Program
{
    static void Main()
    {
        // === Task 1: Person ===
        Person p = new Person("Alice", 25, "Female", "+380501234567");
        p.Print();
        Console.WriteLine();

        // === Task 2: Student and Aspirant ===
        Student s = new Student("Ivanov", 2, "RB12345");
        s.Print();
        Aspirant a = new Aspirant("Petrov", 3, "RB54321");
        a.Print();
        Console.WriteLine();

        // === Task 3: Book hierarchy ===
        Book b = new Book("War and Peace", "Tolstoy L.", 20.5);
        b.Print();
        BookGenre bg = new BookGenre("1984", "Orwell G.", 15.0, "Dystopia");
        bg.Print();
        BookGenrePubl bgp = new BookGenrePubl("Harry Potter", "Rowling J.", 25.0, "Fantasy", "Bloomsbury");
        bgp.Print();
        Console.WriteLine();

        // === Task 4: Figure hierarchy ===
        Figure f = new Figure("Generic Figure");
        f.Display();
        Console.WriteLine();

        Figure rect = new Rectangle(0, 0, 4, 5, "My Rectangle");
        rect.Display();
        Console.WriteLine($"Area: {(rect as Rectangle).Area()}");
        Console.WriteLine();

        Figure coloredRect = new RectangleColor(1, 1, 6, 7, "My Colored Rectangle", "Blue");
        coloredRect.Display();
        Console.WriteLine($"Area: {(coloredRect as RectangleColor).Area()}");
    }
}
