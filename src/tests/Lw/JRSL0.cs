using NUnit.Framework;

namespace HW_15;

[TestFixture]
public class TestBees
{
    [Test]
    public void Test()
    {
        var simulation = new Simulation(new HoneyPot(3), 3);
        simulation.Run(2);
    }
}
