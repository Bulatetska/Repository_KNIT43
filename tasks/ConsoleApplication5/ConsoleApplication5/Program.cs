using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main()
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        
        // task 1, variant 13
        Console.WriteLine("Enter value for A:");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter value for I:");
        int i = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter value for C:");
        double c = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter value for L (true/false):");
        bool l = Convert.ToBoolean(Console.ReadLine());
        Console.WriteLine("Enter value for N:");
        string n = Console.ReadLine();

        Console.WriteLine("Values for variant 13:");
        Console.WriteLine($"A: {a}");
        Console.WriteLine($"I: {i}");
        Console.WriteLine($"C: {c}");
        Console.WriteLine($"L: {l}");
        Console.WriteLine($"N: {n}");

        // task 2, variant 13, 1
        double xmin = 0;
        double xmax = 3;
        int points = 8;
        double step = (xmax - xmin) / (points - 1);

        string outputFilePath = "LAB2.RES";

        List<double> xValues = new List<double>();
        List<double> yValues = new List<double>();
        
        for (int j = 0; j < points; j++)
        {
            double x = xmin + step * j;
            double y = CalculateFunction(x);
            xValues.Add(x);
            yValues.Add(y);
        }
        
        using (StreamWriter sw = new StreamWriter(outputFilePath))
        {
            sw.WriteLine("Table of Values");
            sw.WriteLine("|----------------------------------------------|");
            sw.WriteLine("|   X           |       Function               |");
            sw.WriteLine("|----------------------------------------------|");

            for (int j = 0; j < xValues.Count; j++)
            {
                sw.WriteLine($"| X={xValues[j]:0.###} | Y={yValues[j]:0.###} |");
            }

            sw.WriteLine("|-----------------------------------------------|");
            sw.WriteLine("Signature: <Kateryna Plodnik>");
        }
    }

    static double CalculateFunction(double x)
    {
        return 1 / (Math.Sqrt(2 * Math.PI) * Math.Exp(x + 1));
    }
}
