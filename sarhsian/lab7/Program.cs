using System.Globalization;
using System.Text;

namespace Lab7Operators;

internal static class Program
{
    private static void Main()
    {
        Console.InputEncoding = new UTF8Encoding(false);
        Console.OutputEncoding = new UTF8Encoding(false);
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        while (true)
        {
            Console.WriteLine("\nЛаб 7. Перевантаження операторів");
            Console.WriteLine("1. Приклад з умови");
            Console.WriteLine("2. Ввести власні вектори");
            Console.WriteLine("0. Вихід");
            Console.Write("Оберіть завдання: ");
            string? choice = Console.ReadLine();
            if (choice is null or "0") return;

            switch (choice)
            {
                case "1":
                    Demonstrate(new Vector(3, 4), new Vector(1, -2), 2);
                    break;
                case "2":
                    try
                    {
                        var v1 = new Vector(ReadNumber("x1"), ReadNumber("y1"));
                        var v2 = new Vector(ReadNumber("x2"), ReadNumber("y2"));
                        double k = ReadNumber("Скаляр");
                        Demonstrate(v1, v2, k);
                    }
                    catch (EndOfStreamException) { return; }
                    break;
                default:
                    Console.WriteLine("Оберіть пункт від 0 до 2.");
                    break;
            }
        }
    }

    private static void Demonstrate(Vector v1, Vector v2, double k)
    {
        Console.Write("\nv1 = "); v1.Print();
        Console.Write("v2 = "); v2.Print();
        Console.WriteLine($"-v1 = {-v1}");
        Console.WriteLine($"v1 + v2 = {v1 + v2}");
        Console.WriteLine($"v2 * {k:G} = {v2 * k}");
        Console.WriteLine($"v1 == v2: {(v1 == v2 ? "так" : "ні")}");
        Console.WriteLine($"v1 != v2: {(v1 != v2 ? "так" : "ні")}");
        Console.WriteLine($"Довжина v1: {v1.Length():0.###}");
        Console.WriteLine($"Довжина v2: {v2.Length():0.###}");
    }

    private static double ReadNumber(string label)
    {
        while (true)
        {
            Console.Write($"{label}: ");
            string? input = Console.ReadLine();
            if (input is null) throw new EndOfStreamException();
            if (double.TryParse(input.Replace(',', '.'), NumberStyles.Float,
                CultureInfo.InvariantCulture, out double number) && double.IsFinite(number))
                return number;
            Console.WriteLine("Введіть коректне число.");
        }
    }
}
