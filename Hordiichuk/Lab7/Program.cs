using System;

class Program
{
    static void Main(string[] args)
    {
        MathOperations math = new MathOperations();

        math.OnOperationPerformed += Math_OnOperationPerformed;

        Console.WriteLine("--- Демонстрація групової адресації (Multicast) ---");
        DemonstrateMulticasting(math);
        Console.WriteLine("--------------------------------------------------\n");
        RunCalculatorLoop(math);
        Console.WriteLine("Роботу завершено.");
    }
    private static void Math_OnOperationPerformed(object sender, OperationEventArgs e)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"[ПОДІЯ]: Операція '{e.OperationName}' виконана. Результат: {e.Result}");
        Console.ResetColor();
    }

    private static void DemonstrateMulticasting(MathOperations math)
    {
        Console.WriteLine("1. Створюємо делегат 'op' і прив'язуємо до Add:");
        OperationDelegate op = math.Add;
        double result = op(10, 5);
        Console.WriteLine($"* Результат (з делегата): {result}\n");

        Console.WriteLine("2. Додаємо метод Multiply до того ж делегата (op += ...):");
        op += math.Multiply;
        result = op(20, 10);
        Console.WriteLine($"* Результат (з делегата, останній у ланцюжку): {result}\n");

        Console.WriteLine("3. Видаляємо метод Add з делегата (op -= ...):");
        op -= math.Add;
        result = op(7, 3);
        Console.WriteLine($"* Результат (з делегата): {result}\n");
    }
    private static void RunCalculatorLoop(MathOperations math)
    {
        while (true)
        {
            Console.WriteLine("Оберіть операцію:");
            Console.WriteLine("1: Додавання");
            Console.WriteLine("2: Множення");
            Console.WriteLine("3: Різниця квадратів (Лямбда-вираз)");
            Console.WriteLine("0: Вихід");
            Console.Write("> ");

            string choice = Console.ReadLine();

            if (choice == "0")
            {
                break;
            }

            if (choice != "1" && choice != "2" && choice != "3")
            {
                Console.WriteLine("Невірний ввід, спробуйте ще раз.\n");
                continue;
            }

            try
            {
                Console.Write("Введіть перше число (a): ");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введіть друге число (b): ");
                double b = Convert.ToDouble(Console.ReadLine());

                switch (choice)
                {
                    case "1":
                        math.Add(a, b);
                        break;

                    case "2":
                        math.Multiply(a, b);
                        break;

                    case "3":
                        math.PerformOperation(a, b, (x, y) => (x * x) - (y * y), "Різниця квадратів");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Помилка: {ex.Message}. Спробуйте ще раз.");
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
}