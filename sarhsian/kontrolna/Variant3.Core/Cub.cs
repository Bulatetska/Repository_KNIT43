namespace Variant3.Core;

public class Cub : Square
{
    public double Height => Side;

    public Cub() : base() { }

    public Cub(double x, double y, double side) : base(x, y, side) { }

    public double FaceArea() => Area();

    public double SurfaceArea() => 6 * FaceArea();
}
