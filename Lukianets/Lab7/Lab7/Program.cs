using System;

namespace DelegateEventDemo
{
    // 1️ Оголошення делегата
    public delegate double OperationDelegate(double a, double b);

    // 2️ Клас MathOperations
    class MathOperations
    {
        // Подія, що спрацьовує після виконання операції
        public event Action<double> OnOperationPerformed;

        // Метод додавання
        public double Add(double a, double b)
        {
            double result = a + b;
            OnOperationPerformed?.Invoke(result);
            return result;
        }

        // Метод множення
        public double Multiply(double a, double b)
        {
            double result = a * b;
            OnOperationPerformed?.Invoke(result);
            return result;
        }

        // Додатковий метод для виклику події з лямбда-виразів
        public void PerformCustomOperation(double result)
        {
            OnOperationPerformed?.Invoke(result);
        }
    }

    // 3️ Тестова програма
    class Program
    {
        static void Main()
        {
            MathOperations math = new MathOperations();

            // Обробник події
            math.OnOperationPerformed += result =>
            {
                Console.WriteLine($"Результат операції: {result}\n");
            };

            // Делегати
            OperationDelegate operations = math.Add;
            operations += math.Multiply;

            // Лямбда-вираз для різниці квадратів
            OperationDelegate lambdaOp = (a, b) =>
            {
                double result = (a * a) - (b * b);
                math.PerformCustomOperation(result); // Виклик через метод
                return result;
            };

            while (true)
            {
                Console.WriteLine("Виберіть операцію:");
                Console.WriteLine("1 — Додавання");
                Console.WriteLine("2 — Множення");
                Console.WriteLine("3 — Різниця квадратів (лямбда)");
                Console.WriteLine("4 — Вихід");
                Console.Write("Ваш вибір: ");
                string choice = Console.ReadLine();

                if (choice == "4") break;

                Console.Write("\nВведіть перше число: ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("Введіть друге число: ");
                double b = double.Parse(Console.ReadLine());

                double result = 0;

                switch (choice)
                {
                    case "1":
                        result = math.Add(a, b);
                        break;
                    case "2":
                        result = math.Multiply(a, b);
                        break;
                    case "3":
                        result = lambdaOp(a, b);
                        break;
                    default:
                        Console.WriteLine("Невірний вибір!");
                        break;
                }
            }

            Console.WriteLine("\nПрограму завершено. Натисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }
}
