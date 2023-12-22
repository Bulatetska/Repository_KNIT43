using System;

class Program
{
    // vatiant 13
    static void Main()
    {
        int[,] A = {
            {1, 2, 3, 4},
            {5, 6, 7, 8},
            {9, 10, 11, 12},
            {13, 14, 15, 16}
        };

        int[,] B = {
            {17, 18, 19},
            {20, 21, 22},
            {23, 24, 25}
        };

        Console.WriteLine("Array A before swapping:");
        PrintArray(A);
        SwapWithMaxAverageRow(A);
        Console.WriteLine("Array A after swapping:");
        PrintArray(A);

        Console.WriteLine("Array B before swapping:");
        PrintArray(B);
        SwapWithMaxAverageRow(B);
        Console.WriteLine("Array B after swapping:");
        PrintArray(B);
    }

    static void SwapWithMaxAverageRow(int[,] array)
    {
        int lastRowIndex = array.GetLength(0) - 1;
        int rowWithMaxAverageIndex = GetRowWithMaxAverage(array);
        SwapRows(array, lastRowIndex, rowWithMaxAverageIndex);
    }

    static int GetRowWithMaxAverage(int[,] array)
    {
        int maxRowIndex = 0;
        double maxAverage = -1;

        for (int i = 0; i < array.GetLength(0); i++)
        {
            double rowAverage = GetRowAverage(array, i);
            if (rowAverage > maxAverage)
            {
                maxAverage = rowAverage;
                maxRowIndex = i;
            }
        }

        return maxRowIndex;
    }

    static double GetRowAverage(int[,] array, int rowIndex)
    {
        double sum = 0;
        for (int i = 0; i < array.GetLength(1); i++)
        {
            sum += array[rowIndex, i];
        }

        return sum / array.GetLength(1);
    }

    static void SwapRows(int[,] array, int rowIndex1, int rowIndex2)
    {
        for (int i = 0; i < array.GetLength(1); i++)
        {
            int temp = array[rowIndex1, i];
            array[rowIndex1, i] = array[rowIndex2, i];
            array[rowIndex2, i] = temp;
        }
    }

    static void PrintArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
