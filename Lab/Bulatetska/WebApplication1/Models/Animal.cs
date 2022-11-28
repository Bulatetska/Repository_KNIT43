using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
    {
    class Animal : IPerson
    {
       private string name; // Ім'я
       public int strong; // Сила, генерується випадковим чином
       public static Random random = new Random();
      
        public Animal(string name, int strong)
        {
            this.name = name;
            this.strong = strong;
        }
        public Animal(string name)
        {
            this.name = name;
          
        }
        
        public string Name
        {
            get => name;
            set => name = value;
        }
        public int GetWork()
        { return this.strong; }

        public bool RunAway(IPerson person)
        {
           
            if (this.strong >= person.GetWork())

            return true; 
            else
            return false; 
            }

        public string Say(IPerson person)
        {
            bool c = this.RunAway(person);
            string s = $"Я { this.name}!";
           if (c==true)
            { s = s + $"Я втічу від {person.Name}, бо моя сила {this.strong}, a його {person.GetWork()}" ; }
            else { s = s + $" мене наздожене {person.Name} бо моя сила {this.strong}, a його {person.GetWork()}"; }
            return s;

        }
    }
}
