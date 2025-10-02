// Мета:
// Закріпити знання про перевантаження унарних та бінарних операторів у C#, навчитися реалізовувати перевантаження операторів для різних типів об’єктів.

// Задача:
// Створити клас Vector, який представляє вектор на площині з координатами (x, y).
class Vector
{
    double x;
    double y;

    // Реалізувати конструктор, який ініціалізує координати вектора.
    public Vector(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    // Перевантажити наступні оператори:

    // Унарний мінус(-) для зміни знаків координат вектора.
    public static Vector operator -(Vector operand) => new(-operand.x, -operand.y);
    // Бінарний оператор додавання (+) для додавання двох векторів (додавати відповідні координати).
    public static Vector operator +(Vector left, Vector right) => new(left.x + right.x, left.y + right.y);
    // Оператор рівності (==) та нерівності (!=)** для порівняння двох векторів (вектори рівні, якщо їхні координати однакові).
    public static bool operator ==(Vector left, Vector right) => left.x == right.x && left.y == right.y;
    public static bool operator !=(Vector left, Vector right) => !(left == right);
    // Оператор множення (*)
    public static Vector operator *(Vector left, double right) => new(left.x * right, left.y * right);

    // Реалізувати методи для виведення вектора на екран та отримання його довжини.

    public void Print()
    {
        Console.WriteLine("({0}, {1})", x, y);
    }

    public double Length()
    {
        return Math.Sqrt(x * x + y * y);
    }
}

// Написати тестову програму, яка створює кілька векторів, виконує з ними операції та виводить результати.
class Program
{
    static void Main(string[] args)
    {
        // Приклад:
        // Створити два вектори v1 = (3, 4) та v2 = (1, -2).
        var v1 = new Vector(3, 4);
        var v2 = new Vector(1, -2);
        Console.Write("v1 = ");
        v1.Print();
        Console.Write("v2 = ");
        v2.Print();

        // Змінити знаки координат вектора v1.
        Console.Write("-v1 = ");
        (-v1).Print();

        // Додати вектори v1 і v2.
        Console.Write("v1 + v2 = ");
        (v1 + v2).Print();

        // Помножити вектор v2 на скаляр 2.
        Console.Write("v1 * 2 = ");
        (v1 * 2).Print();

        // Порівняти два вектори на рівність.
        Console.WriteLine("v1 == v2 = {0}", v1 == v2);
        Console.WriteLine("v1 != v2 = {0}", v1 != v2);
    }
}