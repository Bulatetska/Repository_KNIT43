using System;

delegate double OperationDelegate(double a, double b);

class MathOperations
{
    public event Action<string, double> OnOperationPerformed;

    public double Add(double a, double b)
    {
        double r = a + b;
        OnOperationPerformed("Додавання", r);
        return r;
    }

    public double Multiply(double a, double b)
    {
        double r = a * b;
        OnOperationPerformed("Множення", r);
        return r;
    }

    public double Other(OperationDelegate op, double a, double b)
    {
        double r = op(a, b);
        OnOperationPerformed("Різниця квадратів", r);
        return r;
    }
}

class Program
{
    static void Show(string name, double result)
    {
        Console.WriteLine(name + ": " + result);
    }

    static void Main()
    {
        MathOperations math = new MathOperations();

        math.OnOperationPerformed += Show;

        OperationDelegate op = math.Add;

        op += math.Multiply;

        Console.WriteLine("Делегат з двома методами:");
        op(3, 4);

        op -= math.Multiply;

        Console.WriteLine("\nПісля видалення Multiply:");
        op(3, 4);

        Console.WriteLine("\n1 - Додавання");
        Console.WriteLine("2 - Множення");
        Console.WriteLine("3 - Різниця квадратів");

        Console.Write("Оберіть операцію: ");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Введіть a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Введіть b: ");
        double b = double.Parse(Console.ReadLine());

        if (choice == 1)
        {
            op = math.Add;
            op(a, b);
        }
        else if (choice == 2)
        {
            op = math.Multiply;
            op(a, b);
        }
        else if (choice == 3)
        {
            op = (x, y) => x * x - y * y;
            math.Other(op, a, b);
        }
    }
}