namespace ClassesLab;
public class Rectangle : Figure
{
    public double X1 { get; set; }
    public double Y1 { get; set; }
    public double X2 { get; set; }
    public double Y2 { get; set; }
    public Rectangle(string name, double x1, double y1, double x2, double y2) : base(name)
    { X1 = x1; Y1 = y1; X2 = x2; Y2 = y2; }
    public Rectangle() : this("Прямокутник", 0, 0, 1, 1) { }
    public override void Display()
    { base.Display(); Console.WriteLine($"Координати: ({X1}; {Y1}) — ({X2}; {Y2})"); }
    public virtual double Area() => Math.Abs(X2 - X1) * Math.Abs(Y2 - Y1);
}
