using System;
class Program
{
 static void Main(){
Random rand = new Random();
double[] array = new double[20];
int pos = 0;
int zero = 0;
for(int i = 0; i < 20; i++)
{
    array[i] = rand.Next(-100, 100);
    Console.Write(array[i]+" ");
}
for(int i = 1; i < 20; i++)
{
    if (array[i] > 0 && array[i-1]>0)
    {
        pos++;
    }
    if (array[i] == 0 && array[i-1]==0)
    {
        zero++;
    }
}
Console.WriteLine("\nСусідства доданіх - " + pos + ", сусідства нульових - " + zero);
}
}  
