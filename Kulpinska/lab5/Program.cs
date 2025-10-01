using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication8
{
    // Абстрактний клас Figure - містить абстрактний метод Area()
    // і абстрактну властивість Area2
    abstract class Figure
    {
        private string name; // Назва фігури

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

    // Клас, що реалізує трикутник
    class Triangle : Figure
    {
        double a, b, c;

        public Triangle(string name, double a, double b, double c) : base(name)
        {
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
                double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                Console.WriteLine("Property Triangle.Area2: s = {0:f3}", s);
                return s;
            }
        }

        public override double Area()
        {
            double p = (a + b + c) / 2;
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            Console.WriteLine("Method Triangle.Area(): s = {0:f3}", s);
            return s;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("a = {0:f2}", a);
            Console.WriteLine("b = {0:f2}", b);
            Console.WriteLine("c = {0:f2}", c);
        }
    }

    // Клас, що визначає трикутник з кольором
    class TriangleColor : Triangle
    {
        private int color;

        public TriangleColor(string name, double a, double b, double c, int color) :
            base(name, a, b, c)
        {
            if ((color >= 0) && (color <= 255))
                this.color = color;
            else
                this.color = 0;
        }

        public int Color
        {
            get { return color; }
            set
            {
                if ((value >= 0) && (value <= 255))
                    color = value;
                else
                    color = 0;
            }
        }

        public override double Area2
        {
            get
            {
                Console.WriteLine("Property TriangleColor.Area2:");
                return base.Area2;
            }
        }

        public override double Area()
        {
            Console.WriteLine("Method TriangleColor.Area():");
            return base.Area();
        }

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
            // Демонстрація поліморфізму
            Figure refFg;

            Triangle Tr = new Triangle("Triangle", 2, 3, 2);
            TriangleColor TrCol = new TriangleColor("TriangleColor", 1, 3, 3, 120);

            // Методи Print()
            refFg = Tr;
            refFg.Print();
            refFg = TrCol;
            refFg.Print();

            // Методи Area()
            refFg = Tr;
            refFg.Area();
            refFg = TrCol;
            refFg.Area();

            // Властивість Area2
            refFg = Tr;
            double area = refFg.Area2;
            Console.WriteLine("area = {0:f3}", area);

            refFg = TrCol;
            area = refFg.Area2;
            Console.WriteLine("area = {0:f3}", area);

            Console.ReadKey();
        }
    }
}
