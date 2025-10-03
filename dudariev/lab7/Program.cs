// Мета:
// Навчитися використовувати делегати для передачі методів, реалізовувати лямбда-вирази та обробляти події.

// Задача:
// Створити клас MathOperations, який включає наступні методи:
class MathOperations
{
    // Add(double a, double b) – додає два числа.
    public double Add(double a, double b)
    {
        double result = a + b;
        InvokeOperationPerformed("додавання", a, b, result);
        return result;
    }

    // Multiply(double a, double b) – множить два числа.
    public double Multiply(double a, double b)
    {
        double result = a * b;
        InvokeOperationPerformed("множення", a, b, result);
        return result;
    }

    // Створити подію OnOperationPerformed для класу MathOperations, яка спрацьовує після виконання математичної операції.
    public void InvokeOperationPerformed(string name, double a, double b, double result)
    {
        OnOperationPerformed?.Invoke(this, new() { Name = name, A = a, B = b, Result = result });
    }

    public event EventHandler<OperationPerformedEventArgs>? OnOperationPerformed;

    public class OperationPerformedEventArgs : EventArgs
    {
        public required string Name { get; set; }
        public double A { get; set;  }
        public double B { get; set; }
        public double Result { get; set; }
    }
}

// Оголосити делегат типу OperationDelegate, який посилається на метод, що приймає два параметри типу double і повертає double.
delegate double OperationDelegate(double a, double b);

class Program
{
    public static void Main(string[] args)
    {
        // Приклад:
        // Створити екземпляр класу MathOperations.
        var math = new MathOperations();

        // Реалізувати обробники подій для виведення результату операції.
        math.OnOperationPerformed += (sender, e) => Console.WriteLine("Результат операції '{0}' над {1} та {2} рівний {3}", e.Name, e.A, e.B, e.Result);

        // Використати лямбда-вираз для виконання складніших операцій, наприклад, знаходження різниці квадратів двох чисел.
        OperationDelegate lambdaOp = (a, b) => {
            double result = a * a - b * b;
            math.InvokeOperationPerformed("різниця квадратів", a, b, result);
            return result;
        };

        {
            // Перевантажити делегат, щоб він міг посилатися на кілька методів одночасно. Використати групову адресацію для додавання і видалення методів.
            // Додати методи додавання і множення до делегата.
            OperationDelegate? op = null;
            op += math.Add;
            op += math.Multiply;

            // Викликати операції через делегат.
            Console.WriteLine("Add + Multiply (3, 4)");
            op(3, 4);

            // Використати лямбда-вираз для виконання специфічної операції (наприклад, обчислення квадратного кореня суми квадратів двох чисел).
            Console.WriteLine("a * a - b * b (3, 4)");
            lambdaOp(3, 4);

            Console.WriteLine();
        }

        // Тестова програма повинна дозволяти користувачу вибирати операцію (додавання, множення або інша операція, яку можна виконати з допомогою лямбда-виразу), виконувати її і виводити результат.
        while (true)
        {
            Console.WriteLine("Виберіть операцію:");
            Console.WriteLine("1 - додавання");
            Console.WriteLine("2 - множення");
            Console.WriteLine("3 - різниця квадратів");
            string? Line = Console.ReadLine();
            OperationDelegate op;
            switch (Line)
            {
                case "1":
                    op = math.Add;
                    break;
                case "2":
                    op = math.Multiply;
                    break;
                case "3":
                    op = lambdaOp;
                    break;
                default:
                    Console.WriteLine("Невірна операція");
                    return;
            }

            Console.Write("Введіть перше число: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введіть друге число: ");
            double b = double.Parse(Console.ReadLine());

            op(a, b);
            Console.WriteLine();
        }
    }
}