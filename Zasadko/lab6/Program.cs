using System;

namespace VectorExample
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

        // Перевантаження унарного мінуса
        public static Vector operator -(Vector v)
        {
            return new Vector(-v.X, -v.Y);
        }

        // Перевантаження бінарного додавання
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }

        // Перевантаження оператора множення на скаляр (вектор * число)
        public static Vector operator *(Vector v, double scalar)
        {
            return new Vector(v.X * scalar, v.Y * scalar);
        }

        // Перевантаження оператора множення на скаляр (число * вектор)
        public static Vector operator *(double scalar, Vector v)
        {
            return v * scalar;
        }

        // Перевантаження операторів == та !=
        public static bool operator ==(Vector v1, Vector v2)
        {
            // Перевірка на null
            if (ReferenceEquals(v1, null) && ReferenceEquals(v2, null))
                return true;
            if (ReferenceEquals(v1, null) || ReferenceEquals(v2, null))
                return false;

            return v1.X == v2.X && v1.Y == v2.Y;
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            return !(v1 == v2);
        }

        // Перевизначення Equals та GetHashCode для коректної роботи == та !=
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

        // Метод для виводу вектора
        public void Print()
        {
            Console.WriteLine($"({X}, {Y})");
        }

        // Метод для обчислення довжини вектора
        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y);
        }
    }

    class Program
    {
        static void Main()
        {
            // Створення векторів
            Vector v1 = new Vector(3, 4);
            Vector v2 = new Vector(1, -2);

            Console.WriteLine("Початкові вектори:");
            Console.Write("v1 = "); v1.Print();
            Console.Write("v2 = "); v2.Print();

            // Змінити знаки координат вектора v1
            Vector v1Neg = -v1;
            Console.WriteLine("\nПісля унарного мінуса v1:");
            v1Neg.Print();

            // Додати вектори v1 і v2
            Vector vSum = v1Neg + v2;
            Console.WriteLine("\nСума v1 + v2:");
            vSum.Print();

            // Помножити вектор v2 на скаляр 2
            Vector v2Scaled = v2 * 2;
            Console.WriteLine("\nv2 * 2:");
            v2Scaled.Print();

            // Порівняти два вектори на рівність
            Vector v3 = new Vector(-3, -4);
            Console.WriteLine("\nПорівняння векторів:");
            Console.Write("v1 == v3 ? ");
            Console.WriteLine(v1 == v3);
            Console.Write("v1 != v3 ? ");
            Console.WriteLine(v1 != v3);

            // Довжина вектора
            Console.WriteLine("\nДовжини векторів:");
            Console.WriteLine($"|v1| = {v1.Length():F2}");
            Console.WriteLine($"|v2| = {v2.Length():F2}");
        }
    }
}
