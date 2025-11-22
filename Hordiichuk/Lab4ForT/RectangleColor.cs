// Lab4ForT/RectangleColor.cs
namespace Lab4ForT
{
    public class RectangleColor : Rectangle
    {
        public string Color { get; private set; }

        public RectangleColor(string name, int x1, int y1, int x2, int y2, string color)
            : base(name, x1, y1, x2, y2)
        {
            if (string.IsNullOrWhiteSpace(color))
                throw new ArgumentException("Color не може бути порожнім.", nameof(color));

            Color = color;
        }
    }
}
