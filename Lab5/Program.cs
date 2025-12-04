using System;

namespace AbstractFigureExample
{
    // === Абстрактний базовий клас Figure ===
    abstract class Figure
    {
        public string Name { get; set; }

        public Figure(string name)
        {
            Name = name;
        }

        // Абстрактна властивість площі
        public abstract double Area { get; }

        // Віртуальний метод виводу
        public virtual void Print()
        {
            Console.WriteLine($"Фігура: {Name}");
        }
    }

    // === Клас Triangle, що успадковує Figure ===
    class Triangle : Figure
    {
        protected double a, b, c; // сторони трикутника

        public Triangle(string name, double a, double b, double c)
            : base(name)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        // Властивості для доступу до сторін
        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }
        public double C { get => c; set => c = value; }

        // Властивість для обчислення площі за формулою Герона
        public override double Area
        {
            get
            {
                double p = (a + b + c) / 2;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
        }

        // Віртуальний метод для виводу інформації
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Сторони: a={a}, b={b}, c={c}");
            Console.WriteLine($"Площа трикутника: {Area:F2}");
        }
    }

    // === Клас TriangleColor, що розширює Triangle ===
    class TriangleColor : Triangle
    {
        private string color; // приховане поле кольору

        // Конструктор з 5 параметрами (викликає конструктор базового класу)
        public TriangleColor(string name, double a, double b, double c, string color)
            : base(name, a, b, c)
        {
            this.color = color;
        }

        // Властивість для доступу до поля color
        public string Color
        {
            get => color;
            set => color = value;
        }

        // Властивість Area2, що викликає Area базового класу
        public double Area2
        {
            get => base.Area;
        }

        // Метод Area(), який обчислює площу (аналогічно базовому)
        public double AreaMethod()
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        // Віртуальний метод Print() (звертається до базового)
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Колір трикутника: {color}");
            Console.WriteLine($"(через властивість Area2) Площа: {Area2:F2}");
        }
    }

    // === Головний клас ===
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Абстрактний клас Figure та TriangleColor ===\n");

            Triangle t = new Triangle("Звичайний трикутник", 3, 4, 5);
            t.Print();

            Console.WriteLine();

            TriangleColor tc = new TriangleColor("Кольоровий трикутник", 6, 7, 8, "синій");
            tc.Print();

            Console.WriteLine($"\nПлоща через метод AreaMethod(): {tc.AreaMethod():F2}");
        }
    }
}
