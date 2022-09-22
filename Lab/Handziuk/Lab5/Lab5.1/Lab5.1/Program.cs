using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input surname ");
            string name = Console.ReadLine();
            Console.WriteLine("Input A ");  //99,35
            float a = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Input I ");  //72
            int i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input C ");  //1995
            int c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input L ");   //true
            bool l = Convert.ToBoolean(Console.ReadLine());

            System.Console.WriteLine("Результати формування    \n name = {0,6}, l = {1,4}",name,l);
            System.Console.WriteLine("a = {0,4}, c = {0,10:f5}, i = {2,20:e8},", a, c, i);
            System.Console.WriteLine(" ");
            Console.ReadLine();
        }
    }
}
