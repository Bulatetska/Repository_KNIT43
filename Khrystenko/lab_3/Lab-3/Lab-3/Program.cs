using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] task1 = { 1, 2, 3, 3, 2, 1, 7, 4, 8, 8, 2 };
            int[][] task2 = {
                new int[] {1, 2, 2 },
                new int[] {6, 3, 6 },
                new int[] {6, 1, 3 }
            };
            // positive 1 + 1 + 1
            // zero     1
            int[] task3 = { 1, 1, 0, 0, 1, 3, -1, 4, 1, 0 };
            double[] task6 = { 1d, 2d, 3d, 3d, 2d, 1d, 7d, 4d, 8d, 8d, 2d };
            SumOfRowsWithMax(task2);
        }


        static void NumberOfMaxInArray(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                Console.WriteLine("Array is empty");
                return;
            }
            int max = numbers[0];
            foreach (int number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }
            int counter = 0;
            foreach (int number in numbers)
            {
                if (number == max)
                {
                    counter++;
                }
            }
            Console.WriteLine("Max number in array: " + max);
            Console.WriteLine("Number of max in array: " + counter);
        }


        static void DeleteMaxInMartix(int[][] matrix)
        {
            if (matrix.Length == 0)
            {
                Console.WriteLine("Matrix is empty");
                return;
            }
            foreach (int[] array in matrix)
            {
                if (matrix.Length != array.Length)
                {
                    Console.WriteLine("Matrix is not square");
                    return;
                }
            }
            int max = matrix[0][0];
            foreach (int[] array in matrix)
            {
                foreach (int number in array)
                {
                    if (number > max)
                    {
                        max = number;
                    }
                }
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == max)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
            Console.WriteLine();
            foreach (int[] array in matrix)
            {
                Console.WriteLine();
                foreach (int number in array)
                {
                    Console.Write(number + " ");
                }
            }
        }


        static void Task3(int[] numbers)
        {
            int positive = 0;
            int zero = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i != numbers.Length - 1)
                {
                    if (numbers[i + 1] == 0 && numbers[i] == 0)
                    {
                        zero++;
                    }
                    if (numbers[i + 1] > 0 && numbers[i] > 0)
                    {
                        positive++;
                    }
                }
            }
            Console.WriteLine("Positive: " + positive);
            Console.WriteLine("Zero: " + zero);
        }

        static void MeanMatrix(int[][] matrix)
        {
            if (matrix.Length == 0)
            {
                Console.WriteLine("Matrix is empty");
                return;
            }
            foreach (int[] array in matrix)
            {
                if (matrix.Length != array.Length)
                {
                    Console.WriteLine("Matrix is not square");
                    return;
                }
            }
            int sum = 0;
            foreach (int[] array in matrix)
            {
                foreach (int number in array)
                {
                    sum += number;
                }
            }
            double mean = sum / (matrix.Length * matrix.Length);
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] < mean)
                    {
                        matrix[i][j] = -1;
                        continue;
                    }
                    matrix[i][j] = 1;
                }
            }
            Console.WriteLine("Mean: " + mean);
            foreach (int[] array in matrix)
            {
                Console.WriteLine();
                foreach (int number in array)
                {
                    Console.Write(number + " ");
                }
            }
        }


        static void SumOfRowsWithMax(int[][] matrix)
        {
            int max = matrix[0][0];
            foreach (int[] array in matrix)
            {
                foreach (int number in array)
                {
                    if (number > max)
                    {
                        max = number;
                    }
                }
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                bool isMaxPresent = false;
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == max)
                    {
                        isMaxPresent = true;
                    }
                }
                if (isMaxPresent)
                {
                    int sum = 0;
                    for (int j = 0; j < matrix[0].Length; j++)
                    {
                        sum += matrix[i][j];
                    }
                    Console.WriteLine("Sum of " + (i + 1) + " row: " + sum);
                }
            }
        }


        static void SumOfArray(double[] numbers)
        {
            double sum = 0;
            foreach (double number in numbers)
            {
                sum += number;
            }
            Console.WriteLine("Sum of the array: " + sum);
        }
    }
}