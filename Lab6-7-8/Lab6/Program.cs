using System;

// Задача:
// Створити клас Vector, який представляє вектор на площині з координатами (x, y).
public class Vector
{
    public double X { get; set; }
    public double Y { get; set; }

    // Реалізувати конструктор, який ініціалізує координати вектора.
    public Vector(double x, double y)
    {
        this.X = x;
        this.Y = y;
    }

    // Перевантажити наступні оператори:

    // Унарний мінус(-) для зміни знаків координат вектора.
    public static Vector operator -(Vector operand) => new Vector(-operand.X, -operand.Y);
    
    // Бінарний оператор додавання (+) для додавання двох векторів (додавати відповідні координати).
    public static Vector operator +(Vector left, Vector right) => new Vector(left.X + right.X, left.Y + right.Y);
    
    // Оператор рівності (==) та нерівності (!=) для порівняння двох векторів (вектори рівні, якщо їхні координати однакові).
    public static bool operator ==(Vector left, Vector right)
    {
        // Перевірка на null для безпеки
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.X == right.X && left.Y == right.Y;
    }
    
    public static bool operator !=(Vector left, Vector right) => !(left == right);
    
    // Оператор множення (*) - додамо обидва варіанти: вектор * скаляр та скаляр * вектор
    public static Vector operator *(Vector left, double right) => new Vector(left.X * right, left.Y * right);
    public static Vector operator *(double left, Vector right) => new Vector(left * right.X, left * right.Y);

    // Перевизначити методи Equals та GetHashCode для коректної роботи з колекціями
    public override bool Equals(object obj)
    {
        return this == (obj as Vector);
    }

    public override int GetHashCode()
    {
        return (X, Y).GetHashCode();
    }

    // Реалізувати методи для виведення вектора на екран та отримання його довжини.
    public void Print()
    {
        Console.WriteLine("({0}, {1})", X, Y);
    }

    public double Length()
    {
        return Math.Sqrt(X * X + Y * Y);
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

        // Вивести довжину вектора v1
        Console.WriteLine("Довжина v1 = {0:F2}", v1.Length());

        // Змінити знаки координат вектора v1.
        Console.Write("-v1 = ");
        (-v1).Print();

        // Додати вектори v1 і v2.
        Console.Write("v1 + v2 = ");
        (v1 + v2).Print();

        // Помножити вектор v1 на скаляр 2.
        Console.Write("v1 * 2 = ");
        (v1 * 2).Print();

        // Помножити скаляр 3 на вектор v2
        Console.Write("3 * v2 = ");
        (3 * v2).Print();

        // Порівняти два вектори на рівність.
        Console.WriteLine("v1 == v2 = {0}", v1 == v2);
        Console.WriteLine("v1 != v2 = {0}", v1 != v2);

        // Додаткові тести
        var v3 = new Vector(3, 4);
        Console.WriteLine("v1 == v3 (такі самі координати) = {0}", v1 == v3);
    }
}