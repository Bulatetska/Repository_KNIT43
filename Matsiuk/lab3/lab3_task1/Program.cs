using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] A = new int[n];

        Console.WriteLine("Enter the elements:");

        for (int i = 0; i < n; i++)
        {
            A[i] = Convert.ToInt32(Console.ReadLine());
        }

        int max = A[0];
        int count = 0;
        int firstPosition = 0;

        foreach (int element in A)
        {
            if (element > max)
            {
                max = element;
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (A[i] == max)
            {
                count++;

                if (count == 1)
                {
                    firstPosition = i + 1;
                }
            }
        }

        Console.WriteLine("Maximum element: " + max);
        Console.WriteLine("Number of occurrences: " + count);
        Console.WriteLine("Position of the first maximum element: " + firstPosition);
    }
}