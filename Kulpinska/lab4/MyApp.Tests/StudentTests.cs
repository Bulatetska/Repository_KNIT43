using NUnit.Framework;
using MyApp;
using System;

namespace StudentTests
{
    [TestFixture]
    public class StudentTests
    {
        [Test]
        public void Student_SettersAndGetters_WorkCorrectly()
        {
            var student = new Student("Ivanov", 2, "RB123");

            Assert.That(student.LastName, Is.EqualTo("Ivanov"));
            Assert.That(student.Course, Is.EqualTo(2));
            Assert.That(student.RecordBook, Is.EqualTo("RB123"));

            student.LastName = "Petrov";
            student.Course = 3;
            student.RecordBook = "RB456";

            Assert.That(student.LastName, Is.EqualTo("Petrov"));
            Assert.That(student.Course, Is.EqualTo(3));
            Assert.That(student.RecordBook, Is.EqualTo("RB456"));
        }

        [Test]
        public void Student_Print_DoesNotThrow()
        {
            var student = new Student("Ivanov", 2, "RB123");
            Assert.DoesNotThrow(() => student.Print());
        }
    }

    [TestFixture]
    public class AspirantTests
    {
        [Test]
        public void Aspirant_SettersAndGetters_WorkCorrectly()
        {
            var aspirant = new Aspirant("Sidorov", 1, "RB789", "AI Dissertation");

            Assert.That(aspirant.LastName, Is.EqualTo("Sidorov"));
            Assert.That(aspirant.Course, Is.EqualTo(1));
            Assert.That(aspirant.RecordBook, Is.EqualTo("RB789"));
            Assert.That(aspirant.Dissertation, Is.EqualTo("AI Dissertation"));

            aspirant.LastName = "Kovalenko";
            aspirant.Course = 2;
            aspirant.RecordBook = "RB101";
            aspirant.Dissertation = "ML Dissertation";

            Assert.That(aspirant.LastName, Is.EqualTo("Kovalenko"));
            Assert.That(aspirant.Course, Is.EqualTo(2));
            Assert.That(aspirant.RecordBook, Is.EqualTo("RB101"));
            Assert.That(aspirant.Dissertation, Is.EqualTo("ML Dissertation"));
        }

        [Test]
        public void Aspirant_Print_DoesNotThrow()
        {
            var aspirant = new Aspirant("Sidorov", 1, "RB789", "AI Dissertation");
            Assert.DoesNotThrow(() => aspirant.Print());
        }
    }
}