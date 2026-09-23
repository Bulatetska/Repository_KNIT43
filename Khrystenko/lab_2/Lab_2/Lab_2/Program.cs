namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            SumOfDigitsInNumber();
        }


        static void Mean()
        {
            double n1;
            double n2;
            Console.WriteLine("Enter numbers");
            Console.WriteLine("Number 1: ");
            n1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Number 2: ");
            n2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Mean: " + (n1 + n2) / 2);
        }


        static void Task2()
        {
            string message = """
                To be or not to be
                \ Shakespeare \
                """;
            Console.WriteLine(message);
        }


        static void IsEven()
        {
            Console.WriteLine("Enter number to check:");
            double number = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Entered number is even: " + (number % 2 == 0));
        }


        static void QuantityOfDigitsInNumberAndTheirSum()
        {
            Console.WriteLine("Enter number to check:");
            int number = Convert.ToInt16(Console.ReadLine());
            char[] digits = number.ToString().ToCharArray();
            int quantityOfDigits = digits.Length;
            int sumOfDigits = 0;
            foreach (char digit in digits)
            {
                sumOfDigits += (int) char.GetNumericValue(digit);
            }
            Console.WriteLine("Quantitry of digits in " + number + ": " + quantityOfDigits);
            Console.WriteLine("Sum of digits in " + number + ": " + sumOfDigits);
        }


        static void ReverseNumber()
        {
            Console.WriteLine("Enter number to reverse:");
            int number = Convert.ToUInt16(Console.ReadLine());
            char[] digits = number.ToString().ToCharArray();
            Console.Write("Reversed number: ");
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                Console.Write(digits[i]);
            }
        }


        static void SumOfDigitsInNumber()
        {
            Console.WriteLine("Enter number to check:");
            int number = Convert.ToInt16(Console.ReadLine());
            char[] digits = number.ToString().ToCharArray();
            int sumOfDigits = 0;
            foreach (char digit in digits)
            {
                sumOfDigits += (int)char.GetNumericValue(digit);
            }
            Console.WriteLine("Sum of digits in " + number + ": " + sumOfDigits);
        }
    }
}