using System;

int[,] a =
{
    { 2, 5, 8 },
    { 4, 5, 6 }
};

int n = a.GetLength(0);
int m = a.GetLength(1);
double sum = 0;

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        sum += a[i, j];
    }
}

double avg = sum / (n * m);

Console.WriteLine("Середнє арифметичне: " + avg);
Console.WriteLine("Матриця після заміни:");

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        if (a[i, j] < avg)
        {
            a[i, j] = -1;
        }
        else if (a[i, j] > avg)
        {
            a[i, j] = 1;
        }

        Console.Write(a[i, j] + "\t");
    }
    Console.WriteLine();
}
