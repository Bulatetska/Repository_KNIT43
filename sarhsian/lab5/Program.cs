using System.Text;
using Lab5Classes.Models;

namespace Lab5Classes;

internal static class Program
{
    private static void Main()
    {
        Console.InputEncoding = new UTF8Encoding(false);
        Console.OutputEncoding = new UTF8Encoding(false);

        while (true)
        {
            Console.WriteLine("\nЛаб 5. Класи");
            Console.WriteLine("1. Клас Person");
            Console.WriteLine("2. Класи Student та Aspirant");
            Console.WriteLine("3. Класи Book, BookGenre, BookGenrePubl");
            Console.WriteLine("4. Класи Figure, Rectangle, RectangleColor");
            Console.WriteLine("0. Вихід");
            Console.Write("Оберіть завдання: ");

            string? option = Console.ReadLine();
            Console.WriteLine();

            switch (option)
            {
                case "1": TaskOne(); break;
                case "2": TaskTwo(); break;
                case "3": TaskThree(); break;
                case "4": TaskFour(); break;
                case "0": return;
                default: Console.WriteLine("Оберіть пункт від 0 до 4."); break;
            }
        }
    }

    private static void TaskOne()
    {
        var person = new Person("Олександр", 20, "чоловіча", "+380501234567");
        Console.WriteLine("Початкові дані:");
        person.Print();

        person.ChangeName("Андрій");
        person.ChangeAge(21);
        person.ChangeGender("чоловіча");
        person.ChangePhoneNumber("+380671112233");

        Console.WriteLine("\nПісля виклику методів зміни даних:");
        person.Print();
    }

    private static void TaskTwo()
    {
        var student = new Student("Коваль", 3, "СТ-1045");
        var aspirant = new Aspirant("Шевченко", 1, "АС-2026", "Інтелектуальні системи аналізу даних");

        Console.WriteLine("Студент:");
        student.Print();
        Console.WriteLine("\nАспірант:");
        aspirant.Print();

        aspirant.Course = 2;
        Console.WriteLine("\nПісля зміни властивості Course аспіранта:");
        aspirant.Print();
    }

    private static void TaskThree()
    {
        Book[] books =
        {
            new Book("Кобзар", "Тарас Шевченко", 250m),
            new BookGenre("Лісова пісня", "Леся Українка", 180m, "драма-феєрія"),
            new BookGenrePubl("Тіні забутих предків", "Михайло Коцюбинський", 210m,
                "повість", "Фоліо")
        };

        Console.WriteLine("Інформація про книги:");
        foreach (Book book in books)
        {
            Console.WriteLine("------------------------------");
            book.Print(); // Поліморфізм: викликається Print() фактичного типу об'єкта.
        }
    }

    private static void TaskFour()
    {
        // Посилання базового класу Figure на об'єкти похідних класів.
        Figure figure = new Rectangle("Прямокутник", 1, 2, 6, 5);
        ShowFigure(figure);

        figure = new RectangleColor("Кольоровий прямокутник", 0, 0, 4, 3, "синій");
        ShowFigure(figure);

        Console.WriteLine("Прямокутник без параметрів:");
        var defaultRectangle = new Rectangle();
        defaultRectangle.Display();
        Console.WriteLine($"Площа: {defaultRectangle.Area():0.##}");

        Console.WriteLine("\nКольоровий прямокутник без параметрів:");
        var defaultColorRectangle = new RectangleColor();
        defaultColorRectangle.Display();
        Console.WriteLine($"Площа: {defaultColorRectangle.Area():0.##}");
    }

    private static void ShowFigure(Figure figure)
    {
        figure.Display(); // virtual/override: Display() викликається за фактичним типом.
        if (figure is Rectangle rectangle)
        {
            // Area() відсутній у Figure, тому звертаємось через похідний тип.
            Console.WriteLine($"Площа: {rectangle.Area():0.##}");
        }
        Console.WriteLine();
    }
}
