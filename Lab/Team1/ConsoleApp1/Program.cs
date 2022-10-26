using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog d = new Dog("Рекс");
          //  Dog d1 = new Dog("Бобік");
            Cat c = new Cat("Рудько");
            Console.WriteLine(c.Say(d));
            Console.WriteLine(d.Say(c));
           // Console.WriteLine(d.Say(d1));
            Console.ReadLine();

        }
    }
}
