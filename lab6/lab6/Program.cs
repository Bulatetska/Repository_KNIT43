using System;

namespace ConsoleApp
{
    class Vector
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Vector(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Vector operator -(Vector v)
        {
            return new Vector(-v.X, -v.Y);
        }


        public static Vector operator +(Vector left, Vector right)
        {
            return new Vector(left.X + right.X, left.Y + right.Y);
        }

        public static Vector operator *(Vector v, double k)
        {
            return new Vector(v.X * k, v.Y * k);
        }

        public static bool operator ==(Vector a, Vector b)
        {
            if (object.ReferenceEquals(a, b))
                return true;

            if (a is null || b is null)
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

        public void Print()
        {
            Console.WriteLine($"({X}, {Y})");
        }

        public override bool Equals(object obj)
        {
            return obj is Vector v && v.X == X && v.Y == Y;
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
            Vector first = new Vector(3, 4);
            Vector second = new Vector(1, -2);

            Console.Write("Початковий v1 = ");
            first.Print();

            Console.Write("Початковий v2 = ");
            second.Print();

            Console.WriteLine($"\nДовжина first = {first.Length():F2}");
            Console.WriteLine($"Довжина second = {second.Length():F2}");

            Vector inverted = -first;
            Console.Write("\nПісля унарного мінуса first = ");
            inverted.Print();

            Vector sum = first + second;
            Console.Write("first + second = ");
            sum.Print();

            Vector scaled = second * 2;
            Console.Write("second * 2 = ");
            scaled.Print();

            Console.WriteLine($"\nЧи рівні first і second? -> {(first == second ? "Так" : "Ні")}");
        }
    }
}
