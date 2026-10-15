using System;
using System.Globalization;

//Делегат для математичних операцій
public delegate double OperationDelegate(double a, double b);

//Делегат для обробки події
public delegate void OperationPerformedHandler(string operationName, double result);

class MathOperations
{
    public event OperationPerformedHandler? OnOperationPerformed;

    public double Add(double a, double b)
    {
        double result = a + b;

        OnOperationPerformed?.Invoke("Додавання", result);

        return result;
    }

    public double Multiply(double a, double b)
    {
        double result = a * b;

        OnOperationPerformed?.Invoke("Множення", result);

        return result;
    }

    //Метод виконання операції, переданої через делегат
    public double PerformCustomOperation(
        string operationName,
        double a,
        double b,
        OperationDelegate operation)
    {
        double result = operation(a, b);

        OnOperationPerformed?.Invoke(operationName, result);

        return result;
    }
}

class Program
{
    static void Main()
    {
        MathOperations math = new MathOperations();

        math.OnOperationPerformed += ShowOperationResult;

        while (true)
        {
            Console.WriteLine("\n===== МАТЕМАТИЧНІ ОПЕРАЦІЇ =====");
            Console.WriteLine("1. Додавання");
            Console.WriteLine("2. Множення");
            Console.WriteLine("3. Різниця квадратів (лямбда-вираз)");
            Console.WriteLine("4. Демонстрація делегата з кількома методами");
            Console.WriteLine("0. Вихід");
            Console.Write("Виберіть операцію: ");

            string? choice = Console.ReadLine();

            if (choice == "0")
            {
                Console.WriteLine("Завершення програми.");
                break;
            }

            if (choice != "1" && choice != "2" &&
                choice != "3" && choice != "4")
            {
                Console.WriteLine("Помилка! Виберіть пункт від 0 до 4.");
                continue;
            }

            double a = ReadDouble("Введіть перше число: ");
            double b = ReadDouble("Введіть друге число: ");

            switch (choice)
            {
                case "1":
                    //Передаємо метод Add через делегат
                    OperationDelegate addOperation = math.Add;

                    double sum = addOperation(a, b);

                    Console.WriteLine($"Результат додавання: {sum}");
                    break;

                case "2":
                    //Передаємо метод Multiply через делегат
                    OperationDelegate multiplyOperation = math.Multiply;

                    double product = multiplyOperation(a, b);

                    Console.WriteLine($"Результат множення: {product}");
                    break;

                case "3":
                    //Створюємо лямбда-вираз для різниці квадратів
                    OperationDelegate customOperation =
                        (x, y) => x * x - y * y;

                    double difference = math.PerformCustomOperation(
                        "Різниця квадратів",
                        a,
                        b,
                        customOperation
                    );

                    Console.WriteLine(
                        $"Різниця квадратів: {difference}"
                    );
                    break;

                case "4":
                    //Додаємо до делегата два методи
                    OperationDelegate combinedOperation = math.Add;
                    combinedOperation += math.Multiply;

                    Console.WriteLine(
                        "\nВиклик делегата з двома методами:"
                    );

                    double combinedResult = combinedOperation(a, b);

                    Console.WriteLine(
                        $"Повернуте значення делегата: {combinedResult}"
                    );

                    //Видаляємо метод Add із делегата
                    combinedOperation -= math.Add;

                    Console.WriteLine(
                        "\nПісля видалення методу Add:"
                    );

                    double remainingResult = combinedOperation(a, b);

                    Console.WriteLine(
                        $"Результат: {remainingResult}"
                    );
                    break;
            }
        }
    }

    static void ShowOperationResult(string operationName, double result)
    {
        Console.WriteLine(
            $"Подія OnOperationPerformed: {operationName}, результат = {result}"
        );
    }

    //Метод для введення дійсних чисел
    static double ReadDouble(string message)
    {
        while (true)
        {
            Console.Write(message);

            string? input = Console.ReadLine()?.Trim().Replace(',', '.');

            if (double.TryParse(
                input,
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out double number))
            {
                return number;
            }

            Console.WriteLine("Помилка! Введіть коректне число.");
        }
    }
}