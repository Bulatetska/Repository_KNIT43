using System;
class program
    {

    static void avg()
        {
            float firstnum;
            float secondnum;

            Console.WriteLine("Calculate the average of two numbers.");
        Console.Write("Enter first number:");
            firstnum = float.Parse(Console.ReadLine());
            Console.Write("Enter second number:");
            secondnum = float.Parse(Console.ReadLine());
            float average= (firstnum + secondnum) / 2;
            Console.WriteLine("The average:" + average);
        }
    static void Shekspir()
    {
        Console.WriteLine("Show a famous quote by William Shakespeare.");
        string quote = "To be, or not to be, that is the question.";
        string author = "William Shakespeare";  
        Console.WriteLine($"{quote}\n {author}");

    }
    static void Even()
    {
        Console.WriteLine("Even and odd numbers.");
        var numbers = new List<int>();
        Console.WriteLine("Enter numbers separated by spaces:");
        var input = Console.ReadLine();
        var numberStrings = input.Split(' ');
        foreach (var numStr in numberStrings)
        {
            if (int.TryParse(numStr, out int num))
            {
                numbers.Add(num);
            }
        }
        var oddNumbers = new List<int>();
        var evenNumbers = new List<int>();
        foreach (var num in numbers)
        {
            if (num % 2 == 0)
            {
                evenNumbers.Add(num);
            }
            else oddNumbers.Add(num);   
        }
        Console.WriteLine("Even numbers:");
        foreach (var num in evenNumbers)
        {
            Console.WriteLine(num);
        }
        Console.WriteLine("Odd numbers:");
        foreach (var num in oddNumbers)
        {
            Console.WriteLine(num);
        }
    }
    static void amountANDsum()
     {
        Console.WriteLine("Amount and sum of digits in a number 99.");
        int a =99;
         int amount = 0;
         int sum = 0;
         while (a > 0)
         {
             int digit = a % 10;
             sum += digit;
             amount++;
             a /= 10;
         }
         Console.WriteLine("Amount of digits: " + amount);
         Console.WriteLine("Sum of digits: " + sum); 
     }
    static void reversed()
    {
        Console.WriteLine("Reversing a number.");
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        int reversednumber = 0;
        int temp = Math.Abs(number);

        while (temp > 0)
        {
            int digit = temp % 10;
            reversednumber = reversednumber * 10 + digit;
            temp /= 10;
        }
        if (number > 0)
        {
          reversednumber = -reversednumber;
        }
          Console.WriteLine("Reversed number: " + reversednumber);
    }
    static void sumOfDigits()
    {
        Console.WriteLine("Sum of digits in a number.");
        Console.WriteLine("Enter a number: ");
         int number = int.Parse(Console.ReadLine());
        int sum = 0;
        while(number >0)
        {
            int digit = number % 10;
            sum += digit;
            number /= 10;
        }
        Console.WriteLine("Sum of digits:" + sum);
    }
        static void Main(string[] args)
    {
        avg();
        Shekspir();
        Even();
        amountANDsum();
        reversed();
        sumOfDigits();
    }

}