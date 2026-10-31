namespace ClassesLab;
public class Person
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Gender { get; private set; }
    public string Phone { get; private set; }
    public Person(string name, int age, string gender, string phone)
    { Name = name; Age = age; Gender = gender; Phone = phone; }
    public void SetName(string value) => Name = value;
    public void SetAge(int value) => Age = value;
    public void SetGender(string value) => Gender = value;
    public void SetPhone(string value) => Phone = value;
    public void Print() => Console.WriteLine($"Ім'я: {Name}; Вік: {Age}; Стать: {Gender}; Телефон: {Phone}");
}
