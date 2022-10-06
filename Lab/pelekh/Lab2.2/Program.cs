{
    double a = 1, b = 5, c = -6;
    Console.WriteLine(a + "x^2 + " + b + "x + " + c + " = 0;");
    double D = b * b - 4 * a * c;
    double x1, x2, x;
    if (D > 0)
    {
        D = Math.Sqrt(D);
        x1 = (-b + D) / (2 * a);
        x2 = (-b - D) / (2 * a);
        Console.WriteLine("x1 = " + x1 + ",\nx2 = " + x2 + ".");
    }
    else if (D == 0)
    {
        x = -b / (2 * a);
        Console.WriteLine("x1 = x2 = " + x + ".");
    }
    else
    {
        Console.WriteLine("D = " + D + " < 0 - Немає розвязків");
    }
    Console.ReadLine();
}