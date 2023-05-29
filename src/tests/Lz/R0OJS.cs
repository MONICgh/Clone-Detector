using HW_05.PseudoStack;
using NUnit.Framework;

namespace HW_05.SunLoungers;

[TestFixture]
public class TestSunLoungers
{
    [Test]
    public void Check()
    {
        Assert.AreEqual(1, SunLoungersSolver.Solve("10001"));
        Assert.AreEqual(1, SunLoungersSolver.Solve("00101"));
        Assert.AreEqual(1, SunLoungersSolver.Solve("0"));
        Assert.AreEqual(2, SunLoungersSolver.Solve("000"));
    }
}
