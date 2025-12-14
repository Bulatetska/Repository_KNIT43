using System;

namespace DelegatesAndEvents
{
    // Делегат, який приймає два double і повертає double
    public delegate double OperationDelegate(double a, double b);

    // Клас MathOperations
    public class MathOperations
    {
        // Подія, яка спрацьовує після виконання операції
        public event Action<double, string> OnOperationPerformed;

        // Методи додавання і множення
        public double Add(double a, double b)
        {
            double result = a + b;
            OnOperationPerformed?.Invoke(result, "Add");
            return result;
        }

        public double Multiply(double a, double b)
        {
            double result = a * b;
            OnOperationPerformed?.Invoke(result, "Multiply");
            return result;
        }

        // Метод для виклику делегата
        public double ExecuteOperation(double a, double b, OperationDelegate operation)
        {
            return operation(a, b);
        }
    }

    class Program
    {
        static void Main()
        {
            MathOperations math = new MathOperations();

            // Обробник події
            math.OnOperationPerformed += (result, opName) =>
            {
                Console.WriteLine($"Operation {opName} performed. Result = {result:F2}");
            };

            // Створення делегата і додавання методів
            OperationDelegate op = null;
            op += math.Add;
            op += math.Multiply;

            double x = 5;
            double y = 3;

            Console.WriteLine($"Executing delegate with x={x}, y={y}:");
            foreach (OperationDelegate d in op.GetInvocationList())
            {
                double res = d(x, y); // Виклик кожного методу
            }

            // Видалення методу Multiply
            op -= math.Multiply;

            Console.WriteLine("\nAfter removing Multiply method:");
            foreach (OperationDelegate d in op.GetInvocationList())
            {
                double res = d(x, y);
            }

            // Лямбда-вираз для обчислення різниці квадратів
            OperationDelegate diffSquares = (a, b) => a * a - b * b;
            double diffResult = diffSquares(x, y);
            Console.WriteLine($"\nDifference of squares ({x}^2 - {y}^2) = {diffResult:F2}");

            // Лямбда-вираз для обчислення квадратного кореня суми квадратів
            OperationDelegate sqrtSumSquares = (a, b) => Math.Sqrt(a * a + b * b);
            double sqrtResult = sqrtSumSquares(x, y);
            Console.WriteLine($"Square root of sum of squares (sqrt({x}^2 + {y}^2)) = {sqrtResult:F2}");

            
            
        }
    }
}
