using RectangleNS;

namespace RectangleTest;

[TestClass]
public class RectangleTest
{
    [TestMethod]
    public void TestArea()
    {
        double side1 = 5.85;
        double side2 = 3.28;
        Rectangle rectangle = new(side1, side2);
        Assert.AreEqual(19.188, rectangle.Area,
            "Rectangle area mistake");
    }

    [TestMethod]
    public void TestPerimeter()
    {
        double side1 = 5.85;
        double side2 = 3.28;
        Rectangle rectangle = new(side1, side2);
        Assert.AreEqual(18.26, rectangle.Perimeter, 0.001,
            "Rectangle perimeter mistake");
    }
}
