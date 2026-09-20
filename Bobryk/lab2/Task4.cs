using System;

int[,] a =
{
    { 2, 5, 8 },
    { 4, 5, 6 }
};

int n = a.GetLength(0);
int m = a.GetLength(1);
double sum = 0;

foreach (int number in a)
{
    sum += number;
}

double average = sum / (n * m);

Console.WriteLine("Середнє арифметичне: " + average);
Console.WriteLine("Матриця після заміни:");

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        if (a[i, j] < average)
        {
            a[i, j] = -1;
        }
        else if (a[i, j] > average)
        {
            a[i, j] = 1;
        }

        Console.Write(a[i, j] + "\t");
    }
    Console.WriteLine();
}