using HW_15.WolfAndSheeps;
using NUnit.Framework;

namespace HW_15;

[TestFixture]
public class TestWolves
{
    [Test]
    public void Test()
    {
        var simulation = new SimulationWolvesNSheeps(3);
        simulation.Run();
    }
}
