using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    interface IPerson
    {
        string Name { get; set; }
       string Say(IPerson person);
        int GetWork(); // Work to be done and quantity

    }
}
