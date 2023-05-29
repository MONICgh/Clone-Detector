namespace Cars;

public interface IEngine
{
    public float Power { get; }
}

public class PetrolEngine : IEngine
{
    private readonly List<ICylinder> _cylinders;

    public PetrolEngine(List<ICylinder> cylinders)
    {
        _cylinders = cylinders;
    }

    public float Power
    {
        get { return _cylinders.Sum(it => it.Power); }
    }
}

public class ElectricEngine : IEngine
{
    private float _power;

    public ElectricEngine(float power = 1000)
    {
        _power = power;
    }

    public float Power => _power;
}