using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class Program {
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
    class Triangle : Figure
    {   
        double a, b, c;

        public Triangle(string name, double a, double b, double c)
        : base(name)
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
                double p, s;
                p = (a + b + c) / 2;
                s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                Console.WriteLine("Property Triangle.Area2: s = {0:f3}", s);             // 3. Повернути результат
                return s;
            }
        }
 
        public override double Area()
        {
            double p, s;
            p = (a + b + c) / 2;
            s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
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

    class TriangleColor : Triangle
    {
        private int color;

        public TriangleColor(string name, double a, double b, double c, int
        color) :
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
                if ((color >= 0) && (color <= 255))
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

	static void Main(string[] args) {
        Figure refFg;

        Triangle Tr = new Triangle("Triangle", 2, 3, 2);
        TriangleColor TrCol = new TriangleColor("TriangleColor", 1, 3, 3, 0);

        refFg = Tr;
        refFg.Print();
        refFg = TrCol;
        refFg.Print();

        refFg = Tr;
        refFg.Area();
        refFg = TrCol;
        refFg.Area(); 

        refFg = Tr;
        double area = refFg.Area2;  
        Console.WriteLine("area = {0:f3}", area);
        refFg = TrCol;
        area = refFg.Area2; 
        Console.WriteLine("area = {0:f3}", area);
        Console.ReadKey();
    }
}

