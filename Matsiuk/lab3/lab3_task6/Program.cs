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

        double sum = 0;

        foreach (double element in A)
        {
            sum += element;
        }

        Console.WriteLine("Sum of array elements: " + sum);
    }
}