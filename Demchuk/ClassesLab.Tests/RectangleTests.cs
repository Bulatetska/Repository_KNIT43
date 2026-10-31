using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ClassesLab.Tests;
[TestClass] public class RectangleTests
{
    [TestMethod] public void Rectangle_DefaultConstructor_SetsUnitSquare() { var r = new Rectangle(); Assert.AreEqual(0d, r.X1); Assert.AreEqual(0d, r.Y1); Assert.AreEqual(1d, r.X2); Assert.AreEqual(1d, r.Y2); Assert.AreEqual(1d, r.Area()); }
    [TestMethod] public void Rectangle_ParameterizedConstructor_SetsCoordinates() { var r = Make(); Assert.AreEqual("Прямокутник", r.Name); Assert.AreEqual(2d, r.X1); Assert.AreEqual(6d, r.Y2); }
    [TestMethod] public void Rectangle_Area_CalculatesCorrectly() => Assert.AreEqual(12d, Make().Area(), 0.000001);
    [TestMethod] public void Rectangle_Area_UsesAbsoluteDifferences() { var r = new Rectangle("Р", 5, 5, 1, 2); Assert.AreEqual(12d, r.Area(), 0.000001); }
    [TestMethod] public void Rectangle_Display_ShowsNameAndCoordinates() { var output = TestHelpers.Capture(() => Make().Display()); StringAssert.Contains(output, "Прямокутник"); StringAssert.Contains(output, "Координати:"); }
    private static Rectangle Make() => new("Прямокутник", 2, 3, 6, 6);
}
