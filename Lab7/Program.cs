using System;

namespace Lab7
{
    // 🔹 Делегат, що приймає два double та повертає double
    public delegate double OperationDelegate(double a, double b);

    class MathOperations
    {
        // 🔹 Подія, яка спрацьовує після виконання операції
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

        // 🔹 Метод для виклику операції через делегат
        public double Execute(OperationDelegate operation, double a, double b)
        {
            double result = operation(a, b);
            OnOperationPerformed?.Invoke(result);
            return result;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            MathOperations math = new MathOperations();

            // 🔹 Підписуємося на подію (виводить результат)
            math.OnOperationPerformed += (result) =>
            {
                Console.WriteLine($"➡ Результат операції: {result}");
            };

            // 🔹 Створюємо делегат і додаємо методи
            OperationDelegate op = math.Add;
            op += math.Multiply; // групова адресація (multicast delegate)

            double a = 5, b = 3;

            Console.WriteLine("=== Виклик делегата з кількома методами ===");
            foreach (OperationDelegate single in op.GetInvocationList())
            {
                double result = single(a, b);
                Console.WriteLine($"Операція: {single.Method.Name}, результат = {result}");
            }

            // 🔹 Прибираємо метод Multiply
            op -= math.Multiply;

            Console.WriteLine("\n=== Після видалення Multiply ===");
            op(a, b);

            // 🔹 Лямбда: різниця квадратів
            OperationDelegate lambdaOp = (x, y) => (x * x) - (y * y);

            Console.WriteLine("\n=== Лямбда-операція: різниця квадратів ===");
            math.Execute(lambdaOp, a, b);

            // 🔹 Ще складніша лямбда: √(a² + b²)
            OperationDelegate pif = (x, y) => Math.Sqrt(x * x + y * y);

            Console.WriteLine("\n=== Λямбда: √(a² + b²) ===");
            math.Execute(pif, a, b);

            // 🔹 Інтерактивний режим
            Console.WriteLine("\n=== Інтерактивний режим ===");
            Console.Write("Введіть число 1: ");
            double x1 = double.Parse(Console.ReadLine());
            Console.Write("Введіть число 2: ");
            double x2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Оберіть операцію:\n1 — Додавання\n2 — Множення\n3 — Різниця квадратів\n4 — √(a² + b²)");
            Console.Write("Ваш вибір: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    math.Execute(math.Add, x1, x2);
                    break;
                case 2:
                    math.Execute(math.Multiply, x1, x2);
                    break;
                case 3:
                    math.Execute(lambdaOp, x1, x2);
                    break;
                case 4:
                    math.Execute(pif, x1, x2);
                    break;
                default:
                    Console.WriteLine("Невірний вибір!");
                    break;
            }
        }
    }
}
