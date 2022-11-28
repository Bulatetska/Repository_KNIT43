using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class RunCatDog
    {
      

        public string Run()
        {
            Dog d = new Dog("Рекс");
           Cat c = new Cat("Рудько");
            return c.Say(d);
        }

    }

}