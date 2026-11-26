using System.Globalization;
using System.Text;
using Lab6Abstract.Models;

namespace Lab6Abstract;

internal static class Program
{
    private static void Main()
    {
        Console.InputEncoding = new UTF8Encoding(false);
        Console.OutputEncoding = new UTF8Encoding(false);

        while (true)
        {
            Console.WriteLine("\nЛаб 6. Абстрактний клас");
            Console.WriteLine("1. Трикутник");
            Console.WriteLine("2. Кольоровий трикутник");
            Console.WriteLine("0. Вихід");
            Console.Write("Оберіть завдання: ");
            string? choice = Console.ReadLine();
            if (choice == "0" || choice is null) return;
            if (choice != "1" && choice != "2")
            {
                Console.WriteLine("Оберіть пункт від 0 до 2.");
                continue;
            }

            double a = ReadSide("a");
            double b = ReadSide("b");
            double c = ReadSide("c");

            Figure figure;
            if (choice == "1")
            {
                figure = new Triangle("Трикутник", a, b, c);
            }
            else
            {
                Console.Write("Введіть колір: ");
                string? color = Console.ReadLine();
                var triangle = new TriangleColor("Кольоровий трикутник", a, b, c, "білий");
                if (!string.IsNullOrWhiteSpace(color)) triangle.Color = color.Trim();
                figure = triangle;
            }

            Console.WriteLine();
            figure.Print();
            Console.WriteLine($"Площа (Area): {figure.Area():0.###}");
            Console.WriteLine($"Площа (Area2): {figure.Area2:0.###}");
        }
    }

    private static double ReadSide(string name)
    {
        while (true)
        {
            Console.Write($"Введіть сторону {name}: ");
            string? input = Console.ReadLine();
            if (input is null) Environment.Exit(0);
            if (double.TryParse(input!.Replace(',', '.'), NumberStyles.Float,
                CultureInfo.InvariantCulture, out double value) && double.IsFinite(value))
                return value;
            Console.WriteLine("Введіть коректне число.");
        }
    }
}
