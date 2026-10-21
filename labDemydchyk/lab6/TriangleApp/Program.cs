
using System;

namespace ConsoleApplication8
{
    // Абстрактний базовий клас Figure
    abstract class Figure
    {
        private string name;

        public Figure(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public abstract double Area2 { get; }

        public abstract double Area();

        public virtual void Print()
        {
            Console.WriteLine("name = {0}", name);
        }
    }

    // Клас Triangle — трикутник
    class Triangle : Figure
    {
        private double a, b, c;

        public Triangle(string name, double a, double b, double c)
            : base(name)
        {
            if (a + b > c && b + c > a && a + c > b &&
                a > 0 && b > 0 && c > 0)
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }
            else
            {
                Console.WriteLine("Incorrect values a, b, c.");
                Console.WriteLine("By default: a=1, b=1, c=1.");
                this.a = this.b = this.c = 1;
            }
        }

        public void SetABC(double a, double b, double c)
        {
            if (a + b > c && b + c > a && a + c > b &&
                a > 0 && b > 0 && c > 0)
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }
            else
            {
                this.a = this.b = this.c = 1;
            }
        }

        public void GetABC(out double a, out double b, out double c)
        {
            a = this.a;
            b = this.b;
            c = this.c;
        }

        // Властивість для обчислення площі
        public override double Area2
        {
            get
            {
                double p = (a + b + c) / 2;
                double s = Math.Sqrt(
                    p * (p - a) * (p - b) * (p - c));

                Console.WriteLine(
                    "Property Triangle.Area2: s = {0:f3}", s);

                return s;
            }
        }

        // Метод для обчислення площі
        public override double Area()
        {
            double p = (a + b + c) / 2;
            double s = Math.Sqrt(
                p * (p - a) * (p - b) * (p - c));

            Console.WriteLine(
                "Method Triangle.Area(): s = {0:f3}", s);

            return s;
        }

        // Виведення даних про трикутник
        public override void Print()
        {
            base.Print();

            Console.WriteLine("a = {0:f2}", a);
            Console.WriteLine("b = {0:f2}", b);
            Console.WriteLine("c = {0:f2}", c);
        }
    }

    // Новий клас TriangleColor — кольоровий трикутник
    class TriangleColor : Triangle
    {
        // 1. Приховане поле кольору
        private int color;

        // 2. Конструктор із п'ятьма параметрами
        public TriangleColor(
            string name, double a, double b, double c, int color)
            : base(name, a, b, c)
        {
            if (color >= 0 && color <= 255)
                this.color = color;
            else
                this.color = 0;
        }

        // 3. Властивість для доступу до кольору
        public int Color
        {
            get { return color; }

            set
            {
                if (value >= 0 && value <= 255)
                    color = value;
                else
                    color = 0;
            }
        }

        // 4. Властивість Area2 викликає властивість базового класу
        public override double Area2
        {
            get
            {
                Console.WriteLine(
                    "Property TriangleColor.Area2:");

                return base.Area2;
            }
        }

        // 5. Метод Area() викликає метод базового класу
        public override double Area()
        {
            Console.WriteLine(
                "Method TriangleColor.Area():");

            return base.Area();
        }

        // 6. Виведення всіх даних про кольоровий трикутник
        public override void Print()
        {
            base.Print();

            Console.WriteLine("color = {0}", color);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створення об'єктів
            Triangle Tr = new Triangle("Triangle", 2, 3, 2);

            TriangleColor TrCol =
                new TriangleColor("TriangleColor", 1, 3, 3, 100);

            // Демонстрація методу Print()
            Console.WriteLine("=== Triangle ===");
            Tr.Print();

            Console.WriteLine("\n=== TriangleColor ===");
            TrCol.Print();

            // Демонстрація методу Area()
            Console.WriteLine("\n=== Area() ===");
            Tr.Area();
            TrCol.Area();

            // Демонстрація властивості Area2
            Console.WriteLine("\n=== Area2 ===");

            double area = Tr.Area2;
            Console.WriteLine("area = {0:f3}", area);

            area = TrCol.Area2;
            Console.WriteLine("area = {0:f3}", area);

            // Демонстрація властивості Color
            Console.WriteLine("\n=== Color ===");
            Console.WriteLine("Old color = {0}", TrCol.Color);

            TrCol.Color = 200;

            Console.WriteLine("New color = {0}", TrCol.Color);

            Console.ReadKey();
        }
    }
}
