using System;

class Vector
{
    private double x;
    private double y;

    public Vector(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public double X
    {
        get { return x; }
        set { x = value; }
    }

    public double Y
    {
        get { return y; }
        set { y = value; }
    }

    // 1. Унарний мінус
    public static Vector operator -(Vector v)
    {
        return new Vector(-v.x, -v.y);
    }

    // 2. Бінарне додавання
    public static Vector operator +(Vector v1, Vector v2)
    {
        return new Vector(v1.x + v2.x, v1.y + v2.y);
    }

    // 3. Множення на скаляр (з обох боків)
    public static Vector operator *(Vector v, double scalar)
    {
        return new Vector(v.x * scalar, v.y * scalar);
    }

    public static Vector operator *(double scalar, Vector v)
    {
        return new Vector(v.x * scalar, v.y * scalar);
    }

    // 4. Оператори рівності та нерівності
    public static bool operator ==(Vector? v1, Vector? v2)
    {
        if (ReferenceEquals(v1, v2)) return true;
        if (v1 is null || v2 is null) return false;

        return v1.x == v2.x && v1.y == v2.y;
    }

    public static bool operator !=(Vector? v1, Vector? v2)
    {
        return !(v1 == v2);
    }

    public override bool Equals(object? obj)
    {
        if (obj is Vector other)
            return this == other;
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, y);
    }

    public double Length()
    {
        return Math.Sqrt(x * x + y * y);
    }

    public void Print(string name)
    {
        Console.WriteLine($"{name} = ({x:F2}; {y:F2})");
    }

    public override string ToString()
    {
        return $"({x}; {y})";
    }
}

class Task7_1
{
    public static void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("\n=== Лабораторна робота: Перевантаження операторів (Клас Vector) ===\n");

        // 1. Створення векторів
        Vector v1 = new Vector(3, 4);
        Vector v2 = new Vector(1, -2);

        v1.Print("Початковий v1");
        Console.WriteLine($"Довжина v1: {v1.Length():F2}");

        v2.Print("Початковий v2");
        Console.WriteLine($"Довжина v2: {v2.Length():F2}\n");

        // 2. Унарний мінус: зміна знаків
        Vector v1Neg = -v1;
        v1Neg.Print("-v1 (зміна знаків)");
        Console.WriteLine();

        // 3. Додавання векторів: v1 + v2
        Vector sum = v1 + v2;
        sum.Print("v1 + v2");
        Console.WriteLine();

        // 4. Множення вектора v2 на скаляр 2
        Vector scaled = v2 * 2;
        scaled.Print("v2 * 2");
        Console.WriteLine();

        // 5. Порівняння векторів на рівність
        Console.WriteLine("--- Перевірка на рівність (== та !=) ---");
        Console.WriteLine($"v1 == v2: {v1 == v2}");
        Console.WriteLine($"v1 != v2: {v1 != v2}");

        Vector v3 = new Vector(3, 4);
        v3.Print("v3");
        Console.WriteLine($"v1 == v3: {v1 == v3}");
    }
}
