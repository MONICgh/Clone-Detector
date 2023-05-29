using NUnit.Framework;

namespace HW_04.Integral;

public class Tests
{
    [Test]
    public void TestSquare()
    {
        Assert.AreEqual(243, Integrator.Integrate(Square, 0, 9), 0.001);
    }
    [Test]
    public void TestCube()
    {
        Assert.AreEqual(64, Integrator.Integrate(Cube, 0, 4), 0.001);
    }

    [Test]
    public void TestInv()
    {

        Assert.AreEqual(0.69315, Integrator.Integrate(Inverted, 1, 2), 0.001);
    }
    private static double Inverted(double x) => 1 / x;
    
    private static double Cube(double x) => x * x * x;
    
    
    private static double Square(double x) => x * x;

}
