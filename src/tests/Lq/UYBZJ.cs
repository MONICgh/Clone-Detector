namespace CarFactory.components;

public interface IEngine
{
    public int CylindersCount { get; }

    public void Start();

    public void Stop();
}

public class BaseCarEngine : IEngine
{
    private readonly List<EngineCylinder> _cylinders;

    public int CylindersCount => _cylinders.Count;

    public BaseCarEngine()
    {
        _cylinders = new List<EngineCylinder>
        {
            new(), new(), new(), new(), new(), new()
        };
    }

    public void Start()
    {
        Console.WriteLine("BaseCarEngine started");
    }

    public void Stop()
    {
        Console.WriteLine("BaseCarEngine stopped");
    }
}

public class UpgradedCarEngine : IEngine
{
    private readonly List<EngineCylinder> _cylinders;

    public int CylindersCount => _cylinders.Count;

    public UpgradedCarEngine()
    {
        _cylinders = new List<EngineCylinder>
        {
            new(), new(), new(), new(), new(), new(), new(), new()
        };
    }

    public void Start()
    {
        Console.WriteLine("UpgradedCarEngine started");
    }

    public void Stop()
    {
        Console.WriteLine("UpgradedCarEngine stopped");
    }
}