{
    double[] triangle = { 60, 80, 100 }; //сторони заданного трикутника
    Array.Sort(triangle);
    Console.WriteLine("a = " + triangle[0] + ", b = " + triangle[1] + ", c = " + triangle[2] + ".");

    if (triangle[0] + triangle[1] > triangle[2])
    {
        double p = (triangle[0] + triangle[1] + triangle[2]) / 2;
        double S = Math.Sqrt(p * (p - triangle[0]) * (p - triangle[1]) * (p - triangle[2]));
        Console.WriteLine("S = " + S + ".");
    }
    else
    {
        Console.WriteLine("Трикутник не існує!");
    }
    Console.ReadLine();
}