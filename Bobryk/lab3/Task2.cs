using System;

double[,] a =
{
    { 1.5, 9.5, -2.0 },
    { 9.5, 4.0, 6.5 },
    { 3.0, 8.0, 9.5 }
};

int n = a.GetLength(0);
double max = a[0, 0];

Console.WriteLine("Початкова матриця:");

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        Console.Write(a[i, j] + "\t");
    }
    Console.WriteLine();
}

foreach (double number in a)
{
    if (number > max)
    {
        max = number;
    }
}

Console.WriteLine("Матриця після заміни:");

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (a[i, j] == max)
        {
            a[i, j] = 0;
        }

        Console.Write(a[i, j] + "\t");
    }
    Console.WriteLine();
}