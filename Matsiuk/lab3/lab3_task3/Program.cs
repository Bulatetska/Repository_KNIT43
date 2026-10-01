using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());

        double[] A = new double[n];

        Console.WriteLine("Enter the elements:");

        for (int i = 0; i < n; i++)
        {
            A[i] = Convert.ToDouble(Console.ReadLine());
        }

        int positivePairs = 0;
        int zeroPairs = 0;

        for (int i = 0; i < n - 1; i++)
        {
            if (A[i] > 0 && A[i + 1] > 0)
            {
                positivePairs++;
            }

            if (A[i] == 0 && A[i + 1] == 0)
            {
                zeroPairs++;
            }
        }

        Console.WriteLine("Number of neighboring pairs of positive numbers: " + positivePairs);
        Console.WriteLine("Number of neighboring pairs of zero elements: " + zeroPairs);
    }
}