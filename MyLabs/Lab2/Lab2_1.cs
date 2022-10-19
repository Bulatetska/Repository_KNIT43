using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        static void Task1(int num) {
            Random rnd = new Random();
            int[] m = new int[num];
            
            int numberOfMax = 0;

            for (int i = 0; i < num; i++)
            {
                m[i] = rnd.Next() % 10;
                Console.Write(m[i] + " ");
                
            }
            Console.WriteLine();
            int max = m.Max();
            for (int i = 0; i < num; i++)
            {
                if (m[i] == max)
                {
                    numberOfMax++;
                }
            }
            int index = Array.IndexOf(m, max);
            Console.WriteLine("Max value: {0} ", max);
            Console.WriteLine("Count of max values: {0} ", numberOfMax);
            Console.WriteLine("Index of first element: {0} ", index);
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
        }

        static void Task2(int num) {
            int n = num;
            int[,] m = new int[n, n];
            int max = 0;
            Random rnd = new Random();
            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++) {
                    m[i, j] = rnd.Next() % 10;
                    Console.Write(m[i, j] + " ");
                    if (max < m[i, j]) max = m[i, j];
                }
                Console.WriteLine("");
            }
            Console.WriteLine("Max element: {0}", max);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (m[i, j] == max) m[i, j] = 0;
                    Console.Write(m[i, j] + " ");
                }
                Console.WriteLine("");
            }
            Console.ReadLine();
        }

        static void Task3(int num) {
            int[] m = new int[num];
            Random rnd = new Random();
            for (int i = 0; i < num; i++) {
                m[i] = rnd.Next() % 10;
                Console.Write(m[i] + " ");
            }
            Console.WriteLine();
            int bt0 = 0;
            int n = 0;
            for (int i = 0; i < num-1; i++)
            {
                if (m[i] > 0 && m[i + 1] > 0)
                {
                    bt0++;
                }
                else if (m[i] == 0 && m[i + 1] == 0) 
                {
                    n++;
                }
            }
            Console.WriteLine("Positive pairs : {0}", bt0);
            Console.WriteLine("Zero pairs : {0}", n);
            Console.ReadLine();
        }

        static void Task4(int n, int m) {
            Random rnd = new Random();
            int[,] arr = new int[n, m];
            int Sum = 0;
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = rnd.Next() % 10;
                    Console.Write(arr[i, j] + "  ");
                    Sum += arr[i, j];
                }
                Console.WriteLine("");
            }
            float ArM = Sum / (n * m);
            Console.WriteLine("Suma: {0}", Sum);
            Console.WriteLine("Arithmetic mean: {0}", ArM);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (arr[i, j] < ArM) {
                        arr[i, j] = -1;
                    }
                    else if (arr[i, j] > ArM)
                    {
                        arr[i, j] = 1;
                    }
                    Console.Write(arr[i, j] + "  ");
                }
                Console.WriteLine("");
            }
            Console.ReadLine();
        }

        static void Task5()
        {
            int[,] m = new int[6, 9];
            Random rnd = new Random();
            int max = 0;
            int row = 0;
            int Sum = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    m[i, j] = rnd.Next() % 100;
                    Console.Write(m[i, j] + " ");
                    if (m[i, j] > max) max = m[i, j];
                }
                Console.WriteLine("");
            }
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (m[i, j] == max) row = i;
                }
            }
            for (int i = 0; i < 9; i++) {
                Sum += m[row, i];
            }
            Console.WriteLine("Max element: {0}", max);
            Console.WriteLine("Row: {0}", row+1);
            Console.WriteLine("Suma: {0}", Sum);
            Console.ReadLine();
        }

        static void Task6(int num) {
            float[] m = new float[num];
            Random rnd = new Random();
            float Sum = 0;
            for (int i = 0; i < num; i++) {
                m[i] = rnd.Next() % 1000;
                Console.Write(m[i] + " ");
                Sum += m[i];
            }
            Console.WriteLine();
            Console.WriteLine("Suma: {0}", Sum);
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
                Console.WriteLine("Task 1:");
                Task1(5);
                Console.WriteLine("Task 2:");
                Task2(5);
                Console.WriteLine("Task 3:");
                Task3(5);
                Console.WriteLine("Task 4:");
                Task4(2,4);
                Console.WriteLine("Task 5:");
                Task5();
                Console.WriteLine("Task 6:");
                Task6(5);
        }
    }
}
