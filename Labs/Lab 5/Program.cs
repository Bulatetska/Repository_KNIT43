using System;

namespace ConsoleApplicationTriangle
{
    // Абстрактний клас Figure - містить абстрактний метод Area()
    // і абстрактну властивість Area2
    abstract class Figure
    {
        // 1. Приховане поле класу
        private string name; // Назва фігури

        // 2. Конструктор класу
        public Figure(string name)
        {
            this.name = name;
        }

        // 3. Властивість доступу до поля класу
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // 4. Абстрактна властивість, яка повертає площу фігури
        public abstract double Area2 { get; }

        // 5. Абстрактний метод, який повертає площу фігури
        public abstract double Area();

        // 6. Віртуальний метод, який виводить значення полів класу
        public virtual void Print()
        {
            Console.WriteLine("name = {0}", name);
        }
    }

    // Клас, що реалізує трикутник
    class Triangle : Figure
    {
        // 1. Внутрішні поля класу
        protected double a, b, c;

        // 2. Конструктор класу
        public Triangle(string name, double a, double b, double c)
            : base(name)
        {
            // Перевірка на коректність значень a, b, c
            if (((a + b) > c) && ((b + c) > a) && ((a + c) > b))
            {
                this.a = a; this.b = b; this.c = c;
            }
            else
            {
                Console.WriteLine("Incorrect values a, b, c.");
                Console.WriteLine("By default: a=1, b=1, c=1.");
                this.a = this.b = this.c = 1;
            }
        }

        // 3. Встановлення значень сторін
        public void SetABC(double a, double b, double c)
        {
            if (((a + b) > c) && ((b + c) > a) && ((a + c) > b))
            {
                this.a = a; this.b = b; this.c = c;
            }
            else
            {
                this.a = this.b = this.c = 1;
            }
        }

        // 3.2. Читання значень сторін
        public void GetABC(out double a, out double b, out double c)
        {
            a = this.a; b = this.b; c = this.c;
        }

        // 4. Перевизначення абстрактної властивості Area2 класу Figure
        public override double Area2
        {
            get
            {
                double p = (a + b + c) / 2;
                double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                Console.WriteLine("Property Triangle.Area2: s = {0:f3}", s);
                return s;
            }
        }

        // 5. Реалізація абстрактного методу Area()
        public override double Area()
        {
            double p = (a + b + c) / 2;
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            Console.WriteLine("Method Triangle.Area(): s = {0:f3}", s);
            return s;
        }

        // 6. Віртуальний метод Print
        public override void Print()
        {
            base.Print();
            Console.WriteLine("a = {0:f2}", a);
            Console.WriteLine("b = {0:f2}", b);
            Console.WriteLine("c = {0:f2}", c);
        }
    }

    // Новий клас TriangleColor, що розширює Triangle
    class TriangleColor : Triangle
    {
        // 1. Приховане поле color (колір фону трикутника)
        private int color;

        // 2. Конструктор з 5 параметрами, викликає конструктор базового класу
        public TriangleColor(string name, double a, double b, double c, int color)
            : base(name, a, b, c)
        {
            if (color >= 0 && color <= 255)
                this.color = color;
            else
                this.color = 0;
        }

        // 3. Властивість Color для доступу до поля color
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

        // 4. Властивість Area2 – викликає однойменну властивість базового класу
        public override double Area2
        {
            get
            {
                Console.WriteLine("Property TriangleColor.Area2:");
                return base.Area2;
            }
        }


        // 5. Метод Area(), який повертає площу трикутника (через базовий метод)
        public override double Area()
        {
            Console.WriteLine("Method TriangleColor.Area():");
            return base.Area();
        }

        // 6. Віртуальний метод Print()
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
            // Демонстрація поліморфізму з використанням абстрактного класу Figure
            Figure refFg;

            // Екземпляри похідних класів
            Triangle Tr = new Triangle("Triangle", 2, 3, 2);
            TriangleColor TrCol = new TriangleColor("TriangleColor", 1, 3, 3, 128);

            Console.WriteLine("=== Triangle ===");
            refFg = Tr;
            refFg.Print();
            refFg.Area();
            double areaTri = refFg.Area2;
            Console.WriteLine("area (Triangle) = {0:f3}", areaTri);

            Console.WriteLine();

            Console.WriteLine("=== TriangleColor ===");
            refFg = TrCol;
            refFg.Print();
            refFg.Area();
            double areaTriCol = refFg.Area2;
            Console.WriteLine("area (TriangleColor) = {0:f3}", areaTriCol);

            Console.ReadKey();
        }
    }
}
