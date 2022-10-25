using System;
class Program
{
    static void Main()
    {
    	double[] triangle = new double[3];
    	Console.Write("a = ");
        triangle[0] = double.Parse(Console.ReadLine());
        Console.Write("b = ");
        triangle[1] = double.Parse(Console.ReadLine());
        Console.Write("c = ");
        triangle[2] = double.Parse(Console.ReadLine()); 
        Array.Sort(triangle);
        Console.WriteLine("Строни трикутника : " + triangle[0] + ", " + triangle[1] + ", " +     triangle[2] + ".");
  
        if (triangle[0] + triangle[1] > triangle[2]) {
    	double p = (triangle[0] + triangle[1] + triangle[2])/2;
    	double S = Math.Sqrt(p * (p - triangle[0]) * (p - triangle[1]) * (p - triangle[2]));
    	Console.WriteLine("Площа = " + S + ".");
        }
        else {
        Console.WriteLine("Трикутник не існує!");
        }
  Console.ReadLine();
  }
}    
