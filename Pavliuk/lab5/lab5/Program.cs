using System;
using System.Xml.Linq;

namespace ConsoleApplication1
{
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
            Console.WriteLine("name={0}", name);
        }
    }
    class Triangle : Figure
    {
        double a, b, c;
        public Triangle(string name, double a, double b, double c) : base(name)
        {
            if(((a+b)>c)&&((b+c)>a) && ((a + c) > b))
            {
                this.a = a; this.b = b; this.c = c;
            }
            else
            {
                Console.WriteLine("Incorrect values a,b,c.");
                Console.WriteLine("By default: a=1, b=1, c=1.");
                this.a = this.b = this.c = 1;

            }
        }
        public void SetABC(double a, double b, double c)
        {
            if (((a + b) > c) && ((b + c) > a) && ((a + c) > b))
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
        public override double Area2
        {
            get
            {
                double p, s;
                p = (a + b + c) / 2;
                s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                Console.WriteLine("Property Triangle.Area2: s = {0:f3}", s);
                return s;
            }
        }
        public override double Area()
        {
            double p, s;
            p = (a + b + c) / 2;
            s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            Console.WriteLine("Property Triangle.Area(): s = {0:f3}", s);
            return s;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine("a={0:f2}", a);
            Console.WriteLine("b={0:f2}", b);
            Console.WriteLine("c={0:f2}", c);
        }
    }
    class TriangleColor : Triangle
    {
        private string color;
        public TriangleColor(string g, string n, double a, double b, double c): base(n, a, b, c)
        {
            this.color = g;
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
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
            Console.WriteLine("color: {0}", color);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Figure refFg;
            //ERORR
            //Figure objFg = new Figure("Figure");
            TriangleColor Tr = new TriangleColor("Red", "Triangle", 2, 3, 2);
            refFg = Tr;
            Console.WriteLine("----Виведення інформації про фігуру-----");
            refFg.Print();
            refFg = Tr;
            Console.WriteLine("\n---- Обчислення площі (метод Area)----");
            refFg.Area();
            refFg = Tr;
            Console.WriteLine("\n---- Обчислення площі (властивість Area2)----");
            double area = refFg.Area2;
            Console.WriteLine("area = {0:f3}", area);
        }
    }
}