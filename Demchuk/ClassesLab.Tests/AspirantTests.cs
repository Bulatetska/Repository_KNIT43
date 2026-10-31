using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ClassesLab.Tests;
[TestClass] public class AspirantTests
{
    [TestMethod] public void Aspirant_Constructor_SetsBaseAndOwnProperties() { var a = Make(); Assert.AreEqual("Петренко", a.Surname); Assert.AreEqual(5, a.Course); Assert.AreEqual("789", a.RecordBook); Assert.AreEqual("Штучний інтелект", a.DissertationTopic); }
    [TestMethod] public void Aspirant_Setters_UpdateInheritedAndOwnProperties() { var a = Make(); a.Course = 6; a.DissertationTopic = "Мережі"; Assert.AreEqual(6, a.Course); Assert.AreEqual("Мережі", a.DissertationTopic); }
    [TestMethod] public void Aspirant_Print_ContainsBaseAndOwnData() { string output = TestHelpers.Capture(() => Make().Print()); StringAssert.Contains(output, "Петренко"); StringAssert.Contains(output, "789"); StringAssert.Contains(output, "Штучний інтелект"); }
    private static Aspirant Make() => new("Петренко", 5, "789", "Штучний інтелект");
}
