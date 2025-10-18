using NUnit.Framework;
using MyApp;
using System;

namespace PersonTests
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void Person_SettersAndGetters_WorkCorrectly()
        {
            var person = new Person("Nastia", 20, "Female", "+380123456789");

            Assert.That(person, Is.Not.Null);

            person.SetName("Olga");
            person.SetAge(25);
            person.SetGender("Female");
            person.SetPhone("+380987654321");


            Assert.That(person, Is.Not.Null);
        }
    }
}