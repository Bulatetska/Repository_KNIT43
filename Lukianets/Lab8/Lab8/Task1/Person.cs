using System;

namespace PersonClass
{
    public class Person
    {
        private string name;
        private int age;
        private string gender;
        private string phoneNumber;

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Gender { get => gender; set => gender = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        public Person(string name, int age, string gender, string phoneNumber)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.phoneNumber = phoneNumber;
        }

        public void Print()
        {
            Console.WriteLine($"Name: {name}, Age: {age}, Gender: {gender}, Phone: {phoneNumber}");
        }
    }
}
