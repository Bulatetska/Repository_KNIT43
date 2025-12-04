using System;

namespace OperatorOverloadingExample
{
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

        // Множення на скаляр
        public static Vector operator *(Vector v, double scalar)
        {
            return new Vector(v.X * scalar, v.Y * scalar);
        }

        // Порівняння рівності
        public static bool operator ==(Vector v1, Vector v2)
        {
            if (ReferenceEquals(v1, null) || ReferenceEquals(v2, null))
                return false;
            return v1.X == v2.X && v1.Y == v2.Y;
        }

        // Порівняння нерівності
        public static bool operator !=(Vector v1, Vector v2)
        {
            return !(v1 == v2);
        }

        // Перевизначення Equals та GetHashCode (рекомендується при перевантаженні ==)
        public override bool Equals(object? obj)

        {
            if (obj is Vector other)
                return this == other;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        // Метод для виведення
        public void Print()
        {
            Console.WriteLine($"Вектор: ({X}, {Y})");
        }

        // Метод для отримання довжини вектора
        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y);
        }
    }

    // === Тестова програма ===
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Створення векторів
            Vector v1 = new Vector(3, 4);
            Vector v2 = new Vector(1, -2);

            Console.WriteLine("=== Початкові вектори ===");
            v1.Print();
            v2.Print();

            // Унарний мінус
            Vector v1Neg = -v1;
            Console.WriteLine("\nПісля унарного мінуса (v1 -> -v1):");
            v1Neg.Print();

            // Додавання
            Vector v3 = v1 + v2;
            Console.WriteLine("\nРезультат додавання (v1 + v2):");
            v3.Print();

            // Множення на скаляр
            Vector v4 = v2 * 2;
            Console.WriteLine("\nРезультат множення (v2 * 2):");
            v4.Print();

            // Порівняння
            Console.WriteLine("\n=== Порівняння векторів ===");
            Console.WriteLine($"v1 == v2 → {v1 == v2}");
            Console.WriteLine($"v1 != v2 → {v1 != v2}");

            // Довжини
            Console.WriteLine("\n=== Довжини векторів ===");
            Console.WriteLine($"|v1| = {v1.Length():F2}");
            Console.WriteLine($"|v2| = {v2.Length():F2}");
        }
    }
}
