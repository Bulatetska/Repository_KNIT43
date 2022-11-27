using System;
{
    Console.Write("a = ");
    var a = double.Parse(Console.ReadLine());
    Console.Write("b = ");
    var b = double.Parse(Console.ReadLine());
    Console.Write("c = ");
    var c = double.Parse(Console.ReadLine());

    double x1, x2;
    //дискримінант
    var discriminant = Math.Pow(b, 2) - 4 * a * c;
    if (discriminant < 0)
    {
        Console.WriteLine("Коренів немає");
    }
    else
    {
        if (discriminant == 0) //два однакові корені
        {
            x1 = -b / (2 * a);
            x2 = x1;
        }
        else //два різні корені
        {
            x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
        }
        Console.WriteLine($"x1 = {x1}; x2 = {x2}");
    }
}