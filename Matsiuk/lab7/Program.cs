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

    public static Vector operator -(Vector v)
    {
        return new Vector(-v.X, -v.Y);
    }

    public static Vector operator +(Vector v1, Vector v2)
    {
        return new Vector(v1.X + v2.X, v1.Y + v2.Y);
    }

    public static bool operator ==(Vector v1, Vector v2)
    {
        if (ReferenceEquals(v1, v2))
            return true;

        if (v1 is null || v2 is null)
            return false;

        return v1.X == v2.X && v1.Y == v2.Y;
    }

    public static bool operator !=(Vector v1, Vector v2)
    {
        return !(v1 == v2);
    }

    public static Vector operator *(Vector v, double scalar)
    {
        return new Vector(v.X * scalar, v.Y * scalar);
    }

    public double Length()
    {
        return Math.Sqrt(X * X + Y * Y);
    }

    public void Display()
    {
        Console.WriteLine($"({X}, {Y})");
    }

    public override bool Equals(object? obj)
    {
        return obj is Vector v && this == v;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}

class Program
{
    static void Main()
    {
        Vector v1 = new Vector(3, 4);
        Vector v2 = new Vector(1, -2);

        Console.Write("Vector v1: ");
        v1.Display();

        Console.Write("Vector v2: ");
        v2.Display();

        Vector v3 = -v1;
        Console.Write("Unary minus (-v1): ");
        v3.Display();

        Vector v4 = v1 + v2;
        Console.Write("Addition (v1 + v2): ");
        v4.Display();

        Vector v5 = v2 * 2;
        Console.Write("Multiplication (v2 * 2): ");
        v5.Display();

        Console.WriteLine($"v1 == v2: {v1 == v2}");
        Console.WriteLine($"v1 != v2: {v1 != v2}");

        Console.WriteLine($"Length of v1: {v1.Length()}");
        Console.WriteLine($"Length of v2: {v2.Length()}");
    }
}