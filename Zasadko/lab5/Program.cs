using System;

namespace FiguresExample
{
    // ------------------- Абстрактний клас Figure -------------------
    abstract class Figure
    {
        protected string name;

        public Figure(string name)
        {
            this.name = name;
        }

        // Віртуальний метод виводу
        public virtual void Print()
        {
            Console.WriteLine($"Figure: {name}");
        }
    }

    // ------------------- Клас Triangle -------------------
    class Triangle : Figure
    {
        protected double a, b, c; // сторони трикутника

        // Конструктор
        public Triangle(double a, double b, double c, string name) : base(name)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        // Властивість для обчислення площі (за формулою Герона)
        public virtual double Area2
        {
            get
            {
                double s = (a + b + c) / 2;
                return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            }
        }

        // Метод для обчислення площі
        public virtual double Area()
        {
            return Area2;
        }

        // Віртуальний метод виводу
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Sides: a={a}, b={b}, c={c}, Area={Area():F2}");
        }
    }

    // ------------------- Клас TriangleColor -------------------
    class TriangleColor : Triangle
    {
        private string color; // колір фону трикутника

        // Конструктор з 5 параметрами
        public TriangleColor(double a, double b, double c, string name, string color)
            : base(a, b, c, name)
        {
            this.color = color;
        }

        // Властивість Color
        public string Color
        {
            get => color;
            set => color = value;
        }

        // Властивість Area2 (звертається до базового класу)
        public new double Area2 => base.Area2;

        // Метод обчислення площі (можна залишити через базовий)
        public override double Area()
        {
            return base.Area();
        }

        // Віртуальний метод Print()
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Color: {color}");
        }
    }

    // ------------------- Демонстрація -------------------
    class Program
    {
        static void Main()
        {
            Triangle t = new Triangle(3, 4, 5, "Triangle1");
            t.Print();
            Console.WriteLine($"Area via Area2: {t.Area2:F2}\n");

            TriangleColor tc = new TriangleColor(6, 8, 10, "TriangleColor1", "Blue");
            tc.Print();
            Console.WriteLine($"Area via Area2: {tc.Area2:F2}, Color: {tc.Color}");
        }
    }
}
