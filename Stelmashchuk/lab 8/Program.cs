using System;

namespace Lab8
{
    public delegate double OperationDelegate(double a, double b);
    public delegate void OperationPerformedHandler(string operationName, double a, double b, double result);

    public class MathOperations
    {
        public event OperationPerformedHandler? OnOperationPerformed;

        public double Add(double a, double b)
        {
            double result = a + b;
            OnOperationPerformed?.Invoke("Додавання (a + b)", a, b, result);
            return result;
        }

        public double Multiply(double a, double b)
        {
            double result = a * b;
            OnOperationPerformed?.Invoke("Множення (a * b)", a, b, result);
            return result;
        }

        public double ExecuteOperation(string name, OperationDelegate operation, double a, double b)
        {
            double result = operation(a, b);
            OnOperationPerformed?.Invoke(name, a, b, result);
            return result;
        }
    }

    class Program
    {
        static void DisplayOperationResult(string opName, double a, double b, double result)
        {
            Console.WriteLine($"{opName}: a = {a}, b = {b} => {result:F4}");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            MathOperations math = new MathOperations();
            math.OnOperationPerformed += DisplayOperationResult;

            double testA = 3.0;
            double testB = 4.0;

            Console.WriteLine("--- 1. Групова адресація (Add + Multiply) ---");
            OperationDelegate? multiDel = math.Add;
            multiDel += math.Multiply;

            if (multiDel != null)
            {
                foreach (OperationDelegate op in multiDel.GetInvocationList())
                {
                    op(testA, testB);
                }
            }

            Console.WriteLine("\n--- 2. Видалення методу Add (-=) ---");
            multiDel -= math.Add;
            multiDel?.Invoke(testA, testB);

            Console.WriteLine("\n--- 3. Лямбда-вирази ---");
            OperationDelegate diffOfSquares = (a, b) => a * a - b * b;
            math.ExecuteOperation("Різниця квадратів (a^2 - b^2)", diffOfSquares, testA, testB);

            OperationDelegate hypotenuse = (a, b) => Math.Sqrt(a * a + b * b);
            math.ExecuteOperation("Корінь суми квадратів sqrt(a^2 + b^2)", hypotenuse, testA, testB);

            Console.WriteLine("\n--- 4. Інтерактивний вибір операції ---");
            Console.Write("Введіть a: ");
            if (!double.TryParse(Console.ReadLine(), out double userA))
                userA = 5.0;

            Console.Write("Введіть b: ");
            if (!double.TryParse(Console.ReadLine(), out double userB))
                userB = 12.0;

            Console.WriteLine("Оберіть: 1 - Add, 2 - Multiply, 3 - Різниця квадратів, 4 - Корінь, 5 - Сума кубів");
            Console.Write("Ваш вибір (1-5): ");

            string? choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    OperationDelegate addDel = math.Add;
                    addDel(userA, userB);
                    break;
                case "2":
                    OperationDelegate mulDel = math.Multiply;
                    mulDel(userA, userB);
                    break;
                case "3":
                    math.ExecuteOperation("Різниця квадратів (a^2 - b^2)", (a, b) => a * a - b * b, userA, userB);
                    break;
                case "4":
                    math.ExecuteOperation("Корінь суми квадратів sqrt(a^2 + b^2)", (a, b) => Math.Sqrt(a * a + b * b), userA, userB);
                    break;
                case "5":
                    math.ExecuteOperation("Сума кубів (a^3 + b^3)", (a, b) => Math.Pow(a, 3) + Math.Pow(b, 3), userA, userB);
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Виконуємо додавання:");
                    math.Add(userA, userB);
                    break;
            }
        }
    }
}
