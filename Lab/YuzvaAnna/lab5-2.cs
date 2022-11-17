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


            string s; 
            double x;
            

double y(double x)
{
    double e = 2.71828;
    return   Math.Sqrt(e)* Math.Abs((Math.Abs(x * x - 1)-2));
}

            StreamWriter f = new StreamWriter("Lab2res.txt");
            StreamReader f1 = new StreamReader("Lab2.txt");
            f.WriteLine("Таблиця значень\n");
            f.WriteLine("+-----------------------------+");
            f.WriteLine("+     x       +       y       +");
            f.WriteLine("+-----------------------------+");

   

while ((s=f1.ReadLine())!=null)
{
    x = Convert.ToDouble(s);
    f.WriteLine("+   {0,6}    +   {1,9:f6}   +",x,y(x));
}

         
            f.WriteLine("Yuzva");

            f.Close();
            f1.Close();
        }
    }
}