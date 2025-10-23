using System;

class Program
{
    static void Main(string[] args)
    {
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

        /*static void AmountofMaxandfirstmax(int[] array)
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
            Console.WriteLine($"\n Maximum : {max}");
            Console.WriteLine($"Amout of maximum elements: {count}");
            Console.WriteLine($"Positon of first maximum element: ({position})");
        }
        AmountofMaxandfirstmax(array); */

        /*static void MaxEqualZero(int[,] sixsix)
        {
            int[,] new_matrix = new int[sixsix.GetLength(0), sixsix.GetLength(1)];
            int max = sixsix[0, 0];

            // Знаходимо максимальне значення
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

            Console.WriteLine("\nMatrix 6*6 where maximum number changed to 0:");
            for (int i = 0; i < new_matrix.GetLength(0); i++)
            {
                for (int j = 0; j < new_matrix.GetLength(1); j++)
                {
                    Console.Write(new_matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

       
            Console.WriteLine($"\nMaximum value found: {max}");
            }
            MaxEqualZero(sixsix);*/
       /* static void neighbors(int[] array)
        {
            for(int i=0; i < array.Length; i++)
            {

            }
        }*/
        /*static void avrgchanges(int[,] matrix)

        {
            //int i,j = 0;
            int[,] new_matrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            int sum = 0;
            int count = 0;
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
        }
        avrgchanges(matrix);*/
        /*static void sumofmaxline(int[,] matrix) {
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

             // Descriptive output
             Console.WriteLine($"\nSum of elements in row {maxline} (the row containing the first maximum element): {sum}");
             Console.WriteLine($"Maximum element value found in the matrix: {max}");
             Console.WriteLine($"Row index of the first maximum element: {maxline}");
         }

         sumofmaxline(matrix);*/
        void arraysum(int[] array)
        {
            int suma = 0;
            for(int i=0; i<array.Length ; i++)
            {
                suma += array[i];
            }
            Console.Write($"Sum of array: {suma}");
        }
        arraysum(array);

    }


}