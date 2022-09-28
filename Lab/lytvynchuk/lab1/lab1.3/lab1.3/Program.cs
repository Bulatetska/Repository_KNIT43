using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace lab1._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                for (int i = 1; i <= 100; i++)
                {
                    if (i % 3 == 0 && i % 5 == 0)
                    {
                        Console.WriteLine(i + "  / 3 & / 5");
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
            }
            {
                public static string FFIO(string s, string n, string p)
                {
                    string fio = s + " " + n + " " + p;
                    return fio;
                }
                public static string CFIO(string s, string n, string p)
                {
                    string fio = s + " " + n.Substring(0, 1) + ". " + p.Substring(0, 1) + ".";
                    return fio;
                }
                string[,] FIO = {
                        {"Shevchenko", "Taras", "Grugurovych"},
                        {"Kosach", "Larysa", "Petrivna"},
                        {"Franko", "Ivan", "Yakovych"}
                                };
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(FFIO(FIO[i, 0], FIO[i, 1], FIO[i, 2]));
                    Console.WriteLine(CFIO(FIO[i, 0], FIO[i, 1], FIO[i, 2]));
                }
                Console.ReadLine();
            }
        }
    }
}
