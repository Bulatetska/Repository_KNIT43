using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_5.task_4
{
    internal class RectangleColor : Rectangle
    {
        protected string color;


        public RectangleColor(string name, int x1, int y1, int x2, int y2, string color)
            : base(name, x1, y1, x2, y2)
        {
            this.color = color;
        }


        public RectangleColor() : this("Rectangle color", 0, 0, 1, 1, "black")
        {
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("Color: " + color);
        }

        public new int Area()
        {
            Console.WriteLine("Color area");
            return base.Area();
        }
    }
}
