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
                N = i;
                if (N % 3 == 0 && N % 5 == 0)
                {
                    Console.WriteLine("The number is a multiple of 3 and 5");
                }
                else if (N % 3 == 0)
                {
                    Console.WriteLine("The number is a multiple of 3");
                }
                else if (N % 5 == 0)
                {
                    Console.WriteLine("The number is a multiple of 5");
                }
                else { Console.WriteLine(N); }
            }
            Console.ReadLine();

            CreateFip("Skoryk", "Denis", "Andriyovuch");

            Console.ReadLine();
        }
        public static void CreateFip(string surname, string name, string pobatkovi) {
            string fip = surname + " " + name + " " + pobatkovi;
            Console.WriteLine(fip);
        }
    }
}
