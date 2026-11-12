using System;
using System.Globalization;
using System.Text;

namespace LabEightDelegates;

internal static class Program
{
    private static void Main()
    {
        Console.OutputEncoding = new UTF8Encoding(false);
        MathOperations math = new MathOperations();
        math.OnOperationPerformed += ShowOperationResult;

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Лабораторна робота 8. Делегати, лямбда-вирази та події");
            Console.WriteLine("1. Додавання двох чисел (делегат)");
            Console.WriteLine("2. Множення двох чисел (делегат)");
            Console.WriteLine("3. Різниця квадратів (лямбда-вираз)");
            Console.WriteLine("4. Багатоадресний делегат: += та -=");
            Console.WriteLine("5. Корінь із суми квадратів (лямбда-вираз)");
            Console.WriteLine("0. Вихід");
            Console.Write("Оберіть завдання: ");
            string? choice = Console.ReadLine();

            if (choice == "0")
            {
                Console.WriteLine("Роботу завершено.");
                break;
            }

            if (choice != "1" && choice != "2" && choice != "3" &&
                choice != "4" && choice != "5")
            {
                Console.WriteLine("Невірний пункт меню.");
                continue;
            }

            double a = ReadDouble("Введіть число a: ");
            double b = ReadDouble("Введіть число b: ");

            switch (choice)
            {
                case "1":
                {
                    OperationDelegate operation = math.Add;
                    operation(a, b);
                    break;
                }
                case "2":
                {
                    OperationDelegate operation = math.Multiply;
                    operation(a, b);
                    break;
                }
                case "3":
                {
                    OperationDelegate operation = (x, y) => x * x - y * y;
                    math.PerformCustom("Різниця квадратів", operation, a, b);
                    break;
                }
                case "4":
                {
                    OperationDelegate operations = math.Add;
                    operations += math.Multiply;
                    Console.WriteLine("Виклик двох методів через делегат:");
                    double lastResult = operations(a, b);
                    Console.WriteLine($"Повернуте значення делегата: {Format(lastResult)}");

                    operations -= math.Multiply;
                    Console.WriteLine("Після видалення методу Multiply:");
                    operations(a, b);
                    break;
                }
                case "5":
                {
                    OperationDelegate operation = (x, y) => Math.Sqrt(x * x + y * y);
                    math.PerformCustom("Корінь із суми квадратів", operation, a, b);
                    break;
                }
            }
        }
    }

    private static double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = (Console.ReadLine() ?? "").Trim().Replace(',', '.');
            bool isNumber = double.TryParse(input, NumberStyles.Float,
                CultureInfo.InvariantCulture, out double value);

            if (isNumber && !double.IsInfinity(value) && !double.IsNaN(value))
                return value;

            Console.WriteLine("Введіть коректне число, наприклад 2,5 або 2.5.");
        }
    }

    private static void ShowOperationResult(object? sender, OperationPerformedEventArgs e)
    {
        Console.WriteLine($"{e.OperationName}: {Format(e.Result)}");
    }

    private static string Format(double value)
    {
        return value.ToString("G12", CultureInfo.InvariantCulture);
    }
}
