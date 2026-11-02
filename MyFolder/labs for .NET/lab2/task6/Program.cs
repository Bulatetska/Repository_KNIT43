
using System;

class Program
{
    static void Main()
    {
        double[] A = { 2.5, 3.1, 4.4, 1.0, 5.0 };

        double sum = 0;

        for (int i = 0; i < A.Length; i++)
        {
            sum += A[i];
        }

        Console.WriteLine("Сума елементів: " + sum);
    }
}
