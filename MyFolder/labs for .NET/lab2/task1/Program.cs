
using System;

class Program
{
    static void Main()
    {
        int[] A = { 3, 7, 2, 9, 5, 9, 1 };

        int max = A[0];
        int count = 0;
        int position = 0;

        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] > max)
            {
                max = A[i];
                position = i;
            }
        }

        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] == max)
            {
                count++;
            }
        }

        Console.WriteLine("Максимальний елемент: " + max);
        Console.WriteLine("Кількість повторень: " + count);
        Console.WriteLine("Позиція першого максимального: " + (position + 1));
    }
}
