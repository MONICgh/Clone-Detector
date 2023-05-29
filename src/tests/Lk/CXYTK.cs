using NUnit.Framework;

namespace Integration;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestSquare()
    {
        Function square = x => x * x;
        Assert.AreEqual(243, Integrator.Integrate(square, 0, 9), 0.001);
    }

    [Test]
    public void TestCube()
    {
        Function cube = x => x * x * x;
        Assert.AreEqual(64, Integrator.Integrate(cube, 0, 4), 0.001);
    }

    [Test]
    public void TestInv()
    {
        Function inv = x => 1 / x;
        Assert.AreEqual(0.69315, Integrator.Integrate(inv, 1, 2), 0.001);
    }
}