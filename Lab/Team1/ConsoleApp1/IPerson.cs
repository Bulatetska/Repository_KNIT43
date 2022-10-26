using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface IPerson
    {
       string Name { get; set; }
       string Say(IPerson person);
       int GetWork(); // Work to be done and quantity

    }
}
