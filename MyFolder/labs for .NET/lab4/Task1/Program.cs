using System;

class Person
{
    private string name = "";
    private int age;
    private string gender = "";
    private string phone = "";

    public void SetName(string value)
    {
        name = value;
    }

    public void SetAge(int value)
    {
        age = value;
    }

    public void SetGender(string value)
    {
        gender = value;
    }

    public void SetPhone(string value)
    {
        phone = value;
    }

    public void Print()
    {
        Console.WriteLine("Ім'я: " + name);
        Console.WriteLine("Вік: " + age);
        Console.WriteLine("Стать: " + gender);
        Console.WriteLine("Телефон: " + phone);
    }
}

class Program
{
    static void Main()
    {
        Person person = new Person();

        person.SetName("Олена");
        person.SetAge(20);
        person.SetGender("Жіноча");
        person.SetPhone("0991234567");

        person.Print();
    }
}
