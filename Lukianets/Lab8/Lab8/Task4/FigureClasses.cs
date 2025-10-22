using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureClasses
{
    public class Figure
    {
        protected string name;

        public Figure(string name)
        {
            this.name = name;
        }

        public virtual void Display()
        {
            Console.WriteLine($"Figure: {name}");
        }
    }

    public class Rectangle : Figure
    {
        protected int x1, y1, x2, y2;

        public Rectangle(int x1, int y1, int x2, int y2, string name)
            : base(name)
        {
            this.x1 = x1; this.y1 = y1; this.x2 = x2; this.y2 = y2;
        }

        public Rectangle() : this(0, 0, 1, 1, "Rectangle") { }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Coordinates: ({x1},{y1}) to ({x2},{y2})");
        }

        public int Area()
        {
            return (x2 - x1) * (y2 - y1);
        }
    }

    public class RectangleColor : Rectangle
    {
        private string color;

        public RectangleColor(int x1, int y1, int x2, int y2, string name, string color)
            : base(x1, y1, x2, y2, name)
        {
            this.color = color;
        }

        public RectangleColor() : this(0, 0, 1, 1, "Colored Rectangle", "Red") { }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Color: {color}");
        }

        public new int Area()
        {
            return base.Area();
        }
    }
}
