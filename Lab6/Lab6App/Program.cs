using System;

namespace Lab6App
{
    // Мета:
    // Закріпити знання про перевантаження унарних та бінарних операторів у C#, навчитися реалізовувати перевантаження операторів для різних типів об’єктів.

    // Задача:
    // Створити клас Vector, який представляє вектор на площині з координатами (x, y).
    class Vector
    {
        double x;
        double y;

        // Реалізувати конструктор, який ініціалізує координати вектора.
        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // перевантажити унарний мінус для зміни знаків координат вектора
        public static Vector operator -(Vector operand) => new Vector(-operand.x, -operand.y);

        // бінарний оператор додавання для додавання двох векторів
        public static Vector operator +(Vector left, Vector right) => new Vector(left.x + right.x, left.y + right.y);

        // оператор множення вектора на скаляр
        public static Vector operator *(Vector left, double right) => new Vector(left.x * right, left.y * right);

        // додатково реалізую множення скаляр на вектор для зручності
        public static Vector operator *(double left, Vector right) => new Vector(right.x * left, right.y * left);

        // оператор рівності та нерівності
        // важливо також перевизначити equals і gethashcode щоб уникнути несподіваних поведінок
        public static bool operator ==(Vector left, Vector right)
        {
            // обробка null посилань
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.x == right.x && left.y == right.y;
        }

        public static bool operator !=(Vector left, Vector right) => !(left == right);

        // перевизначення equals для сумісності з оператором ==
        public override bool Equals(object obj)
        {
            if (obj is Vector v)
            {
                return this.x == v.x && this.y == v.y;
            }
            return false;
        }

        // перевизначення gethashcode
        public override int GetHashCode()
        {
            // використовуємо вбудований комбінатор хешів
            return HashCode.Combine(x, y);
        }

        // Реалізувати методи для виведення вектора на екран та отримання його довжини.
        public void Print()
        {
            Console.WriteLine("({0}, {1})", x, y);
        }

        public double Length()
        {
            return Math.Sqrt(x * x + y * y);
        }
    }

    // Написати тестову програму, яка створює кілька векторів, виконує з ними операції та виводить результати.
    class Program
    {
        static void Main(string[] args)
        {
            // Приклад:
            // Створити два вектори v1 = (3, 4) та v2 = (1, -2).
            var v1 = new Vector(3, 4);
            var v2 = new Vector(1, -2);
            Console.Write("v1 = ");
            v1.Print();
            Console.Write("v2 = ");
            v2.Print();

            // Змінити знаки координат вектора v1.
            Console.Write("-v1 = ");
            (-v1).Print();

            // Додати вектори v1 і v2.
            Console.Write("v1 + v2 = ");
            (v1 + v2).Print();

            // Помножити вектор v2 на скаляр 2.
            Console.Write("v2 * 2 = ");
            (v2 * 2).Print();

            // також можна помножити скаляр на вектор
            Console.Write("2 * v1 = ");
            (2 * v1).Print();

            // Порівняти два вектори на рівність.
            Console.WriteLine("v1 == v2 = {0}", v1 == v2);
            Console.WriteLine("v1 != v2 = {0}", v1 != v2);

            // додатково виведемо довжини векторів для інформації
            Console.WriteLine("length v1 = {0:f3}", v1.Length());
            Console.WriteLine("length v2 = {0:f3}", v2.Length());
        }
    }
}