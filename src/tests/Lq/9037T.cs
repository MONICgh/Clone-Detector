using NUnit.Framework;

namespace HW_12.car_factory;

[TestFixture]
public class Test
{
    [Test]
    public void BuildCarTest()
    {
        var factory = new Factory();
        var givenBody = new UsualBody();
        var givenPanel = new UsualPanel();
        var usualStereoSystem = new UsualStereoSystem();
        var car = factory.GetCar(givenBody, givenPanel, usualStereoSystem);
        Assert.AreEqual(car.Body, givenBody);
        Assert.AreEqual(car.Panel, givenPanel);
    }
}
