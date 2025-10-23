using System;

class Program
{
    static void Main(string[] args)
    {
        ConsoleColor originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n");
        Console.WriteLine("Матриця окрім 6*6, для всіх завдань, так само і масив\n");
        Console.ForegroundColor = originalColor;


        // Матриця 6x6
        int[,] sixsix = {
            {95, 23, 42, 18, 56, 33},
            {29, 67, 95, 88, 25, 47},
            {38, 72, 91, 12, 64, 19},
            {55, 31, 76, 44, 83, 27},
            {49, 62, 95, 37, 21, 58},
            {13, 79, 26, 53, 68, 41}
        };

        // Виводимо оригінальну матрицю
        Console.WriteLine("Original 6x6 matrix:");
        for (int i = 0; i < sixsix.GetLength(0); i++)
        {
            for (int j = 0; j < sixsix.GetLength(1); j++)
            {
                Console.Write(sixsix[i, j] + "\t");
            }
            Console.WriteLine();
        }

        Random random = new Random();
        int rows = 6;
        int cols = 9;
        int[,] matrix = new int[rows, cols];

        // Fill matrix
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = random.Next(1, 100);
            }
        }

        // Print generated matrix
        Console.WriteLine("\nGenerated 6x9 matrix:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
        int[] array = new int[] { 1, 2,0,0 , 4, -4,-2, 4, 10, 3,0,0, -1, 5 };
        Console.WriteLine("Index and its meaning");
        for(int i=0; i<array.Length; i++)
            
        {
            Console.Write(i+"  ");
        }
        Console.WriteLine();
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + "  ");
        }
        Console.WriteLine();

        static void AmountofMaxandfirstmax(int[] array)
        {
            int max = array[0];
            int count = 0;
            int position = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {

                if (array[i] > max)
                {
                    max = array[i];
                    count = 1;
                    position = i;

                }
                else if (array[i] == max)
                {
                    count++;
                }

            }
            Console.WriteLine("Задати одновимірний масив цілих чисел A[і], де і =1,2,…,n. Визначити та вивести на екран, скільки разів максимальний елемент зустрічається у даному масиві та порядковий номер першого найбільшого елементу. ");
            Console.WriteLine($"Maximum : {max}");
            Console.WriteLine($"Amout of maximum elements: {count}");
            Console.WriteLine($"Positon of first maximum element: ({position})");
            Console.WriteLine();
        }
            AmountofMaxandfirstmax(array); 

        static void MaxEqualZero(int[,] sixsix)
        {
            int[,] new_matrix = new int[sixsix.GetLength(0), sixsix.GetLength(1)];
            int max = sixsix[0, 0];

            for (int i = 0; i < sixsix.GetLength(0); i++)
            {
                for (int j = 0; j < sixsix.GetLength(1); j++)
                {
                    if (sixsix[i, j] > max)
                    {
                        max = sixsix[i, j];
                    }
                }
            }
                Console.WriteLine("Задати квадратну дійсну матрицю порядку n. Усі максимальні елементи матриці замінити нулями. Задану матрицю та результуючу вивести на екран. ");
            // Заповнюємо нову матрицю
            for (int i = 0; i < sixsix.GetLength(0); i++)
            {
                for (int j = 0; j < sixsix.GetLength(1); j++)
                {
                    if (sixsix[i, j] == max)
                    {
                        new_matrix[i, j] = 0;
                    }
                    else
                    {
                        new_matrix[i, j] = sixsix[i, j];
                    }
                }
            }

            Console.WriteLine("Matrix 6*6 where maximum number changed to 0:");
            for (int i = 0; i < new_matrix.GetLength(0); i++)
            {
                for (int j = 0; j < new_matrix.GetLength(1); j++)
                {
                    Console.Write(new_matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            
            Console.WriteLine($"Maximum value found: {max}");
            Console.WriteLine();
        }
            MaxEqualZero(sixsix);
        static void neighbors(int[] array)
        {
            int nullneighbors = 0;
            int positivebors = 0;

            for(int i=0; i < array.Length-1; i++)
            {
                if (array[i]>0 && array[i+1]>0)
                    positivebors++;
                if (array[i] == 0 && array[i + 1] == 0)
                    nullneighbors++;
            }
            Console.WriteLine("Задати одновимірний масив цілих чисел A[і], де і =1,2,…,n. Визначити та вивести на екран кількість пар сусідніх елементів," +
                " у яких обидва елементи більше нуля, а також кількість пар сусідніх елементів, �� яких обидва елементи дорівнюють нулю. ");
            Console.Write($"Amout neighbors that more then 0: {positivebors} amout of pairs that equal to 0: {nullneighbors}");
            Console.WriteLine();
            Console.WriteLine();
        }
        neighbors(array);

        static void avrgchanges(int[,] matrix)

        {
            
            int[,] new_matrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            int sum = 0;
            int count = 0;
            Console.WriteLine("Задати дійсну матрицю розмірності m x n. Знайти середнє арифметичне всіх елементів матриці. Утворити нову матрицю того самого розміру," +
                " елементи якої приймають значення -1, якщо відповідний елемент початкової матриці менший за середнє арифметичне, і 1 - якщо більший або дорівнює середньому арифметичному. " +
                "Вивести на екран початкову та утворену матриці. ");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += matrix[i, j];
                    count++;
                }
            }
            int average = sum / count;

            for (int i = 0; i < new_matrix.GetLength(0); i++)
            {
                for (int j = 0; j < new_matrix.GetLength(1); j++)
                {
                    if (average < matrix[i, j])
                    {
                        new_matrix[i, j] = -1;
                    }
                    else new_matrix[i, j] = 1;
                }
            }
            Console.WriteLine("If less then average is -1, else 1 ");
            Console.WriteLine($"The average is: {average}");

            for (int i = 0; i < new_matrix.GetLength(0); i++)
            {
                for (int j = 0; j < new_matrix.GetLength(1); j++)
                {
                    Console.Write(new_matrix[i, j] + "\t");
                }
                Console.WriteLine();

            }
            Console.WriteLine();
        }     
        avrgchanges(matrix);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Навіть якщо в двох або більше рядках буде максимум, буде обрано перший для підрахунку суми рядка тому що наступні максимуми будуть ігноруватися наприклад:" +
            "Перший і друший рядок має 3 максимуми але другий не рахується тому що він не може стати новим максимумом 3!> max, тому рахується перший рядок ");
        Console.ForegroundColor = originalColor;

        static void sumofmaxline(int[,] matrix) {
             int sum = 0;
             int max = matrix[0, 0];
             int maxline = 0;
             for (int i = 0; i < matrix.GetLength(0); i++)
             {
                 for (int j = 0; j < matrix.GetLength(1); j++)
                 {
                     if (matrix[i, j] > max)
                     {
                         max = matrix[i, j];
                         maxline = i;
                     }

                 }
             }
             for (int j = 0; j < matrix.GetLength(1); j++)
             {
                 sum += matrix[maxline, j];
             }

             Console.WriteLine("Задати матрицю розмірністю 6 х 9 та знайти суму елементів рядка, який містить найбільший елемент. Вважається, що такий елемент в матриці єдиний.");
            Console.WriteLine($"Sum of elements in row {maxline} (the row containing the first maximum element): {sum}");
             Console.WriteLine($"Maximum element value found in the matrix: {max}");
             Console.WriteLine($"Row index of the first maximum element: {maxline}");
            Console.WriteLine();
         }

         sumofmaxline(matrix);
        void arraysum(int[] array)
        {   Console.WriteLine("Задати одновимірний масив цілих чисел A[і], де і =1,2,…,n. Знайти суму всіх елементів масиву.");
            int suma = 0;
            for(int i=0; i<array.Length ; i++)
            {
                suma += array[i];
            }
            Console.Write($"Sum of array: {suma}");
            Console.WriteLine();
        }
        arraysum(array);

    }


}