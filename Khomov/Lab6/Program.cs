public class Vector
{
    public double X { get; set; }
    public double Y { get; set; }

    public Vector(double x, double y)
    {
        X = x;
        Y = y;
    }

    // Зміна знаків координат
    public static Vector operator -(Vector v)
    {
        return new Vector(-v.X, -v.Y);
    }

    // Додавання двох векторів
    public static Vector operator +(Vector v1, Vector v2)
    {
        return new Vector(v1.X + v2.X, v1.Y + v2.Y);
    }

    // Порівняння на рівність
    public static bool operator ==(Vector v1, Vector v2)
    {
        if (ReferenceEquals(v1, null) && ReferenceEquals(v2, null))
            return true;
        if (ReferenceEquals(v1, null) || ReferenceEquals(v2, null))
            return false;

        return v1.X == v2.X && v1.Y == v2.Y;
    }

    // Порівняння на нерівність
    public static bool operator !=(Vector v1, Vector v2)
    {
        return !(v1 == v2);
    }

    // Множення на скаляр
    public static Vector operator *(Vector v, double scalar)
    {
        return new Vector(v.X * scalar, v.Y * scalar);
    }

    // Обчислення довжини
    public double Length()
    {
        return Math.Sqrt(X * X + Y * Y);
    }

    // Перезапис методу ToString() для зручного виведення об'єкту
    public override string ToString()
    {
        return $"({X}, {Y})";
    }

    public override bool Equals(object o)
    {
        if (o is not Vector v) return false;
        return X == v.X && Y == v.Y;
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

        Console.WriteLine($"v1 = {v1}");
        Console.WriteLine($"v2 = {v2}");

        // Зміна знаків координат
        Vector negV1 = -v1;
        Console.WriteLine($"-v1 = {negV1}");

        // Додавання векторів
        Vector sum = v1 + v2;
        Console.WriteLine($"v1 + v2 = {sum}");

        // Множення на скаляр
        Vector scaled = v2 * 2;
        Console.WriteLine($"v2 * 2 = {scaled}");

        // Порівняння
        Console.WriteLine($"v1 == v2: {v1 == v2}");
        Console.WriteLine($"v1 != v2: {v1 != v2}");

        // Довжини векторів
        Console.WriteLine($"|v1| = {v1.Length():F2}");
        Console.WriteLine($"|v2| = {v2.Length():F2}");
    }
}