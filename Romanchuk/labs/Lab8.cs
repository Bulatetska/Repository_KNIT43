using System;


class Program {

    class MathOperations
    {
        public static double Add(double a, double b)
        {
            OnOperationPerformed?.Invoke(null, new OperationPerformedEventArgs { Result = a + b });
            return a + b;
        }

        public static double Multiply(double a, double b)
        {
            OnOperationPerformed?.Invoke(null, new OperationPerformedEventArgs { Result = a * b });
            return a * b;
        }

        public delegate double SquareDifferenceDelegate(double a, double b);

        public delegate double OperationDelegate(double a, double b);

        public static event EventHandler<OperationPerformedEventArgs> OnOperationPerformed;

        public class OperationPerformedEventArgs : EventArgs
        {
            public double Result { get; set; }
        }

        public static void PrintOperationResult(object sender, MathOperations.OperationPerformedEventArgs e)
        {
            Console.WriteLine($"Result of operation: {e.Result}");
        }
    }
    

    static void Main(string[] args)
    {
        double num1 = 5.0;
        double num2 = 3.0;

        MathOperations.OperationDelegate OD; 
        MathOperations.OnOperationPerformed += MathOperations.PrintOperationResult;

        MathOperations.OperationDelegate GetSum = MathOperations.Add;
        MathOperations.OperationDelegate GetProduct = MathOperations.Multiply;
        MathOperations.SquareDifferenceDelegate squareDifference = (x, y) =>
        {   
            Console.WriteLine($"Result of operation: {x * x - y * y}");
            return x * x - y * y;
        };


        OD = GetSum;

        // Console.WriteLine(OD(num1, num2));
        OD(num1, num2);

        OD += GetProduct;        

        // Console.WriteLine(OD(num1, num2));
        OD(num1, num2);

        while (true)
        {
            Console.WriteLine("Enter two numbers separated by space (or type 'exit' to quit):");
            string input = Console.ReadLine();
            if (input.ToLower() == "exit")
                break;

            string[] parts = input.Split(' ');
            Console.WriteLine("Choose an operation: 1 for Add, 2 for Multiply, 3 for Square Difference");
            string operationChoice = Console.ReadLine();
            

            if (parts.Length == 2 && double.TryParse(parts[0], out double a) && double.TryParse(parts[1], out double b))
            {
                switch (operationChoice)
                {
                    case "1":
                        OD = GetSum;
                        OD(a, b);
                        break;
                    case "2":
                        OD = GetProduct;
                        OD(a, b);
                        break;
                    case "3":
                        squareDifference(a, b);
                        break;
                    default:
                        Console.WriteLine("Invalid operation choice.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter two valid numbers.");
            }

        }
    }
}