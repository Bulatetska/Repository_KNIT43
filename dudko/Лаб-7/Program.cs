using System;

// Делегат, який представляє будь-яку операцію з двома числами і повертає результат
public delegate double OperationDelegate(double a, double b);

// Делегат для події — викликається після виконання операції
public delegate void OperationPerformedHandler(double result);

public class MathOperations
{
    // Подія, яка викликається після виконання будь-якої операції
    public event OperationPerformedHandler OnOperationPerformed = delegate { };

    public double Add(double a, double b)
    {
        double result = a + b; // Обчислення
        OnOperationPerformed.Invoke(result); // Виклик події з результатом
        return result;
    }

    public double Multiply(double a, double b)
    {
        double result = a * b;
        OnOperationPerformed.Invoke(result);
        return result;
    }

    public double DifferenceOfSquares(double a, double b)
    {
        double result = (a * a) - (b * b);
        OnOperationPerformed.Invoke(result);
        return result;
    }
}

class Program
{
    static void Main()
    {
        MathOperations math = new MathOperations(); // Створення об’єкта з методами
        math.OnOperationPerformed += ShowResult; // Підписка на подію — виводимо результат

        Console.WriteLine("Введіть перше число:");
        double a = Convert.ToDouble(Console.ReadLine()); // Зчитуємо перше число

        Console.WriteLine("Введіть друге число:");
        double b = Convert.ToDouble(Console.ReadLine()); // Зчитуємо друге число

        // Виводимо меню для вибору
        Console.WriteLine("\nОберіть операцію:");
        Console.WriteLine("1 - Додавання (метод)");
        Console.WriteLine("2 - Множення (метод)");
        Console.WriteLine("3 - Різниця квадратів (метод)");
        Console.WriteLine("4 - Сума квадратів (АНОНІМНА ФУНКЦІЯ)");
        Console.WriteLine("5 - Корінь з суми квадратів (АНОНІМНА ФУНКЦІЯ)");
        string choice = Console.ReadLine(); // Зчитуємо вибір

        OperationDelegate operation; // Змінна для збереження вибраної операції

        // Перевіряємо вибір користувача
        if (choice == "1")
            operation = math.Add; // Посилання на метод додавання
        else if (choice == "2")
            operation = math.Multiply;
        else if (choice == "3")
            operation = math.DifferenceOfSquares;
        else if (choice == "4")
            operation = delegate(double x, double y) { return (x * x) + (y * y); }; // Анонімна функція замість окремого методу
        else if (choice == "5")
            operation = delegate(double x, double y) { return Math.Sqrt((x * x) + (y * y)); };
        else
        {
            Console.WriteLine("Невірний вибір!"); // Якщо неправильний варіант
            return;
        }

        // Виконуємо вибрану операцію
        operation(a, b);
    }

    // Метод-обробник для події — друкує результат
    static void ShowResult(double result)
    {
        Console.WriteLine($"Результат обчислення: {result}");
    }
}
