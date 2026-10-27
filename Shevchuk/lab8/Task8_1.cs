using System;
using System.Globalization;

delegate double OperationDelegate(double a, double b);

class OperationEventArgs : EventArgs
{
    public string Name { get; }
    public double A { get; }
    public double B { get; }
    public double Result { get; }

    public OperationEventArgs(string name, double a, double b, double result)
    {
        Name = name;
        A = a;
        B = b;
        Result = result;
    }
}

// 1. Клас з математичними операціями
class MathOperations
{
    public event EventHandler<OperationEventArgs> OnOperationPerformed;
    public double Add(double a, double b)
    {
        double result = a + b;
        RaiseEvent("Додавання", a, b, result);
        return result;
    }
    public double Multiply(double a, double b)
    {
        double result = a * b;
        RaiseEvent("Множення", a, b, result);
        return result;
    }

    // Виконання будь-якої операції, переданої через делегат (наприклад, лямбда-виразу)
    public double Execute(string name, OperationDelegate operation, double a, double b)
    {
        double result = operation(a, b);
        RaiseEvent(name, a, b, result);
        return result;
    }

    // Метод, що викликає подію (якщо на неї хтось підписаний)
    protected virtual void RaiseEvent(string name, double a, double b, double result)
    {
        OnOperationPerformed?.Invoke(this, new OperationEventArgs(name, a, b, result));
    }
}

static class Task8_1
{
    static int operationsCount = 0;

    static void PrintResult(object sender, OperationEventArgs e)
    {
        Console.WriteLine($"  [Подія] {e.Name}: a = {e.A}, b = {e.B}, результат = {e.Result:0.####}");
    }

    static void CountOperations(object sender, OperationEventArgs e)
    {
        operationsCount++;
        Console.WriteLine($"  [Подія] Всього виконано операцій: {operationsCount}");
    }

    static double ReadNumber(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (input != null)
            {
                input = input.Replace(',', '.');
                if (double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
                    return value;
            }
            Console.WriteLine("Помилка: введіть число.");
        }
    }

    // 3. Демонстрація групової адресації делегата
    static void DemoMulticast(MathOperations mo, double a, double b)
    {
        Console.WriteLine("\n--- Групова адресація ---");

        OperationDelegate del = mo.Add;   
        del += mo.Multiply;              
        Console.WriteLine($"У списку делегата методів: {del.GetInvocationList().Length}");

        double last = del(a, b);
        Console.WriteLine($"Результат виклику делегата (останній метод): {last:0.####}");

        Console.WriteLine("Результати кожного методу окремо:");
        foreach (OperationDelegate d in del.GetInvocationList())
        {
            Console.WriteLine($"  {d.Method.Name}: {d(a, b):0.####}");
        }

        del -= mo.Add;                 
        Console.WriteLine($"Після видалення Add у списку методів: {del.GetInvocationList().Length}");
        Console.WriteLine($"Виклик делегата: {del(a, b):0.####}");
    }

    public static void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        MathOperations mo = new MathOperations();

        mo.OnOperationPerformed += PrintResult;
        mo.OnOperationPerformed += CountOperations;

        OperationDelegate diffSquares = (a, b) => a * a - b * b;

        OperationDelegate hypotenuse = (a, b) =>
        {
            double sum = a * a + b * b;
            return Math.Sqrt(sum);
        };

        while (true)
        {
            Console.WriteLine("\n========== МЕНЮ ==========");
            Console.WriteLine("1 - Додавання (a + b)");
            Console.WriteLine("2 - Множення (a * b)");
            Console.WriteLine("3 - Різниця квадратів (a² - b²) - лямбда");
            Console.WriteLine("4 - Корінь із суми квадратів √(a² + b²) - лямбда");
            Console.WriteLine("5 - Групова адресація делегата (Add + Multiply)");
            Console.WriteLine("0 - Вихід");
            Console.Write("Ваш вибір: ");
            string choice = Console.ReadLine();

            if (choice == "0")
            {
                Console.WriteLine("Програму завершено.");
                break;
            }

            if (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5")
            {
                Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                continue;
            }

            double x = ReadNumber("Введіть a: ");
            double y = ReadNumber("Введіть b: ");
            double result;

            switch (choice)
            {
                case "1":
                    // Виклик через делегат
                    OperationDelegate add = mo.Add;
                    result = add(x, y);
                    Console.WriteLine($"Результат: {result:0.####}");
                    break;
                case "2":
                    OperationDelegate mult = mo.Multiply;
                    result = mult(x, y);
                    Console.WriteLine($"Результат: {result:0.####}");
                    break;
                case "3":
                    result = mo.Execute("Різниця квадратів", diffSquares, x, y);
                    Console.WriteLine($"Результат: {result:0.####}");
                    break;
                case "4":
                    result = mo.Execute("Корінь із суми квадратів", hypotenuse, x, y);
                    Console.WriteLine($"Результат: {result:0.####}");
                    break;
                case "5":
                    DemoMulticast(mo, x, y);
                    break;
            }
        }
    }
}
