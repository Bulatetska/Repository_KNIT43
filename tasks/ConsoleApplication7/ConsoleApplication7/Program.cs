using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

public class ArrayOperations
{
    public static int GetRowWithMaxAverage(int[,] array)
    {
        int maxRowIndex = 0;
        double maxAverage = double.MinValue;

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

    public static double GetRowAverage(int[,] array, int rowIndex)
    {
        double sum = 0;
        for (int i = 0; i < array.GetLength(1); i++)
        {
            sum += array[rowIndex, i];
        }

        return sum / array.GetLength(1);
    }

    public static void SwapRows(int[,] array, int rowIndex1, int rowIndex2)
    {
        for (int i = 0; i < array.GetLength(1); i++)
        {
            int temp = array[rowIndex1, i];
            array[rowIndex1, i] = array[rowIndex2, i];
            array[rowIndex2, i] = temp;
        }
    }
}


public class ArrayOperationsTests
{
    
    public void TestGetRowWithMaxAverage()
    {
        int[,] testArray = {
            {1, 2, 3, 4},
            {5, 6, 7, 8},
            {9, 10, 11, 12},
            {13, 14, 15, 16}
        };
        int expectedRow = 3; // The last row has the max average
        int actualRow = ArrayOperations.GetRowWithMaxAverage(testArray);
        Assert.AreEqual(expectedRow, actualRow);
    }
    
    public void TestGetRowAverage()
    {
        int[,] testArray = {
            {1, 2, 3, 4},
            {5, 6, 7, 8}
        };
        double expectedAverage = 6.5; // Average of the second row
        double actualAverage = ArrayOperations.GetRowAverage(testArray, 1);
        Assert.AreEqual(expectedAverage, actualAverage, 0.001);
    }
    
    public void TestSwapRows()
    {
        int[,] testArray = {
            {1, 2, 3, 4},
            {5, 6, 7, 8}
        };
        int[,] expectedArray = {
            {5, 6, 7, 8},
            {1, 2, 3, 4}
        };
        ArrayOperations.SwapRows(testArray, 0, 1);

        for (int i = 0; i < testArray.GetLength(0); i++)
        {
            for (int j = 0; j < testArray.GetLength(1); j++)
            {
                Assert.AreEqual(expectedArray[i, j], testArray[i, j]);
            }
        }
    }
}
