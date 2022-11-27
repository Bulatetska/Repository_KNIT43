using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        public static string Fio(string surname, string name, string
            otch)
        {
            string fio = surname + " " + name + " " + otch;
            return fio;
        }
        public static string FioInt(string surname, string name, string
           otch)
        {
            string fio = surname + " " + name.Substring(0, 1) + ". " + otch.Substring(0, 1) + ".";
            return fio;
        }

        static void Main(string[] args)
        {
            string surname = "Ярмольський";
            string name = "Вадим";
            string otch = "Iванович";


            Console.WriteLine(Fio(surname, name, otch));
            Console.WriteLine(FioInt(surname, name, otch));
            Console.ReadLine();
        }

    }
}
