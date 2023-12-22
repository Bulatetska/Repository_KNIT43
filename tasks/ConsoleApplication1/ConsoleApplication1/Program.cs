using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //task1
            System.Console.WriteLine("Hello word");
            
            //task2
            string stringToShow1, stringToShow2;
            string surname = "Johnson";
            string name = "Joe";
            string secondname = "Yu";

            int age = 40;
            double weight = 88.73;

            stringToShow1 = surname + " " + name + " " + secondname + ", age " + age + ", weight " + weight;
            surname = "Marcus";
            name = "Alex";
            secondname = "Fu";
            age = 23;
            weight = 66;

            stringToShow2 = surname + " " + name + " " + secondname + ", age " + age + ", weight " + weight;
            System.Console.WriteLine(stringToShow1);
            System.Console.WriteLine(stringToShow2);
            
            //task3
            int a = 5;
            int b = 2;
            System.Console.WriteLine("a = " + a + ", b = " + b);
            int result = a + b;
            System.Console.WriteLine("Додавання, a + b = " + result);
            result = a * b;
            System.Console.WriteLine("Множення, a * b = " + result);
            result = a / b;
            System.Console.WriteLine("Ділення, a / b = " + result + " а та b - цілі числа, результат - текст");
            double resultDouble = a / b;
            System.Console.WriteLine("Ділення, a / b = " + resultDouble + " помилка...");
            double aDouble = 5;
            resultDouble = aDouble / b;
            System.Console.WriteLine("Ділення, a / b = " + resultDouble);
            System.Console.ReadLine();
        }
    }
}