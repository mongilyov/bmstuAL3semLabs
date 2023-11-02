namespace FigureTest;

using FigureNS;
using PointNS;

[TestClass]
public class FigureTest
{
    [TestMethod]
    public void TestMethod1()
    {
        Figure figure = new Figure(new Point(1, 1), new Point(1, 4), new Point(5, 1));
        figure.PerimeterCalculator();
        Assert.AreEqual("Triangle", figure.name);
        Assert.AreEqual(12, figure.Perimeter);
    }
}
