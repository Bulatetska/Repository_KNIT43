
using System;

class Program
{
    static void Main()
    {
        double[] A = { 2, 3, 0, 0, -4, 5, 6, 7, 0, 0 };

        int positive = 0;
        int zeros = 0;

        for (int i = 0; i < A.Length - 1; i++)
        {
            if (A[i] > 0 && A[i + 1] > 0)
            {
                positive++;
            }

            if (A[i] == 0 && A[i + 1] == 0)
            {
                zeros++;
            }
        }

        Console.WriteLine("Пар додатних чисел: " + positive);
        Console.WriteLine("Пар нулів: " + zeros);
    }
}
