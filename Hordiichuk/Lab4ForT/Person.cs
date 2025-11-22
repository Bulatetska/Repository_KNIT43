// Lab4ForT/Person.cs
namespace Lab4ForT
{
    public class Person
    {
        public string Name { get; private set; }
        public int Age { get; set; }
        public string Gender { get; private set; }
        public string Phone { get; private set; }

        public Person(string name, int age, string gender, string phone)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name не може бути порожнім.", nameof(name));
            if (age < 0)
                throw new ArgumentOutOfRangeException(nameof(age), "Age не може бути від’ємним.");
            if (string.IsNullOrWhiteSpace(gender))
                throw new ArgumentException("Gender не може бути порожнім.", nameof(gender));
            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentException("Phone не може бути порожнім.", nameof(phone));

            Name = name;
            Age = age;
            Gender = gender;
            Phone = phone;
        }
    }
}
