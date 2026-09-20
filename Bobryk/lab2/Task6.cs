using System;

double[] a = { 1.5, -2.0, 3.5, 4.0, 0.0 };
int n = a.Length;
double sum = 0;

for (int i = 0; i < n; i++)
{
    sum += a[i];
}

Console.WriteLine("Сума елементів масиву: " + sum);
