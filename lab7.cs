using System;

class MathOperations
{
    public delegate double OperationDelegate(double a, double b);

    public event Action<string, double> OnOperationPerformed;

    public void RaiseEvent(string operation, double result)
    {
        OnOperationPerformed?.Invoke(operation, result);
    }
    public double Add(double a, double b)
    {
        double result = a + b;
        OnOperationPerformed?.Invoke($"Додавання {a} + {b}", result);
        return result;
    }

    public double Multiply(double a, double b)
    {
        double result = a * b;
        OnOperationPerformed?.Invoke($"Множення {a} * {b}", result);
        return result;
    }
}

class Program
{
    static void Main()
    {
        MathOperations math = new MathOperations();

        math.OnOperationPerformed += (operation, result) =>
        {
            Console.WriteLine($"Операція: {operation}");
            Console.WriteLine($"Результат: {result}");
            Console.WriteLine();
        };

        MathOperations.OperationDelegate operationDelegate = null;

        operationDelegate += math.Add;
        operationDelegate += math.Multiply;

        Console.WriteLine("Демонстрація делегатів:");
        double a = 3, b = 4;

        if (operationDelegate != null)
        {
            foreach (var op in operationDelegate.GetInvocationList())
            {
                var func = (MathOperations.OperationDelegate)op;
                func(a, b);
            }
        }

        operationDelegate -= math.Multiply;

        Console.WriteLine("Після видалення Multiply:");
        operationDelegate?.Invoke(a, b);
        Console.WriteLine();

        //лямбда
        MathOperations.OperationDelegate complexOp = (x, y) =>
        {
            double result = Math.Sqrt(x * x + y * y);
            math.RaiseEvent($"Квадратний корінь із суми квадратів {x} і {y}", result);
            return result;
        };

        Console.WriteLine("Використання лямбда-виразу: ");
        complexOp(5, 12);

        //вибір користувача
        Console.WriteLine("\n Інтерактивний режим: ");
        Console.Write("Введіть перше число: ");
        double num1 = double.Parse(Console.ReadLine());

        Console.Write("Введіть друге число: ");
        double num2 = double.Parse(Console.ReadLine());

        Console.WriteLine("Оберіть операцію: 1 - Додавання, 2 - Множення, 3 - Лямбда");
        string choice = Console.ReadLine();

        MathOperations.OperationDelegate selectedOp = null;

        switch (choice)
        {
            case "1":
                selectedOp = math.Add;
                break;
            case "2":
                selectedOp = math.Multiply;
                break;
            case "3":
                selectedOp = (x, y) =>
                {
                    double result = (x * x) - (y * y);
                    math.RaiseEvent($"Різниця квадратів {x} і {y}", result);
                    return result;
                };
                break;
            default:
                Console.WriteLine("Невірний вибір!");
                return;
        }

        selectedOp(num1, num2);
    }
}