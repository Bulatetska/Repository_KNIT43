using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Rectangle
    {
        Point a;
        Point b;
        Point c;
        Point d;

        public Rectangle()
        {
            this.a = new Point();
            this.b = new Point();
            this.c = new Point();
            this.d = new Point();
        }
        public void setAX(double x)
        {
            this.a.setX(x);
        }
        public void setAY(double y)
        {
            this.a.setY(y);
        }

        public void setBX(double x)
        {
            this.b.setX(x);
        }
        public void setBY(double y)
        {
            this.b.setY(y);
        }

        public void setCX(double x)
        {
            this.c.setX(x);
        }
        public void setCY(double y)
        {
            this.c.setY(y);
        }

        public void setDX(double x)
        {
            this.d.setX(x);
        }
        public void setDY(double y)
        {
            this.d.setY(y);
        }
        public Point getA()
        {
            return this.a;
        }
        public Point getB()
        {
            return this.b;
        }
        public Point getC()
        {
            return this.c;
        }
        public Point getD()
        {
            return this.d;
        }
        public void getRectangle()
        {
            Console.WriteLine("Point A: ", this.getA());
        }
        public void createRectangle()
        {
            Console.WriteLine("Enter AX");
            this.setAX(double.Parse(Console.ReadLine()));
            Console.WriteLine("Enter AY");
            this.setAY(double.Parse(Console.ReadLine()));

            Console.WriteLine("Enter BX");
            this.setBX(double.Parse(Console.ReadLine()));
            Console.WriteLine("Enter BY");
            this.setBY(double.Parse(Console.ReadLine()));

            Console.WriteLine("Enter CX");
            this.setCX(double.Parse(Console.ReadLine()));
            Console.WriteLine("Enter CY");
            this.setCY(double.Parse(Console.ReadLine()));

            Console.WriteLine("Enter DX");
            this.setDX(double.Parse(Console.ReadLine()));
            Console.WriteLine("Enter DY");
            this.setDY(double.Parse(Console.ReadLine()));
        }
        public double getDist(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.getX() - b.getX(), 2) + Math.Pow(a.getY() - b.getY(), 2));
        }
        public double getArea(Point a, Point b, Point c)
        {
            return getDist(a, b) * getDist(b, c);
        }
        public double getPerimeter(Point a, Point b, Point c)
        {
            return getDist(a, b) * 2 + getDist(b, c) * 2;
        }

        public bool compareAreas(Rectangle b)
        {
            return this.getArea(this.getA(), this.getB(), this.getC()) == b.getArea(b.getA(), b.getB(), b.getC());
        }

        public void updateRectangle(double a)
        {
            this.b.setY(this.b.getY() * a);
            this.c.setX(this.c.getX() * a);
            this.c.setY(this.c.getY() * a);
            this.d.setX(this.d.getX() * a);
            this.getRectangle();
        }
    }
}
