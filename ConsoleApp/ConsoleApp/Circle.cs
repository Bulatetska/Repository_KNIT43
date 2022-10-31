using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Circle
    {
        Point a;
        double r;

        public Circle()
        {
            this.a = new Point();
            this.r = new Double();
        }
        public void setAX(double x)
        {
            this.a.setX(x);
        }
        public void setAY(double y)
        {
            this.a.setY(y);
        }
        public void setR(double r)
        {
            this.r = r;
        }
        public Point getA()
        {
            return this.a;
        }
        public double getR()
        {
            return this.r;
        }
        public void displayCircle()
        {
            Console.WriteLine("Circle center: ", this.getA());
            Console.WriteLine("Circle radius: ", this.getR());

        }
        public void createCircle()
        {
            Console.WriteLine("Enter AX");
            this.setAX(double.Parse(Console.ReadLine()));
            Console.WriteLine("Enter AY");
            this.setAY(double.Parse(Console.ReadLine()));

            Console.WriteLine("Enter R");
            this.setR(double.Parse(Console.ReadLine()));
        }
        public double getArea()
        {
            return Math.Pow(this.r, 2) * Math.PI;
        }
        public double getLength()
        {
            return 2 * this.r * Math.PI;
        }
        public void updateCircle(double a)
        {
            this.setR(this.getR() * a);
        }
        public bool compareAreas(Circle circle)
        {
            return this.getArea() == circle.getArea();
        }
    }
}
