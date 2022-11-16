using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s; double x, y;
            double e = 2.71828;
            StreamWriter f = new StreamWriter("Lab2res.txt");
            StreamReader f1 = new StreamReader("Lab2.txt");
            f.WriteLine("Таблиця значень\n");
            f.WriteLine("********************");
        mitka: s = f1.ReadLine();
            if (s == null) goto mitka1;

            x = Convert.ToDouble(s);
            y = (Math.Sqrt(e))* (Math.Abs((Math.Abs(x * x - 1))-2));
            f.WriteLine("* x = {0:F3}  * y = {0:F3} *\n ********************", x, y);
            f.WriteLine();
            goto mitka;
        mitka1: f.WriteLine("Склала Юзва А. С.");
            f.Close();
            f1.Close();
        }
    }
}