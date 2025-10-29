using System;

class Vector
{
    public double X { get; set; }
    public double Y { get; set; }

    public Vector(double x, double y)
    {
        X = x;
        Y = y;
    }

    // Перевантаження унарного мінусаz
    public static Vector operator -(Vector v)
    {
        return new Vector(-v.X, -v.Y);
    }

    // Перевантаження додавання двох векторів
    public static Vector operator +(Vector a, Vector b)
    {
        return new Vector(a.X + b.X, a.Y + b.Y);
    }

    // Перевантаження множення на скаляр
    public static Vector operator *(Vector v, double scalar)
    {
        return new Vector(v.X * scalar, v.Y * scalar);
    }

    // Перевантаження множення скаляра на вектор (з іншого боку)
    public static Vector operator *(double scalar, Vector v)
    {
        return new Vector(v.X * scalar, v.Y * scalar);
    }

    // Перевантаження операторів рівності та нерівності
    public static bool operator ==(Vector a, Vector b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
        return a.X == b.X && a.Y == b.Y;
    }

    public static bool operator !=(Vector a, Vector b)
    {
        return !(a == b);
    }

    public override bool Equals(object obj)
    {
        if (obj is Vector v)
            return this == v;
        return false;
    }

    public override int GetHashCode()
    {
        return X.GetHashCode() ^ Y.GetHashCode();
    }

    public double Length()
    {
        return Math.Sqrt(X * X + Y * Y);
    }

    public void Print()
    {
        Console.WriteLine($"({X}, {Y})");
    }
}

class Program
{
    static void Main()
    {
        Vector v1 = new Vector(3, 4);
        Vector v2 = new Vector(1, -2);

        Console.WriteLine("Початкові вектори:");
        Console.Write("v1 = "); v1.Print();
        Console.Write("v2 = "); v2.Print();
        Console.WriteLine();

        Vector negV1 = -v1;
        Console.WriteLine("Після унарного мінуса:");
        Console.Write("−v1 = "); negV1.Print();
        Console.WriteLine();

        Vector sum = v1 + v2;
        Console.WriteLine("Сума векторів:");
        Console.Write("v1 + v2 = "); sum.Print();
        Console.WriteLine();

        Vector scaled = v2 * 2;
        Console.WriteLine("Множення вектора v2 на скаляр 2:");
        Console.Write("v2 * 2 = "); scaled.Print();
        Console.WriteLine();

        Console.WriteLine("Порівняння векторів:");
        Console.WriteLine($"v1 == v2 → {v1 == v2}");
        Console.WriteLine($"v1 != v2 → {v1 != v2}");
        Console.WriteLine();

        Console.WriteLine("Довжини векторів:");
        Console.WriteLine($"|v1| = {v1.Length():F2}");
        Console.WriteLine($"|v2| = {v2.Length():F2}");
    }
}