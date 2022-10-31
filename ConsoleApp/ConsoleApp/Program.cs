using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle1 = new Rectangle();
            Rectangle rectangle2 = new Rectangle();

            rectangle1.createRectangle();
            rectangle2.createRectangle();

            Console.ReadKey();

            Console.WriteLine("Area of rectangle: " + rectangle1.getArea(rectangle1.getA(), rectangle1.getB(), rectangle1.getC()));
            Console.ReadKey();

            Console.WriteLine("Perimeter of rectangle: " + rectangle1.getPerimeter(rectangle1.getA(), rectangle1.getB(), rectangle1.getC()));
            Console.ReadKey();

            Console.WriteLine("Are areas of rectangles equals " + rectangle1.compareAreas(rectangle2));
            Console.ReadKey();

            Console.WriteLine("Specify how many times to enlarge the rectangle");
            rectangle1.updateRectangle(double.Parse(Console.ReadLine()));
            Console.ReadKey();

            Circle circle1 = new Circle();
            Circle circle2 = new Circle();

            circle1.createCircle();
            circle2.createCircle();

            Console.ReadKey();

            Console.WriteLine("Area of circle: " + circle1.getArea());
            Console.ReadKey();

            Console.WriteLine("Lenght of circle: " + circle1.getLength());
            Console.ReadKey();

            Console.WriteLine("Are areas of circles equals " + circle1.compareAreas(circle2));
            Console.ReadKey();
        }
    }
}
