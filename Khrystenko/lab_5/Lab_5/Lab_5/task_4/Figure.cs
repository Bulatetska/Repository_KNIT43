using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_5.task_4
{
    internal class Figure
    {
        protected string name;


        public Figure(string name)
        {
            this.name = name;
        }


        public virtual void Display()
        {
            Console.WriteLine("Figure name: " + name);
        }
    }
}
