using NUnit.Framework;
using PersonClass;

namespace Test_Person
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void PersonProperties_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var person = new Person("Alice", 25, "Female", "+380501234567");

            // Act
            person.Name = "Bob";
            person.Age = 30;
            person.Gender = "Male";
            person.PhoneNumber = "+380501112233";

            // Assert
            Assert.That(person.Name, Is.EqualTo("Bob"));
            Assert.That(person.Age, Is.EqualTo(30));
            Assert.That(person.Gender, Is.EqualTo("Male"));
            Assert.That(person.PhoneNumber, Is.EqualTo("+380501112233"));
        }
    }
}
