// Lab4ForT/Rectangle.cs
namespace Lab4ForT
{
    public class Rectangle : Figure
    {
        public int X1 { get; private set; }
        public int Y1 { get; private set; }
        public int X2 { get; private set; }
        public int Y2 { get; private set; }

        public Rectangle(string name, int x1, int y1, int x2, int y2)
            : base(name)
        {
            if (x2 <= x1) throw new ArgumentException("X2 повинен бути більшим за X1");
            if (y2 <= y1) throw new ArgumentException("Y2 повинен бути більшим за Y1");

            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public override int Area()
        {
            return (X2 - X1) * (Y2 - Y1);
        }
    }
}
