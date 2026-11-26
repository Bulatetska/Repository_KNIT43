using Lab5Classes.Models;
using NUnit.Framework;

namespace Lab9Tests;

[TestFixture, NonParallelizable]
public class PersonTests
{
    private static Person CreatePerson() => new("Олександр", 20, "чоловіча", "123456");

    [Test]
    public void Print_ShowsInitialData()
    {
        var person = CreatePerson();
        string text = ConsoleOutput.Capture(person.Print);
        Assert.That(text, Does.Contain("Ім'я: Олександр"));
        Assert.That(text, Does.Contain("Вік: 20"));
        Assert.That(text, Does.Contain("Стать: чоловіча"));
        Assert.That(text, Does.Contain("Телефон: 123456"));
    }

    [Test]
    public void SetName_ChangesName()
    {
        var person = CreatePerson();
        person.SetName("  Андрій  ");
        Assert.That(ConsoleOutput.Capture(person.Print), Does.Contain("Ім'я: Андрій"));
    }

    [Test]
    public void SetAge_ChangesAge()
    {
        var person = CreatePerson();
        person.SetAge(21);
        Assert.That(ConsoleOutput.Capture(person.Print), Does.Contain("Вік: 21"));
    }

    [Test]
    public void SetGender_ChangesGender()
    {
        var person = CreatePerson();
        person.SetGender("жіноча");
        Assert.That(ConsoleOutput.Capture(person.Print), Does.Contain("Стать: жіноча"));
    }

    [Test]
    public void SetPhoneNumber_ChangesPhone()
    {
        var person = CreatePerson();
        person.SetPhoneNumber("987654");
        Assert.That(ConsoleOutput.Capture(person.Print), Does.Contain("Телефон: 987654"));
    }

    [TestCase(-1)]
    [TestCase(121)]
    public void SetAge_InvalidValue_Throws(int age)
    {
        var person = CreatePerson();
        Assert.Throws<ArgumentOutOfRangeException>(() => person.SetAge(age));
    }

    [Test]
    public void SetName_EmptyValue_Throws()
    {
        Assert.Throws<ArgumentException>(() => CreatePerson().SetName(" "));
    }

    [Test]
    public void SetGender_EmptyValue_Throws()
    {
        Assert.Throws<ArgumentException>(() => CreatePerson().SetGender(""));
    }

    [Test]
    public void SetPhoneNumber_EmptyValue_Throws()
    {
        Assert.Throws<ArgumentException>(() => CreatePerson().SetPhoneNumber(""));
    }
}
