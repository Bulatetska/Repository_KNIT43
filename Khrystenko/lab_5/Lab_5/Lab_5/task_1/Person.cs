using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_5.task_1
{
    internal class Person
    {
        private string name;
        private int age;
        private string gender;
        private string phone;

        public Person()
        {
            name = "";
            age = 0;
            gender = "";
            phone = "";
        }

        public Person(string name, int age, string gender, string phone)
        {
            this.name = name;
            SetAge(age);
            this.gender = gender;
            this.phone = phone;
        }


        public void SetName(string newName)
        {
            name = newName;
        }

        public void SetAge(int newAge)
        {
            if (newAge >= 0)
            {
                age = newAge;
            }
            else
            {
                Console.WriteLine("Age below zero");
            }
        }

        public void SetGender(string newGender)
        {
            gender = newGender;
        }

        public void SetPhone(string newPhone)
        {
            phone = newPhone;
        }

        public void Print()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("Gender: " + gender);
            Console.WriteLine("Phone: " + phone);
        }
    }
}
