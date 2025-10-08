using System;

namespace ConsoleApplication8
{
    // Абстрактний клас Figure
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

    // Клас Triangle
    class Triangle : Figure
    {
        protected double a, b, c;

        public Triangle(string name, double a, double b, double c)
            : base(name)
        {
            if (((a + b) > c) && ((b + c) > a) && ((a + c) > b))
            {
                this.a = a; this.b = b; this.c = c;
            }
            else
            {
                Console.WriteLine("Incorrect values a, b, c. Using default 1,1,1.");
                this.a = this.b = this.c = 1;
            }
        }

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

        public void GetABC(out double a, out double b, out double c)
        {
            a = this.a; b = this.b; c = this.c;
        }

        public override double Area2
        {
            get
            {
                double p = (a + b + c) / 2;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
        }

        public override double Area()
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"a = {a}, b = {b}, c = {c}");
        }
    }

    // Новий клас TriangleColor
    class TriangleColor : Triangle
    {
        private string color;

        public TriangleColor(string name, double a, double b, double c, string color)
            : base(name, a, b, c)
        {
            this.color = color;
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        // Використовує властивість базового класу для обчислення площі
        public new double Area2
        {
            get { return base.Area2; }
        }

        public override double Area()
        {
            return base.Area();
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Color: {color}");
        }
    }

    class Program
    {
        static void Main()
        {
            TriangleColor tc = new TriangleColor("Colored Triangle", 3, 4, 5, "Red");

            Figure fRef = tc; // поліморфізм через базовий клас
            fRef.Print();
            Console.WriteLine($"Area (method) = {fRef.Area():f3}");
            Console.WriteLine($"Area2 (property) = {tc.Area2:f3}");
        }
    }
}
