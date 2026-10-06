using System;

class Vector
{
    public double X;
    public double Y;

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

    public static Vector operator *(Vector v, double number)
    {
        return new Vector(v.X * number, v.Y * number);
    }

    public static bool operator ==(Vector v1, Vector v2)
    {
        return v1.X == v2.X && v1.Y == v2.Y;
    }

    public static bool operator !=(Vector v1, Vector v2)
    {
        return v1.X != v2.X || v1.Y != v2.Y;
    }

    public override bool Equals(object obj)
    {
        Vector v = (Vector)obj;
        return X == v.X && Y == v.Y;
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public void Display()
    {
        Console.WriteLine("(" + X + ", " + Y + ")");
    }

    public double GetLength()
    {
        return Math.Sqrt(X * X + Y * Y);
    }
}

class Program
{
    static void Main()
    {
        Vector v1 = new Vector(3, 4);
        Vector v2 = new Vector(1, -2);
        Vector v3 = new Vector(3, 4);

        Console.Write("v1 = ");
        v1.Display();

        Console.Write("v2 = ");
        v2.Display();

        Console.Write("v3 = ");
        v3.Display();

        Console.Write("-v1 = ");
        (-v1).Display();

        Console.Write("v1 + v2 = ");
        (v1 + v2).Display();

        Console.Write("v2 * 2 = ");
        (v2 * 2).Display();

        Console.WriteLine("Довжина v1 = " + v1.GetLength());
        Console.WriteLine("Довжина v2 = " + v2.GetLength());

        Console.WriteLine("v1 == v2: " + (v1 == v2));
        Console.WriteLine("v1 != v2: " + (v1 != v2));
        Console.WriteLine("v1 == v3: " + (v1 == v3));
    }
}