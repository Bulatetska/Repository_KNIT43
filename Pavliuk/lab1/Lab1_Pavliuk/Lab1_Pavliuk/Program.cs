//Zad 1
Console.WriteLine("Завдання 1");
double a = 8;
double b = 7;
double res = (a + b) / 2;
Console.WriteLine("Середнє арифметичне: ");
Console.WriteLine(res);

//Zad 2
Console.WriteLine("\n Завдання 2");
Console.WriteLine("To be or not to be \n \\ Shakespeare \\");

//Zad 3
Console.WriteLine("\n Завдання 3");
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
Console.Write("\n Завдання 4 \n Введіть натуральне число до 100 - ");
int number = Convert.ToInt32(Console.ReadLine());
if (number >= 100) {
    Console.Write("Введене число є більшим 100.");
}
else
{
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
}

//Zad 5 
Console.Write("\n Завдання 5 \n Введіть число для його перевертання - ");
string str = Console.ReadLine();
char[] charArray = str.ToCharArray();
Array.Reverse(charArray);
string reversedString = new string(charArray);
Console.WriteLine("Перевернене число " + reversedString);

//Zad 6
Console.Write("\n Завдання 6 \n Введіть число для підрахунку цифр - ");
int zad6 = Convert.ToInt32(Console.ReadLine());
int sum6 = 0;
int temp6 = zad6;
while (temp6 > 0)
{
    sum6 = sum6 + temp6 % 10;
    temp6 /= 10;
}

Console.WriteLine("Сума цифр числа " + zad6 + " : " + sum6);
