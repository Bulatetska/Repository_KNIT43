namespace ClassesLab;
public class RectangleColor : Rectangle
{
    public string Color { get; set; }
    public RectangleColor(string name, double x1, double y1, double x2, double y2, string color)
        : base(name, x1, y1, x2, y2) => Color = color;
    public RectangleColor() : this("Кольоровий прямокутник", 0, 0, 1, 1, "Без кольору") { }
    public override void Display()
    { base.Display(); Console.WriteLine($"Колір: {Color}"); }
    public override double Area() => base.Area();
}
