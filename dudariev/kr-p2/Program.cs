// Створіть клас Square (квадрат) у якого сторони паралельні осям координат
// (задати координату точки та сторону квадрата).
// У класі Square створіть відповідні властивості тa конструктори.
// Створіть клас Cub, який наслідує клас Square.
// У класі Cub створіть відповідні властивості тa конструктори.
// Напишіть метод обчислення площі квадрата для класу Square та
// площі однієї грані і всієї поверхні куба для класу Cub (використати наслідування).

var square = new Square(1, 2, 2);
Console.WriteLine("Квадрат з X = {0} | Y = {1} | Side = {2}", square.X, square.Y, square.Side);
Console.WriteLine("Площа квадрата: {0}", square.Area());
Console.WriteLine();

var cube = new Cub(1, 2, 3, 2);
Console.WriteLine("Куб з X = {0} | Y = {1} | Z = {2} | Side = {3}", cube.X, cube.Y, cube.Z, cube.Side);
Console.WriteLine("Площа сторони куба: {0}", cube.SideArea());
Console.WriteLine("Площа усієї поверхні куба: {0}", cube.SurfaceArea());
Console.WriteLine();

public class Square
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Side { get; set; }

    public Square(double x, double y, double side)
    {
        X = x;
        Y = y;
        Side = side;
    }

    public double Area()
    {
        return Side * Side;
    }
}

public class Cub : Square
{
    public double Z { get; set; }

    public Cub(double x, double y, double z, double side) : base(x, y, side)
    {
        Z = z;
    }

    public double SideArea()
    {
        return base.Area();
    }

    public double SurfaceArea()
    {
        return SideArea() * 6;
    }
}