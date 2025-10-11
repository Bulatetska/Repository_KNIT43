using System;
namespace ConsoleApplication
{
    class MathOperations
    {
        public event OperationDelegate2 OnOperationPerformed;
        public void RaiseEvent(double result)
        {
            OnOperationPerformed?.Invoke(result);
        }
        public double Add(double a, double b)
        {
            double sum = a + b;
            RaiseEvent(sum);
            Console.WriteLine("Suma: " + sum);
            return sum;
        }
        public double Multiply(double a, double b)
        {
            double mult = a * b;
            RaiseEvent(mult);
            Console.WriteLine("Multiply: " + mult);
            return mult;
        }
    }
    public delegate double OperationDelegate(double a, double b);
    public delegate void OperationDelegate2(double sum);
    class Program
    {
        static void WakeOperation(double res)
        {
            Console.WriteLine("Подія спрацювала! Результат: " + res);
        }
        public static void Main(string[] args)
        {
            OperationDelegate OD = null;
            MathOperations m = new MathOperations();
            Console.WriteLine("Виберіть операцію: \n 1. Додавання \n 2. Множення \n 3. Різниця квадратів двох чисел");
            int oper = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Виберіть перше число:");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Виберіть друге число:");
            double b = Convert.ToDouble(Console.ReadLine());
            switch (oper)
            {
                case 1:
                    OperationDelegate od_add = m.Add;
                    OD = od_add;
                    break;
                case 2:
                    OperationDelegate od_mult = m.Multiply;
                    OD = od_mult;
                    break;
                case 3:
                    OperationDelegate tree = (a, b) => { double riz = Math.Pow(a, 2) - Math.Pow(b, 2); m.RaiseEvent(riz); Console.WriteLine(riz); return riz; };
                    OD = tree;
                    break;
            }
            m.OnOperationPerformed += WakeOperation;
            OD(a, b);
            
        }
    }
}