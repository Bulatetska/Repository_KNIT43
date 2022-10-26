using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Cat:Animal
    {
        public Cat(string name, int strong) : base(name, strong)
        { }
        public Cat(string name) : base(name)
        { this.strong = random.Next(1, 6); }

        
    }
}
