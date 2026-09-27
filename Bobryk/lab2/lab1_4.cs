Console.Write("a<100: ");
int a = Convert.ToInt32(Console.ReadLine());

if (a < 10)
{
    Console.WriteLine("Кількість цифр: 1");
    Console.WriteLine("Сума цифр: " + a);
}
else
{
    int first = a / 10;
    int second = a % 10;

    Console.WriteLine("Кількість цифр: 2");
    Console.WriteLine("Сума цифр: " + (first + second));
}