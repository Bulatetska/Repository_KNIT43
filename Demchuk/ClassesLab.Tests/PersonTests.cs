using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ClassesLab.Tests;
[TestClass] public class PersonTests
{
    [TestMethod] public void Person_Constructor_SetsFields()
    { var p = new Person("Олена", 21, "Ж", "0501234567"); Assert.AreEqual("Олена", p.Name); Assert.AreEqual(21, p.Age); Assert.AreEqual("Ж", p.Gender); Assert.AreEqual("0501234567", p.Phone); }
    [TestMethod] public void Person_SetName_ChangesName() { var p = Make(); p.SetName("Іван"); Assert.AreEqual("Іван", p.Name); }
    [TestMethod] public void Person_SetAge_ChangesAge() { var p = Make(); p.SetAge(22); Assert.AreEqual(22, p.Age); }
    [TestMethod] public void Person_SetGender_ChangesGender() { var p = Make(); p.SetGender("Ч"); Assert.AreEqual("Ч", p.Gender); }
    [TestMethod] public void Person_SetPhone_ChangesPhone() { var p = Make(); p.SetPhone("0670000000"); Assert.AreEqual("0670000000", p.Phone); }
    [TestMethod] public void Person_Print_ShowsAllFields()
    { string output = TestHelpers.Capture(() => Make().Print()); StringAssert.Contains(output, "Олена"); StringAssert.Contains(output, "21"); StringAssert.Contains(output, "0501234567"); }
    private static Person Make() => new("Олена", 21, "Ж", "0501234567");
}
