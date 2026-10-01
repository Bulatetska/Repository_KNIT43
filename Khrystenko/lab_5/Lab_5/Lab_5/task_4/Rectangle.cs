using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_5.task_4
{
    internal class Rectangle : Figure
    {
        protected int x1, y1, x2, y2;


        public Rectangle(string name, int x1, int y1, int x2, int y2)
            : base(name)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }


        public Rectangle() : this("Rectangle", 0, 0, 1, 1)
        {
        }


        public override void Display()
        {
            base.Display();
            Console.WriteLine("Coordinates: (" + x1 + ", " + y1 + "), (" + x2 + ", " + y2 + ")");
        }

        public int Area()
        {
            return Math.Abs(x1 - x2) * Math.Abs(y1 - y2);
        }
    }
}
