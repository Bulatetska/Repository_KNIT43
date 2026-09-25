using System;

double[] A = { 2.5, 4.7, 1.3, 6.2, 3.8 };

double sum = 0;

foreach (double number in A)
{
    sum += number;
}

Console.WriteLine("Сума елементів масиву: " + sum);