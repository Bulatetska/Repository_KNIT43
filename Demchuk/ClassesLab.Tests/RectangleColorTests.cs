using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ClassesLab.Tests;
[TestClass] public class RectangleColorTests
{
    [TestMethod] public void RectangleColor_DefaultConstructor_SetsDefaultFields() { var r = new RectangleColor(); Assert.AreEqual(0d, r.X1); Assert.AreEqual(1d, r.X2); Assert.AreEqual("Без кольору", r.Color); Assert.AreEqual(1d, r.Area()); }
    [TestMethod] public void RectangleColor_Constructor_SetsFields() { var r = Make(); Assert.AreEqual("Синій", r.Color); Assert.AreEqual(1d, r.X1); Assert.AreEqual(4d, r.Y2); }
    [TestMethod] public void RectangleColor_SetColor_UpdatesColor() { var r = Make(); r.Color = "Зелений"; Assert.AreEqual("Зелений", r.Color); }
    [TestMethod] public void RectangleColor_Area_UsesBaseCalculation() => Assert.AreEqual(12d, Make().Area(), 0.000001);
    [TestMethod] public void RectangleColor_Display_ShowsAllDetails() { var output = TestHelpers.Capture(() => Make().Display()); StringAssert.Contains(output, "Фігура:"); StringAssert.Contains(output, "Координати:"); StringAssert.Contains(output, "Колір: Синій"); }
    private static RectangleColor Make() => new("Кольоровий", 1, 1, 5, 4, "Синій");
}
