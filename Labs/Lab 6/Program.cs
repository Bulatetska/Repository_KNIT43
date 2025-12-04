using System;

class Vector
{
    public double X { get; set; }
    public double Y { get; set; }

    // Конструктор
    public Vector(double x = 0, double y = 0)
    {
        X = x;
        Y = y;
    }

    // --- Унарний мінус ---
    public static Vector operator -(Vector v)
    {
        return new Vector(-v.X, -v.Y);
    }

    // --- Додавання векторів ---
    public static Vector operator +(Vector a, Vector b)
    {
        return new Vector(a.X + b.X, a.Y + b.Y);
    }

    // --- Множення на скаляр (vector * scalar) ---
    public static Vector operator *(Vector v, double k)
    {
        return new Vector(v.X * k, v.Y * k);
    }

    // --- Множення на скаляр (scalar * vector) ---
    public static Vector operator *(double k, Vector v)
    {
        return new Vector(v.X * k, v.Y * k);
    }

    // --- Оператори рівності та нерівності ---
    public static bool operator ==(Vector a, Vector b)
    {
        return a.X == b.X && a.Y == b.Y;
    }

    public static bool operator !=(Vector a, Vector b)
    {
        return !(a == b);
    }

    // Обов’язково перевизначити Equals і GetHashCode
    public override bool Equals(object obj)
    {
        if (obj is Vector v)
            return this == v;
        return false;
    }

    public override int GetHashCode()
    {
        return (X, Y).GetHashCode();
    }

    // Довжина вектора
    public double Length()
    {
        return Math.Sqrt(X * X + Y * Y);
    }

    // Вивід вектора
    public void Print()
    {
        Console.WriteLine($"({X}, {Y})");
    }
}

class Program
{
    static void Main()
    {
        // Приклад з умови
        Vector v1 = new Vector(3, 4);
        Vector v2 = new Vector(1, -2);

        Console.WriteLine("Початкові вектори:");
        Console.Write("v1 = "); v1.Print();
        Console.Write("v2 = "); v2.Print();
        Console.WriteLine();

        // 1. Унарний мінус
        Console.WriteLine("Змінюємо знак у v1:");
        Vector v1_neg = -v1;
        v1_neg.Print();
        Console.WriteLine();

        // 2. Додавання
        Console.WriteLine("v1 + v2:");
        Vector sum = v1 + v2;
        sum.Print();
        Console.WriteLine();

        // 3. Множення на скаляр
        Console.WriteLine("v2 * 2:");
        Vector v2_mul = v2 * 2;
        v2_mul.Print();
        Console.WriteLine();

        // 4. Порівняння
        Console.WriteLine("v1 == v2 ?");
        Console.WriteLine(v1 == v2);
        Console.WriteLine();

        // Довжини векторів
        Console.WriteLine("Довжини векторів:");
        Console.WriteLine($"|v1| = {v1.Length()}");
        Console.WriteLine($"|v2| = {v2.Length()}");

        Console.ReadKey();
    }
}
