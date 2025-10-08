using System;

namespace DelegatesAndEvents
{
    //оголошення делегата
    public delegate double OperationDelegate(double a, double b);

    //клас MathOperations
    class MathOperations
    {
        //подія, що спрацьовує після виконання операції
        public event EventHandler<double>? OnOperationPerformed;

        //методи для операцій
        public double Add(double a, double b)
        {
            double result = a + b;
            OnOperationPerformed?.Invoke(this, result);
            return result;
        }

        public double Multiply(double a, double b)
        {
            double result = a * b;
            OnOperationPerformed?.Invoke(this, result);
            return result;
        }

        //метод для виконання будь-якої операції через делегат
        public double ExecuteOperation(OperationDelegate op, double a, double b)
        {
            double result = op(a, b);
            OnOperationPerformed?.Invoke(this, result);
            return result;
        }
    }




    //основна програма
    class Program
    {
        static void Main(string[] args)
        {
            MathOperations math = new MathOperations();

            //підписуємося на подію
            math.OnOperationPerformed += (sender, result) =>
            {
                Console.WriteLine($"Результат операції: {result}");
            };

            //створюю делегати (делегат — це спеціальний тип, який зберігає адресу методу і дозволяє викликати цей метод через змінну, ніби метод — це дані)
            OperationDelegate del = math.Add;
            del += math.Multiply; // групова адресація (кілька методів)

            //введення від користувача
            Console.Write("Введіть число a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введіть число b: ");
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine("\nОберіть операцію:");
            Console.WriteLine("1 — Додавання");
            Console.WriteLine("2 — Множення");
            Console.WriteLine("3 — Різниця квадратів (лямбда)");
            Console.WriteLine("4 — Квадратний корінь із суми квадратів (лямбда)");

            Console.Write("Ваш вибір: ");
            int choice = int.Parse(Console.ReadLine());

            double result = 0;

            switch (choice)
            {
                case 1:
                    result = math.ExecuteOperation(math.Add, a, b);
                    break;
                case 2:
                    result = math.ExecuteOperation(math.Multiply, a, b);
                    break;
                case 3:
                    //лямбда для різниці квадратів
                    OperationDelegate diffSquares = (x, y) => x * x - y * y;
                    result = math.ExecuteOperation(diffSquares, a, b);
                    break;
                case 4:
                    //лямбда для кореня із суми квадратів
                    OperationDelegate sqrtSumSquares = (x, y) => Math.Sqrt(x * x + y * y);
                    result = math.ExecuteOperation(sqrtSumSquares, a, b);
                    break;
                default:
                    Console.WriteLine("Невірний вибір!");
                    return;
            }

            Console.WriteLine($"\nОстаточний результат: {result}");

            //демонстрація видалення методу з делегата (делегати можуть містити кілька методів, групова адресація)
            del -= math.Add;
            Console.WriteLine("\nМетод Add видалено з делегата.");
        }
    }
}
