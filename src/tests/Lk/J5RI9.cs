using NUnit.Framework;

namespace HW_04.HorseCar;

public class Tests
{
    [Test]
    public void TestExplicit()
    {
        var horse1 = new Horse(HorseType.Pony, true, 5, 100, 1000);
        var expected = new Car(CarType.Small, true, 5, 100, 1000);
        var horseCarImplicit = (Car)horse1;
        Assert.IsTrue(expected == horseCarImplicit);
    }

    [Test]
    public void TestNotEqual()
    {
        var horse1 = new Horse(HorseType.Pony, true, 5, 100, 60);
        var horse2 = new Horse(HorseType.Pony, true, 6,  120, 80);

        Assert.IsFalse(horse1 == horse2);
    }

    [Test]
    public void TestEqual()
    {
        var horse1 = new Horse(HorseType.Pony, true, 5, 100, 60);
        var horse2 = new Horse(HorseType.FastHorse, true, 5, 100, 60);

        Assert.IsTrue(horse1 == horse2);
    }

    [Test]
    public void TestLess()
    {
        Horse horse1 = new Horse((HorseType)HorseType.Pony, (bool)true, (int)5, (int)100, (int)60);
        Horse horse2 = new Horse((HorseType)HorseType.FastHorse, (bool)true, (int)6, (int)100, (int)60);

        Assert.IsTrue(horse1 < horse2);
    }

    [Test]
    public void TestLess2()
    {
        var horse1 = new Horse((HorseType)HorseType.Pony, (bool)true, (int)5, (int)100, (int)60);
        var horse2 = new Horse((HorseType)HorseType.FastHorse, (bool)true, (int)5, (int)120, (int)50);

        Assert.IsTrue(horse1 < horse2);
    }

    [Test]
    public void TestLess3()
    {
        var horse1 = new Horse(HorseType.Pony, true, 5, 100, 60);
        var horse2 = new Horse(HorseType.FastHorse, true, 5, 100, 70);

        Assert.IsTrue(horse1 < horse2);
    }
}
