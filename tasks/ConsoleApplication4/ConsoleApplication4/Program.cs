using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // task 1
        CountMaxElements();

        // task 2 
        ReplaceMatrixMaxWithZeros();

        // task 3
        CountAdjacentSequences();

        // task 4
        ReplaceMatrixElementsByAverage();

        // task 5
        SumOfRowWithMaxElement();

        // task 6
        CalculateArraySum();
    }

    static void CountMaxElements()
    {
        int[] array = { 1, 3, 5, 7, 5, 7, 7 }; 
        int maxElement = array.Max();
        int maxCount = array.Count(x => x == maxElement);
        int firstMaxIndex = Array.IndexOf(array, maxElement);

        Console.WriteLine($"Максимальний елемент {maxElement} зустрічається {maxCount} рази.");
        Console.WriteLine($"Перший максимальний елемент має індекс {firstMaxIndex + 1} (враховуючи, що нумерація починається з 1).");
    }
    
    static void ReplaceMatrixMaxWithZeros()
    {
        double[,] matrix = { { 1, 3, 2 }, { 2, 5, 5 }, { 5, 1, 5 } };
        double max = matrix.Cast<double>().Max();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == max)
                {
                    matrix[i, j] = 0;
                }
            }
        }
        
        Console.WriteLine("Матриця після заміни максимальних елементів на нулі:");
        PrintMatrix(matrix);
    }
    
    static void CountAdjacentSequences()
    {
        double[] sequence = { 1, 0, 0, -1, 1, 1, 0 }; 
        int positiveCount = 0, zeroCount = 0;

        for (int i = 0; i < sequence.Length - 1; i++)
        {
            if (sequence[i] > 0 && sequence[i + 1] > 0)
            {
                positiveCount++;
            }
            if (sequence[i] == 0 && sequence[i + 1] == 0)
            {
                zeroCount++;
            }
        }

        Console.WriteLine($"Кількість сусідств двох додатних чисел: {positiveCount}");
        Console.WriteLine($"Кількість сусідств двох нульових елементів: {zeroCount}");
    }
    
    static void ReplaceMatrixElementsByAverage()
    {
        int[,] matrix = { { 1, -1, 2 }, { 3, 4, -2 }, { -3, -4, 1 } };
        double average = matrix.Cast<int>().Average();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = matrix[i, j] < average ? -1 : 1;
            }
        }
        
        Console.WriteLine("Матриця після заміни елементів:");
        PrintMatrix(matrix);
    }
    
    static void SumOfRowWithMaxElement()
    {
        int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 }, { 13, 14, 15 }, { 16, 17, 18 } };
        int maxElement = matrix.Cast<int>().Max();
        int rowIndex = -1;
        int sum = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == maxElement)
                {
                    rowIndex = i;
                    break;
                }
            }
        }

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sum += matrix[rowIndex, j];
        }

        Console.WriteLine($"Сума елементів рядка з найбільшим елементом {maxElement}: {sum}");
    }
    
    static void CalculateArraySum()
    {
        double[] array = { 1.5, 2.3, -1.2, 4.5, 5.6 }; // Приклад масиву
        double sum = array.Sum();

        Console.WriteLine($"Сума елементів масиву: {sum}");
    }
    
    static void PrintMatrix<T>(T[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
