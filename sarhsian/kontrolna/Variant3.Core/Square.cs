namespace Variant3.Core;

public class Square
{
    public double X { get; }
    public double Y { get; }
    public double Side { get; }

    public Square() : this(0, 0, 1) { }

    public Square(double x, double y, double side)
    {
        if (!double.IsFinite(x) || !double.IsFinite(y))
            throw new ArgumentException("Координати мають бути скінченними числами.");
        if (!double.IsFinite(side) || side <= 0)
            throw new ArgumentOutOfRangeException(nameof(side), "Сторона має бути більшою за нуль.");

        X = x;
        Y = y;
        Side = side;
    }

    public double Area() => Side * Side;
}
