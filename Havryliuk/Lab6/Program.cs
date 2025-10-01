using System;

namespace OperatorOverloading
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

        // Множення на скаляр
        public static Vector operator *(Vector v, double k)
        {
            return new Vector(v.X * k, v.Y * k);
        }

        public static Vector operator *(double k, Vector v)
        {
            return v * k; // виклик попереднього
        }

        // Оператор рівності
        public static bool operator ==(Vector v1, Vector v2)
        {
            if (ReferenceEquals(v1, v2)) return true;
            if (ReferenceEquals(v1, null) || ReferenceEquals(v2, null)) return false;
            return v1.X == v2.X && v1.Y == v2.Y;
        }

        // Оператор нерівності
        public static bool operator !=(Vector v1, Vector v2)
        {
            return !(v1 == v2);
        }

        // Перевизначаємо Equals і GetHashCode, якщо перевантажуємо ==
        public override bool Equals(object? obj)
        {
            if (obj is Vector other)
                return this == other;
            return false;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        // Метод довжини вектора
        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        // Метод для виводу
        public void Print()
        {
            Console.WriteLine($"({X}, {Y})");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector(3, 4);
            Vector v2 = new Vector(1, -2);

            Console.Write("v1 = "); v1.Print();
            Console.Write("v2 = "); v2.Print();

            // Унарний мінус
            Vector v1Neg = -v1;
            Console.Write("−v1 = "); v1Neg.Print();

            // Додавання
            Vector sum = v1 + v2;
            Console.Write("v1 + v2 = "); sum.Print();

            // Множення на скаляр
            Vector scaled = v2 * 2;
            Console.Write("v2 * 2 = "); scaled.Print();

            // Довжина вектора
            Console.WriteLine($"|v1| = {v1.Length()}");
            Console.WriteLine($"|v2| = {v2.Length()}");

            // Порівняння
            Console.WriteLine($"v1 == v2 ? { (v1 == v2) }");
            Console.WriteLine($"v1 != v2 ? { (v1 != v2) }");

            // Перевірка, що працює множення в іншому порядку
            Vector scaled2 = 3 * v1;
            Console.Write("3 * v1 = "); scaled2.Print();
        }
    }
}
