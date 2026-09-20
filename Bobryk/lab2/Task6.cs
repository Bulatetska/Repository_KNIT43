using System;

double[] a = { 1.5, -2.0, 3.5, 4.0, 0.0 };
double sum = 0;

foreach (double number in a)
{
    sum += number;
}

Console.WriteLine("Сума елементів масиву: " + sum);