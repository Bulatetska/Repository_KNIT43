// Lab4ForT.Tests/StudentTests.cs
using NUnit.Framework;
using Lab4ForT;
using System;

namespace Lab4ForT.Tests
{
    [TestFixture]
    public class StudentTests
    {
        [Test]
        public void Constructor_ValidArguments_CreatesStudent()
        {
            var student = new Student("Ivanov", 2, "RB12345");

            Assert.That(student.Surname, Is.EqualTo("Ivanov"));
            Assert.That(student.Course, Is.EqualTo(2));
            Assert.That(student.RecordBook, Is.EqualTo("RB12345"));
        }

        [Test]
        public void Constructor_EmptySurname_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Student("", 2, "RB12345"));
        }

        [Test]
        public void Constructor_NonPositiveCourse_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Student("Ivanov", 0, "RB12345"));
        }

        [Test]
        public void Constructor_EmptyRecordBook_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Student("Ivanov", 2, ""));
        }
    }
}
