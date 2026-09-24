using System;

class Program
{
    static void Main()
    {
        //1. Кількість максимальних елементів та номер першого максимального
        Console.WriteLine("ЗАВДАННЯ 1");

        Console.Write("Введіть n: ");
        int n1 = int.Parse(Console.ReadLine());

        int[] A1 = new int[n1];

        Console.WriteLine("Введіть елементи масиву:");
        for (int i = 0; i < n1; i++)
        {
            A1[i] = int.Parse(Console.ReadLine());
        }

        int max1 = A1[0];

        for (int i = 1; i < n1; i++)
        {
            if (A1[i] > max1)
            {
                max1 = A1[i];
            }
        }

        int count1 = 0;
        int firstMax1 = 0;

        for (int i = 0; i < n1; i++)
        {
            if (A1[i] == max1)
            {
                count1++;

                if (count1 == 1)
                {
                    firstMax1 = i + 1;
                }
            }
        }

        Console.WriteLine("Максимальний елемент: " + max1);
        Console.WriteLine("Кількість максимальних елементів: " + count1);
        Console.WriteLine("Порядковий номер першого максимального: " + firstMax1);


        //2. Замінити всі максимальні елементи матриці нулями
        Console.WriteLine("\nЗАВДАННЯ 2");

        Console.Write("Введіть n: ");
        int n2 = int.Parse(Console.ReadLine());

        double[,] A2 = new double[n2, n2];

        Console.WriteLine("Введіть елементи матриці:");

        for (int i = 0; i < n2; i++)
        {
            for (int j = 0; j < n2; j++)
            {
                A2[i, j] = double.Parse(Console.ReadLine());
            }
        }

        double max2 = A2[0, 0];

        for (int i = 0; i < n2; i++)
        {
            for (int j = 0; j < n2; j++)
            {
                if (A2[i, j] > max2)
                {
                    max2 = A2[i, j];
                }
            }
        }

        Console.WriteLine("\nПочаткова матриця:");

        for (int i = 0; i < n2; i++)
        {
            for (int j = 0; j < n2; j++)
            {
                Console.Write(A2[i, j] + "\t");
            }

            Console.WriteLine();
        }

        for (int i = 0; i < n2; i++)
        {
            for (int j = 0; j < n2; j++)
            {
                if (A2[i, j] == max2)
                {
                    A2[i, j] = 0;
                }
            }
        }

        Console.WriteLine("\nРезультуюча матриця:");

        for (int i = 0; i < n2; i++)
        {
            for (int j = 0; j < n2; j++)
            {
                Console.Write(A2[i, j] + "\t");
            }

            Console.WriteLine();
        }


        //3. Кількість сусідств двох додатних та двох нульових чисел        
        Console.WriteLine("\nЗАВДАННЯ 3");

        Console.Write("Введіть n: ");
        int n3 = int.Parse(Console.ReadLine());

        double[] A3 = new double[n3];

        Console.WriteLine("Введіть елементи послідовності:");

        for (int i = 0; i < n3; i++)
        {
            A3[i] = double.Parse(Console.ReadLine());
        }

        int positivePairs = 0;
        int zeroPairs = 0;

        for (int i = 0; i < n3 - 1; i++)
        {
            if (A3[i] > 0 && A3[i + 1] > 0)
            {
                positivePairs++;
            }

            if (A3[i] == 0 && A3[i + 1] == 0)
            {
                zeroPairs++;
            }
        }

        Console.WriteLine("Кількість сусідств двох додатних чисел: " + positivePairs);
        Console.WriteLine("Кількість сусідств двох нульових елементів: " + zeroPairs);


        //4. Замінити елементи матриці відносно середнього арифметичного
        Console.WriteLine("\nЗАВДАННЯ 4");

        Console.Write("Введіть n: ");
        int n4 = int.Parse(Console.ReadLine());

        Console.Write("Введіть m: ");
        int m4 = int.Parse(Console.ReadLine());

        int[,] A4 = new int[n4, m4];

        int sum4 = 0;

        Console.WriteLine("Введіть елементи матриці:");

        for (int i = 0; i < n4; i++)
        {
            for (int j = 0; j < m4; j++)
            {
                A4[i, j] = int.Parse(Console.ReadLine());
                sum4 += A4[i, j];
            }
        }

        double average4 = (double)sum4 / (n4 * m4);

        Console.WriteLine("Середнє арифметичне: " + average4);

        for (int i = 0; i < n4; i++)
        {
            for (int j = 0; j < m4; j++)
            {
                if (A4[i, j] < average4)
                {
                    A4[i, j] = -1;
                }
                else if (A4[i, j] > average4)
                {
                    A4[i, j] = 1;
                }
            }
        }

        Console.WriteLine("\nРезультуюча матриця:");

        for (int i = 0; i < n4; i++)
        {
            for (int j = 0; j < m4; j++)
            {
                Console.Write(A4[i, j] + "\t");
            }

            Console.WriteLine();
        }


        //5. Сума елементів рядка, що містить найбільший елемент    
        Console.WriteLine("\nЗАВДАННЯ 5");

        int[,] A5 = new int[6, 9];

        Console.WriteLine("Введіть елементи матриці 6 x 9:");

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                A5[i, j] = int.Parse(Console.ReadLine());
            }
        }

        int max5 = A5[0, 0];
        int maxRow5 = 0;

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (A5[i, j] > max5)
                {
                    max5 = A5[i, j];
                    maxRow5 = i;
                }
            }
        }

        int sum5 = 0;

        for (int j = 0; j < 9; j++)
        {
            sum5 += A5[maxRow5, j];
        }

        Console.WriteLine("Максимальний елемент: " + max5);
        Console.WriteLine("Номер рядка: " + (maxRow5 + 1));
        Console.WriteLine("Сума елементів цього рядка: " + sum5);


//6. Сума елементів одновимірного масиву 
        Console.WriteLine("\nЗАВДАННЯ 6");

        Console.Write("Введіть n: ");
        int n6 = int.Parse(Console.ReadLine());

        double[] A6 = new double[n6];

        double sum6 = 0;

        Console.WriteLine("Введіть елементи масиву:");

        for (int i = 0; i < n6; i++)
        {
            A6[i] = double.Parse(Console.ReadLine());
            sum6 += A6[i];
        }

        Console.WriteLine("Сума елементів масиву: " + sum6);

        Console.WriteLine("\nКІНЕЦЬ");
    }
}