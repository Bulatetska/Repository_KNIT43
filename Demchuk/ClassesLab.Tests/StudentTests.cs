using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ClassesLab.Tests;
[TestClass] public class StudentTests
{
    [TestMethod] public void Student_Constructor_SetsProperties() { var s = Make(); Assert.AreEqual("Демчук", s.Surname); Assert.AreEqual(3, s.Course); Assert.AreEqual("123", s.RecordBook); }
    [TestMethod] public void Student_Setters_UpdateProperties() { var s = Make(); s.Surname = "Коваль"; s.Course = 4; s.RecordBook = "456"; Assert.AreEqual("Коваль", s.Surname); Assert.AreEqual(4, s.Course); Assert.AreEqual("456", s.RecordBook); }
    [TestMethod] public void Student_Print_ShowsFields() { string output = TestHelpers.Capture(() => Make().Print()); StringAssert.Contains(output, "Демчук"); StringAssert.Contains(output, "Курс: 3"); StringAssert.Contains(output, "123"); }
    private static Student Make() => new("Демчук", 3, "123");
}
