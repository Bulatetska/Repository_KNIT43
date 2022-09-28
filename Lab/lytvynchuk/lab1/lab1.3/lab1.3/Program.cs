using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine(i + "  / 3 and / 5");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine(i + "  / 3");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine(i + "  / 5");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
            Console.ReadLine();
        }
    }
}
