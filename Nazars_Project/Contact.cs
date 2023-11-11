using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class Contact
    {

        private string name;
        private string emailAddress;
        private string phoneNumber;
        private int age;
        private string sex;
        private DateTime birthday;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

       
        public Contact(string name, string email, string phone, int age, string sex, DateTime birthday)
        {
            Name = name;
            EmailAddress = email;
            PhoneNumber = phone;
            Age = age;
            Sex = sex;
            Birthday = birthday;
        }

        
        public override string ToString()
        {
            return $"Name: {Name}\nEmail: {EmailAddress}\nPhone: {PhoneNumber}\nAge: {Age}\nSex: {Sex}\nBirthday: {Birthday.ToShortDateString()}";
        }
    }
}
