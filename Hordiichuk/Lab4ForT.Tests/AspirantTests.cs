// Lab4ForT.Tests/AspirantTests.cs
using NUnit.Framework;
using Lab4ForT;
using System;

namespace Lab4ForT.Tests
{
    [TestFixture]
    public class AspirantTests
    {
        [Test]
        public void Constructor_ValidArguments_CreatesAspirant()
        {
            var aspirant = new Aspirant("Petrov", 3, "RB54321", "Machine Learning");

            Assert.That(aspirant.Surname, Is.EqualTo("Petrov"));
            Assert.That(aspirant.Course, Is.EqualTo(3));
            Assert.That(aspirant.RecordBook, Is.EqualTo("RB54321"));
            Assert.That(aspirant.DissertationTopic, Is.EqualTo("Machine Learning"));
        }

        [Test]
        public void Constructor_EmptyDissertationTopic_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Aspirant("Petrov", 3, "RB54321", ""));
        }
    }
}
