using NUnit.Framework;

namespace TransformationOperator;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    // Uncomment this test and comment the next
    // [Test]
    // public void TestImplicit()
    // {
    //     Horse horse1 = new Horse(HorseType.Pony, true, 5, "Pony", 100, 60, 25);
    //     Car expected = new Car(CarType.Mini, true, 6, "Pony 2", 120, 80, 30);
    //     Car horseCarImplicit = horse1;
    //     Assert.AreEqual(expected, horseCarImplicit);
    // }
    
    [Test]
    public void TestExplicit()
    {
        Horse horse1 = new Horse(HorseType.Pony, true, 5, "Pony", 100, 60, 25);
        Car expected = new Car(CarType.Mini, true, 5, "Pony", 100, 60, 25);
        Car horseCarImplicit = (Car)horse1;
        Assert.IsTrue(expected == horseCarImplicit);
    }
    
    [Test]
    public void TestNotEqual()
    {
        Horse horse1 = new Horse(HorseType.Pony, true, 5, "Pony", 100, 60, 25);
        Horse horse2 = new Horse(HorseType.Pony, true, 6, "Pony 2", 120, 80, 30);

        Assert.IsFalse(horse1 == horse2);
    }
    
    [Test]
    public void TestEqual()
    {
        Horse horse1 = new Horse(HorseType.Pony, true, 5, "Pony", 100, 60, 25);
        Horse horse2 = new Horse(HorseType.RaceHorse, true, 5, "Horse", 100, 60, 65);

        Assert.IsTrue(horse1 == horse2);
    }
    
    [Test]
    public void TestLess()
    {
        Horse horse1 = new Horse(HorseType.Pony, true, 5, "Pony", 100, 60, 25);
        Horse horse2 = new Horse(HorseType.RaceHorse, true, 6, "Horse", 100, 60, 65);

        Assert.IsTrue(horse1 < horse2);
    }
    
    [Test]
    public void TestLess2()
    {
        Horse horse1 = new Horse(HorseType.Pony, true, 5, "Pony", 100, 60, 25);
        Horse horse2 = new Horse(HorseType.RaceHorse, true, 5, "Horse", 120, 50, 65);

        Assert.IsTrue(horse1 < horse2);
    }
    
    [Test]
    public void TestLess3()
    {
        Horse horse1 = new Horse(HorseType.Pony, true, 5, "Pony", 100, 60, 25);
        Horse horse2 = new Horse(HorseType.RaceHorse, true, 5, "Horse", 100, 70, 65);

        Assert.IsTrue(horse1 < horse2);
    }
}