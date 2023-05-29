namespace Cars;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var factory = new Factory();
        var car = factory.BuildCityCar();
        
        Assert.AreEqual(800, car.Engine.Power);
        Assert.IsInstanceOf<PetrolEngine>(car.Engine);
    }

    [Test]
    public void Test2()
    {
        var factory = new Factory();
        var car = factory.BuildExpensiveCar();
        
        Assert.AreEqual(2000, car.Engine.Power);
        Assert.IsInstanceOf<ElectricEngine>(car.Engine);
    }

    [Test]
    public void Test3()
    {
        var factory = new Factory();
        var car = factory.BuildSportCar();
        
        Assert.AreEqual(10000, car.Engine.Power);
        Assert.IsInstanceOf<PetrolEngine>(car.Engine);
    }
}