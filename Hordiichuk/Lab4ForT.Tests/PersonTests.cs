using NUnit.Framework;
using Lab4ForT;
using System;

namespace Lab4ForT.Tests
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void Constructor_ValidArguments_CreatesPerson()
        {
            var person = new Person("Alice", 25, "Female", "1234567890");

            Assert.That(person.Name, Is.EqualTo("Alice"));
            Assert.That(person.Age, Is.EqualTo(25));
            Assert.That(person.Gender, Is.EqualTo("Female"));
            Assert.That(person.Phone, Is.EqualTo("1234567890"));
        }

        [Test]
        public void Constructor_EmptyName_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Person("", 25, "Female", "1234567890"));
        }

        [Test]
        public void Constructor_NegativeAge_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Person("Alice", -1, "Female", "1234567890"));
        }

        [Test]
        public void Constructor_EmptyGender_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Person("Alice", 25, "", "1234567890"));
        }

        [Test]
        public void Constructor_EmptyPhone_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Person("Alice", 25, "Female", ""));
        }
    }
}
