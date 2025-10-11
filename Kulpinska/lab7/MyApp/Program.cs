using System;

public delegate double OperationDelegate(double a, double b);

public class MathOperations
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

public class Program
{
    public static void Main()
    {
        MathOperations mathOps = new MathOperations();

        mathOps.OnOperationPerformed += r => Console.WriteLine($"[Подія] Результат операції: {r}");

        OperationDelegate operations = mathOps.Add;
        operations += mathOps.Multiply;

        OperationDelegate sqrtSumSquares = (x, y) => Math.Sqrt(x * x + y * y);

        Console.WriteLine("=== Вибір користувача ===");
        Console.WriteLine("1 — Додавання");
        Console.WriteLine("2 — Множення");
        Console.WriteLine("3 — Кв. корінь суми квадратів (лямбда)");
        Console.Write("Ваш вибір: ");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Введіть перше число: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Введіть друге число: ");
        double b = double.Parse(Console.ReadLine());

        double finalResult = 0;

        switch (choice)
        {
            case 1:
                finalResult = mathOps.Add(a, b);
                break;
            case 2:
                finalResult = mathOps.Multiply(a, b);
                break;
            case 3:
                finalResult = sqrtSumSquares(a, b);
                Console.WriteLine($"Результат (лямбда): {finalResult}");
                break;
            default:
                Console.WriteLine("Невірний вибір!");
                break;
        }

        Console.WriteLine("\n=== Групова адресація перед видаленням Add ===");
        foreach (OperationDelegate op in operations.GetInvocationList())
        {
            Console.WriteLine($"Метод у делегаті: {op.Method.Name}");
        }

        operations -= mathOps.Add;

        Console.WriteLine("\n=== Після видалення Add ===");
        foreach (OperationDelegate op in operations.GetInvocationList())
        {
            Console.WriteLine($"Метод у делегаті: {op.Method.Name}");
        }
    }
}
