//Zad 1
double a = 8;
double b = 7;
double res = (a + b) / 2;
Console.WriteLine("Середнє арифметичне: ");
Console.WriteLine(res);

//Zad 2
Console.WriteLine("\n To be or not to be \n \\ Shakespeare \\");

//Zad 3
Console.WriteLine("\n");
double num = Convert.ToDouble(Console.ReadLine());
if (num % 2 == 0)
{
    Console.WriteLine(num + " - парне число");
}
else
{
    Console.WriteLine(num + " - не парне число");
}

//Zad 4
int number = Convert.ToInt32(Console.ReadLine());
int sum = 0;
int count = 0;
int temp = number;
while (temp > 0)
{
    sum = sum + temp % 10;
    temp /= 10;
    count++;
}

Console.WriteLine("Кількість: " + count);
Console.WriteLine("Сума: " + sum);

//Zad 5 

string str = Console.ReadLine();
char[] charArray = str.ToCharArray(); 
Array.Reverse(charArray);
string reversedString = new string(charArray); 
Console.WriteLine(reversedString);

//Zad 6
int zad6 = Convert.ToInt32(Console.ReadLine());
int sum6 = 0;
int temp6 = zad6;
while (temp6 > 0)
{ 
    sum6 = sum6 + temp6 % 10;
    temp6 /= 10;
}

Console.WriteLine("Сума: " + sum6);
