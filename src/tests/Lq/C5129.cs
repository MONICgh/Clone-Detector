using CarFactory.components;

namespace CarFactory;

public class CarFactory
{
    private IdGenerator _idGenerator = new IdGenerator();

    public Car BuildCheapCar(string modelName)
    {
        var id = _idGenerator.GetUniqueId();
        return new Car(
            modelName + " (id: " + id + ")",
            new CarBody(id),
            new BaseCarEngine(),
            new BaseChassis(new List<ChassisWheel>
            {
                new BaseWheel(), new BaseWheel(), new BaseWheel(), new BaseWheel()
            }),
            new ManualGearbox(),
            new MechanicDashboard(),
            new BaseStereoSystem()
        );
    }
    
    public Car BuildMiddleClassCar(string modelName)
    {
        var id = _idGenerator.GetUniqueId();
        return new Car(
            modelName + " (id: " + id + ")",
            new CarBody(id),
            new BaseCarEngine(),
            new BaseChassis(new List<ChassisWheel>
            {
                new UpgradedWheel(), new UpgradedWheel(), new UpgradedWheel(), new UpgradedWheel()
            }),
            new ManualGearbox(),
            new DigitalDashboard(),
            new BaseStereoSystem()
        );
    }
    
    public Car BuildHighClassCar(string modelName)
    {
        var id = _idGenerator.GetUniqueId();
        return new Car(
            modelName + " (id: " + id + ")",
            new CarBody(id),
            new UpgradedCarEngine(),
            new UpgradedChassis(new List<ChassisWheel>
            {
                new BaseWheel(), new BaseWheel(), new BaseWheel(), new BaseWheel()
            }),
            new AutomaticGearbox(),
            new DigitalDashboard(),
            new BaseStereoSystem()
        );
    }

    public Car BuildLuxCar(string modelName)
    {
        var id = _idGenerator.GetUniqueId();
        return new Car(
            modelName + " (id: " + id + ")",
            new CarBody(id),
            new UpgradedCarEngine(),
            new UpgradedChassis(new List<ChassisWheel>
            {
                new UpgradedWheel(), new UpgradedWheel(), new UpgradedWheel(), new UpgradedWheel()
            }),
            new AutomaticGearbox(),
            new DigitalDashboard(),
            new BaseStereoSystem()
        );
    }
}

internal class IdGenerator
{
    private int _id;

    public int GetUniqueId()
    {
        _id += 1;
        return _id;
    }
}