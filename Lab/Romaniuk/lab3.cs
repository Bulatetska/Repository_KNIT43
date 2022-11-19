using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 0;
            for (int i = 0; i <= 100; i++)
            {
                n = i;
                if (n % 3 == 0 && n % 5 == 0)
                {
                    Console.WriteLine("3 and 5");
                }
                else if (n % 3 == 0)
                {
                    Console.WriteLine("of 3");
                }
                else if (n % 5 == 0)
                {
                    Console.WriteLine("5");
                }
                else { Console.WriteLine(n); }
            }
            Console.ReadLine();

            CreateFip("Romaniuk", "Oleksandr", "Mukolayovuch");

            Console.ReadLine();
        }
        public static void CreateFip(string surname, string name, string pobatkovi) {
            string fip = surname + " " + name + " " + pobatkovi;
            Console.WriteLine(fip);
        }
    }
}
