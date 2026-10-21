
using System;

class Vector
{
    public double X { get; set; }
    public double Y { get; set; }

    // Конструктор
    public Vector(double x, double y)
    {
        X = x;
        Y = y;
    }

    // Унарний мінус
    public static Vector operator -(Vector v)
    {
        return new Vector(-v.X, -v.Y);
    }

    // Додавання двох векторів
    public static Vector operator +(Vector v1, Vector v2)
    {
        return new Vector(v1.X + v2.X, v1.Y + v2.Y);
    }

    // Множення вектора на число
    public static Vector operator *(Vector v, double scalar)
    {
        return new Vector(v.X * scalar, v.Y * scalar);
    }

    // Множення числа на вектор
    public static Vector operator *(double scalar, Vector v)
    {
        return v * scalar;
    }

    // Порівняння на рівність
    public static bool operator ==(Vector v1, Vector v2)
    {
        if (ReferenceEquals(v1, v2))
            return true;

        if (v1 is null || v2 is null)
            return false;

        return v1.X == v2.X && v1.Y == v2.Y;
    }

    // Порівняння на нерівність
    public static bool operator !=(Vector v1, Vector v2)
    {
        return !(v1 == v2);
    }

    // Перевизначення Equals та GetHashCode
    public override bool Equals(object obj)
    {
        return obj is Vector v && this == v;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    // Обчислення довжини вектора
    public double Length()
    {
        return Math.Sqrt(X * X + Y * Y);
    }

    // Виведення вектора
    public void Print()
    {
        Console.WriteLine($"({X}; {Y})");
    }
}

class Program
{
    static void Main()
    {
        Vector v1 = new Vector(3, 4);
        Vector v2 = new Vector(1, -2);

        Console.Write("Вектор v1: ");
        v1.Print();

        Console.Write("Вектор v2: ");
        v2.Print();

        // Унарний мінус
        Vector v3 = -v1;
        Console.Write("Протилежний до v1: ");
        v3.Print();

        // Додавання
        Vector sum = v1 + v2;
        Console.Write("Сума v1 + v2: ");
        sum.Print();

        // Множення на скаляр
        Vector product = v2 * 2;
        Console.Write("Вектор v2 * 2: ");
        product.Print();

        // Довжина вектора
        Console.WriteLine($"Довжина v1: {v1.Length()}");
        Console.WriteLine($"Довжина v2: {v2.Length()}");

        // Порівняння векторів
        Console.WriteLine($"v1 == v2: {v1 == v2}");
        Console.WriteLine($"v1 != v2: {v1 != v2}");

        // Перевірка рівності однакових векторів
        Vector v4 = new Vector(3, 4);
        Console.WriteLine($"v1 == v4: {v1 == v4}");
    }
}
