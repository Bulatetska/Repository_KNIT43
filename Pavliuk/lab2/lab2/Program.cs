Random rd = new Random();

//Zadanie 1

Console.WriteLine("\n \n Введіть розмір масиву: ");
int size = Convert.ToInt32(Console.ReadLine());
int[] Zad1 = new int[size];

int max = Zad1[0];
int count = 0;
int firstIndex = -1;

for (int i = 0; i < size; i++)
{
    Zad1[i] = rd.Next(0, 100);
    Console.Write(Zad1[i] + " ");
}
for (int i = 0; i < size; i++)
{
    if (Zad1[i] > max)
    {
        max = Zad1[i];
        count = 0;
        firstIndex = i + 1;
    }
    if (Zad1[i] == max)
    {
        count++;
    }
}
Console.WriteLine("Max number: " + max);
Console.WriteLine("Number of the max: " + count);
Console.WriteLine("Index of the first max: " + firstIndex);


//Zadanie 2 

Console.WriteLine("\n \n Введіть розмір масиву: ");
int size2 = Convert.ToInt32(Console.ReadLine());
int[,] Zad2 = new int[size2, size2];

Console.WriteLine("\n Old matrix: ");
int max2 = Zad2[0, 0];
for (int i = 0; i < size2; i++)
{
    for (int j = 0; j < size2; j++)
    {
        Zad2[i, j] = rd.Next(0, 10);
        if (Zad2[i, j] > max2)
        {
            max2 = Zad2[i, j];
        }
        Console.Write(Zad2[i, j] + " ");
    }
    Console.WriteLine();
}
Console.WriteLine("\n New matrix: ");

for (int i = 0; i < size2; i++)
{
    for (int j = 0; j < size2; j++)
    {
        if (Zad2[i, j] == max2)
        {
            Zad2[i, j] = 0;
        }
        Console.Write(Zad2[i, j] + " ");
    }
    Console.WriteLine();
}

//Zadanie 3

Console.WriteLine("\n \n Введіть розмір масиву: ");
int size3 = Convert.ToInt32(Console.ReadLine());
int[] Zad3 = new int[size3];
Console.WriteLine("\n Matrix: ");
for (int i = 0; i < size3; i++)
{
    Zad3[i] = rd.Next(0, 100);
    Console.Write(Zad3[i] + " ");
}

int plus = 0;
int minus = 0;
for (int i = 1; i < size3; i++)
{
    if (Zad3[i - 1] > 0 && Zad3[i] > 0)
    {
        plus++;
        //Console.WriteLine(Zad3[i - 1] + " " + Zad3[i]);
    }
    else
    {
        if (Zad3[i - 1] == 0 && Zad3[i] == 0)
        {
            minus++;
        }
    }

}
Console.WriteLine("\n Number of the positive numbers: " + plus);
Console.WriteLine("\n Number of the positive numbers: " + minus);


//Zadanie 4 

Console.WriteLine("\n \n Введіть розмір масиву: ");
int size4 = Convert.ToInt32(Console.ReadLine());
int size4_1 = Convert.ToInt32(Console.ReadLine());
int[,] Zad4 = new int[size4, size4_1];

Console.WriteLine("\n Old matrix: ");
int sum4 = 0;
for (int i = 0; i < size4; i++)
{
    for (int j = 0; j < size4_1; j++)
    {
        Zad4[i, j] = rd.Next(0, 10);
        sum4 += Zad4[i, j];
        Console.Write(Zad4[i, j] + " ");
    }
    Console.WriteLine();
}
float aver4 = sum4 / (size4 * size4_1);
Console.WriteLine("\n Average: " + aver4);
Console.WriteLine("\n New matrix: ");
for (int i = 0; i < size4; i++)
{
    for (int j = 0; j < size4_1; j++)
    {
        if (Zad4[i, j] > aver4 || Zad4[i, j] == aver4)
        {
            Zad4[i, j] = 1;
        }
        else
        {
            if (Zad4[i, j] < aver4)
            {
                Zad4[i, j] = -1;
            }
        }
        Console.Write(Zad4[i, j] + " ");
    }
    Console.WriteLine();
}

//Zadanie 5 

int[,] Zad5 = new int[6, 9];

int max5 = Zad5[0, 0];
int num5 = 0;
Console.WriteLine("\n \n Matrix: ");
for (int i = 0; i < 6; i++)
{
    for (int j = 0; j < 9; j++)
    {
        Zad5[i, j] = rd.Next(0, 100);
        Console.Write(Zad5[i, j] + " ");
        if (Zad5[i, j] > max5)
        {
            max5 = Zad5[i, j];
            num5 = i;
        }
    }
    Console.WriteLine();
}
Console.WriteLine("Max number: " + max5);
int sum5 = 0;

for (int j = 0; j < 9; j++)
{
    sum5 += Zad5[num5, j];
}
Console.WriteLine(sum5);

//Zadanie 6 

Console.WriteLine("\n \n Введіть розмір масиву: ");
int size6 = Convert.ToInt32(Console.ReadLine());
int[] Zad6 = new int[size6];

int sum6 = 0;

for (int i = 0; i < size6; i++)
{
    Zad6[i] = rd.Next(-100, 100);
    Console.Write(Zad6[i] + " ");
    sum6 += Zad6[i];
}

Console.WriteLine("Sum number: " + sum6);