using System;

delegate double OperationDelegate(double a, double b);

class MathOperations
{
    public event Action<string, double>? OnOperationPerformed;

    public double Add(double a, double b)
    {
        double result = a + b;
        OnOperationPerformed?.Invoke("Addition", result);
        return result;
    }

    public double Multiply(double a, double b)
    {
        double result = a * b;
        OnOperationPerformed?.Invoke("Multiplication", result);
        return result;
    }

    public double ExecuteOperation(
        OperationDelegate operation, double a, double b)
    {
        double result = operation(a, b);
        OnOperationPerformed?.Invoke("Custom operation", result);
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
            Console.WriteLine($"{operation} result: {result}");
        };

        OperationDelegate operations = math.Add;
        operations += math.Multiply;

        Console.WriteLine("Choose an operation:");
        Console.WriteLine("1 - Addition");
        Console.WriteLine("2 - Multiplication");
        Console.WriteLine("3 - Difference of squares");
        Console.WriteLine("4 - Square root of sum of squares");

        Console.Write("Enter your choice: ");
        string? choice = Console.ReadLine();

        Console.Write("Enter the first number: ");
        string? firstInput = Console.ReadLine();

        if (!double.TryParse(firstInput, out double a))
        {
            Console.WriteLine("Invalid first number.");
            return;
        }

        Console.Write("Enter the second number: ");
        string? secondInput = Console.ReadLine();

        if (!double.TryParse(secondInput, out double b))
        {
            Console.WriteLine("Invalid second number.");
            return;
        }

        switch (choice)
        {
            case "1":
                math.Add(a, b);
                break;

            case "2":
                math.Multiply(a, b);
                break;

            case "3":
                OperationDelegate differenceOfSquares =
                    (x, y) => x * x - y * y;

                math.ExecuteOperation(differenceOfSquares, a, b);
                break;

            case "4":
                OperationDelegate rootOfSquares =
                    (x, y) => Math.Sqrt(x * x + y * y);

                math.ExecuteOperation(rootOfSquares, a, b);
                break;

            default:
                Console.WriteLine("Invalid operation.");
                break;
        }

        operations = (OperationDelegate?)Delegate.Remove(
            operations, (OperationDelegate)math.Multiply
        )!;
    }
}