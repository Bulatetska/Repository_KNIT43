using System;

namespace ConsoleApp
{
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

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }

        public static Vector operator *(Vector v, double scalar)
        {
            return new Vector(v.X * scalar, v.Y * scalar);
        }

        public static bool operator ==(Vector a, Vector b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(Vector a, Vector b)
        {
            return !(a == b);
        }

        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public void Display()
        {
            Console.WriteLine($"({X}, {Y})");
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector v)
                return X == v.X && Y == v.Y;
            return false;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }

    class Program
    {
        static void Main()
        {
            Vector v1 = new Vector(3, 4);
            Vector v2 = new Vector(1, -2);

            Console.Write("Початковий вектор v1 = ");
            v1.Display();
            Console.Write("Початковий вектор v2 = ");
            v2.Display();

            Console.WriteLine($"\nДовжина v1 = {v1.Length():F2}");
            Console.WriteLine($"Довжина v2 = {v2.Length():F2}");

            Vector negV1 = -v1;
            Console.Write("\nПісля унарного мінуса v1 = ");
            negV1.Display();

            Vector sum = v1 + v2;
            Console.Write("v1 + v2 = ");
            sum.Display();

            Vector scaled = v2 * 2;
            Console.Write("v2 * 2 = ");
            scaled.Display();

            Console.WriteLine($"\nЧи рівні v1 і v2? -> {(v1 == v2 ? "Так" : "Ні")}");


        }
    }
}
