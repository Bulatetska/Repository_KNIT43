using System;

class Person
{
    private string name;
    private int age;
    private string gender;
    private string phone;

    public Person(string name, int age, string gender, string phone)
    {
        this.name = name;
        this.age = age;
        this.gender = gender;
        this.phone = phone;
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public void SetAge(int age)
    {
        this.age = age;
    }

    public void SetGender(string gender)
    {
        this.gender = gender;
    }

    public void SetPhone(string phone)
    {
        this.phone = phone;
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
        Person person = new Person("Артем", 20, "Чоловіча", "0991234567");

        Console.WriteLine("Початкові дані:");
        person.Print();

        person.SetAge(21);
        //person.SetPhone("0681234567");

        Console.WriteLine("\nПісля зміни:");
        person.Print();
    }
}
