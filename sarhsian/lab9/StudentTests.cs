using Lab5Classes.Models;
using NUnit.Framework;

namespace Lab9Tests;

[TestFixture, NonParallelizable]
public class StudentTests
{
    [Test]
    public void Constructor_InitializesProperties()
    {
        var student = new Student("Коваль", 3, "СТ-1045");
        Assert.That(student.Surname, Is.EqualTo("Коваль"));
        Assert.That(student.Course, Is.EqualTo(3));
        Assert.That(student.RecordBookNumber, Is.EqualTo("СТ-1045"));
    }

    [Test]
    public void Properties_CanBeChanged()
    {
        var student = new Student("Коваль", 3, "СТ-1045");
        student.Surname = "Бойко";
        student.Course = 4;
        student.RecordBookNumber = "СТ-2000";
        Assert.That(student.Surname, Is.EqualTo("Бойко"));
        Assert.That(student.Course, Is.EqualTo(4));
        Assert.That(student.RecordBookNumber, Is.EqualTo("СТ-2000"));
    }

    [TestCase(0)]
    [TestCase(7)]
    public void Course_InvalidValue_Throws(int course)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Student("Коваль", course, "СТ-1045"));
    }

    [Test]
    public void Print_ShowsStudentData()
    {
        var student = new Student("Коваль", 3, "СТ-1045");
        string text = ConsoleOutput.Capture(student.Print);
        Assert.That(text, Does.Contain("Прізвище: Коваль"));
        Assert.That(text, Does.Contain("Курс: 3"));
        Assert.That(text, Does.Contain("СТ-1045"));
    }

    [Test]
    public void Aspirant_InheritsStudentProperties()
    {
        var aspirant = new Aspirant("Шевченко", 1, "АС-2026", "Аналіз даних");
        aspirant.Course = 2;
        aspirant.DissertationTopic = "Штучний інтелект";
        Assert.That(aspirant, Is.InstanceOf<Student>());
        Assert.That(aspirant.Course, Is.EqualTo(2));
        Assert.That(aspirant.DissertationTopic, Is.EqualTo("Штучний інтелект"));
    }

    [Test]
    public void Aspirant_Print_ThroughStudentReference()
    {
        Student student = new Aspirant("Шевченко", 1, "АС-2026", "Аналіз даних");
        string text = ConsoleOutput.Capture(student.Print);
        Assert.That(text, Does.Contain("Прізвище: Шевченко"));
        Assert.That(text, Does.Contain("Тема дисертації: Аналіз даних"));
    }

    [Test]
    public void Aspirant_EmptyTopic_Throws()
    {
        Assert.Throws<ArgumentException>(() => new Aspirant("Шевченко", 1, "АС-2026", ""));
    }
}
