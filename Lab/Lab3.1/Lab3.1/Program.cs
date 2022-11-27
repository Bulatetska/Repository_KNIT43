using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                 if (i % 3 == 0 && i % 5 == 0 )
                {
                    Console.WriteLine("kratne 3 i 5");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine(" kratne 3");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine(" kratne 5");
                }
          
                else { Console.WriteLine(i.ToString()); }
            }
            Console.ReadLine();
        }
    }
}
