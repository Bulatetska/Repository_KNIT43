
using System;

delegate double OperationDelegate(double a, double b);

class MathOperations
{
    public event Action<double> OnOperationPerformed;

    public double Add(double a, double b)
    {
        double result = a + b;
        OnOperationPerformed?.Invoke(result);
        return result;
    }

    public double Multiply(double a, double b)
    {
        double result = a * b;
        OnOperationPerformed?.Invoke(result);
        return result;
    }
}

class Program
{
    static void Main()
    {
        MathOperations math = new MathOperations();

        math.OnOperationPerformed += ShowResult;

        OperationDelegate operation = math.Add;

        operation += math.Multiply;

        // Демонстрація додавання та видалення методів
        operation -= math.Multiply;

        Console.Write("Введіть перше число: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть друге число: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("1 - Додавання");
        Console.WriteLine("2 - Множення");
        Console.WriteLine("3 - Різниця квадратів");

        Console.Write("Виберіть операцію: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
        {
            operation = math.Add;
        }
        else if (choice == 2)
        {
            operation = math.Multiply;
        }
        else if (choice == 3)
        {
            operation = (x, y) => x * x - y * y;
        }
        else
        {
            Console.WriteLine("Невірний вибір!");
            return;
        }

        double result = operation(a, b);

        if (choice == 3)
        {
            Console.WriteLine("Результат: " + result);
        }
    }

    static void ShowResult(double result)
    {
        Console.WriteLine("Результат операції: " + result);
    }
}
