using System;

public delegate double OperationDelegate(double x, double y);

public class MathOperations
{
    public event Action<double> OperationCompleted;

    public double Sum(double x, double y)
    {
        double res = x + y;
        OperationCompleted?.Invoke(res);
        return res;
    }

    public double Product(double x, double y)
    {
        double res = x * y;
        OperationCompleted?.Invoke(res);
        return res;
    }
}

public class Program
{
    public static void Main()
    {
        MathOperations ops = new MathOperations();

        ops.OperationCompleted += value =>
            Console.WriteLine($"[Подія] Отримано результат: {value}");

        OperationDelegate multiOps = ops.Sum;
        multiOps += ops.Product;

        OperationDelegate diffOfSquares = (a, b) => Math.Abs(a * a - b * b);

        Console.WriteLine("1 - Сума");
        Console.WriteLine("2 - Множення");
        Console.WriteLine("3 - Різниця квадратів (лямбда)");
        Console.Write("Введіть номер операції: ");

        if (!int.TryParse(Console.ReadLine(), out int option))
        {
            Console.WriteLine("Помилка вводу!");
            return;
        }

        Console.Write("Перше число: ");
        double x = double.Parse(Console.ReadLine());

        Console.Write("Друге число: ");
        double y = double.Parse(Console.ReadLine());

        double outResult = 0;

        switch (option)
        {
            case 1:
                outResult = ops.Sum(x, y);
                break;

            case 2:
                outResult = ops.Product(x, y);
                break;

            case 3:
                outResult = diffOfSquares(x, y);
                Console.WriteLine($"Результат лямбда-операції: {outResult}");
                break;

            default:
                Console.WriteLine("Невідома операція!");
                return;
        }

        Console.WriteLine("\n Метод-список у делегаті перед видаленням Sum");
        foreach (var d in multiOps.GetInvocationList())
            Console.WriteLine("Метод: " + d.Method.Name);

        multiOps -= ops.Sum;

        Console.WriteLine("\n Після видалення Sum");
        foreach (var d in multiOps.GetInvocationList())
            Console.WriteLine("Метод: " + d.Method.Name);
    }
}
