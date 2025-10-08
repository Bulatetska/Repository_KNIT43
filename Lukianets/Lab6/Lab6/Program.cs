using System;

namespace VectorDemo
{
    class Vector
    {
        // 1. Поля класу
        private double x;
        private double y;

        // 2. Конструктор
        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // 3. Властивості для доступу до координат (необов’язково, але зручно)
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

        // 4. Унарний мінус — змінює знаки координат
        public static Vector operator -(Vector v)
        {
            return new Vector(-v.x, -v.y);
        }

        // 5. Додавання двох векторів
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y);
        }

        // 6. Множення вектора на скаляр
        public static Vector operator *(Vector v, double scalar)
        {
            return new Vector(v.x * scalar, v.y * scalar);
        }

        // 7. Порівняння рівності (==)
        public static bool operator ==(Vector v1, Vector v2)
        {
            // Використовуємо точність для double
            return Math.Abs(v1.x - v2.x) < 1e-9 && Math.Abs(v1.y - v2.y) < 1e-9;
        }

        // 8. Порівняння нерівності (!=)
        public static bool operator !=(Vector v1, Vector v2)
        {
            return !(v1 == v2);
        }

        // 9. Метод для обчислення довжини вектора
        public double Length()
        {
            return Math.Sqrt(x * x + y * y);
        }

        // 10. Метод для виведення вектора
        public void Print()
        {
            Console.WriteLine($"({x}, {y})");
        }

        // 11. Перевизначаємо Equals та GetHashCode (рекомендується при перевантаженні ==)
        public override bool Equals(object obj)
        {
            if (obj is Vector other)
                return this == other;
            return false;
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створення двох векторів
            Vector v1 = new Vector(3, 4);
            Vector v2 = new Vector(1, -2);

            Console.WriteLine("Початкові вектори:");
            Console.Write("v1 = "); v1.Print();
            Console.Write("v2 = "); v2.Print();

            // 1. Змінюємо знаки координат v1
            Vector v1Neg = -v1;
            Console.Write("\nПісля зміни знаків v1: ");
            v1Neg.Print();

            // 2. Додавання векторів
            Vector sum = v1 + v2;
            Console.Write("Сума v1 + v2 = ");
            sum.Print();

            // 3. Множення v2 на скаляр 2
            Vector scaled = v2 * 2;
            Console.Write("v2 * 2 = ");
            scaled.Print();

            // 4. Довжина вектора
            Console.WriteLine($"\nДовжина v1 = {v1.Length():f2}");
            Console.WriteLine($"Довжина v2 = {v2.Length():f2}");

            // 5. Порівняння
            Console.WriteLine($"\nv1 == v2 ? {v1 == v2}");
            Console.WriteLine($"v1 != v2 ? {v1 != v2}");

            Console.ReadKey();
        }
    }
}
