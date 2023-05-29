namespace CarManufacturing;

public interface IEngine
{
    void Start();
    void Stop();
    
    bool IsOn { get; set; }
}

public class ElectricEngine : IEngine
{
    public ElectricEngine()
    {
        IsOn = false;
    }

    public void Start()
    {
        Console.WriteLine("Electric Engine on");
        IsOn = true;
    }

    public void Stop()
    {
        Console.WriteLine("Electric Engine off");
        IsOn = false;
    }

    public bool IsOn { get; set; }
}

public class GasEngine : IEngine
{
    public GasEngine()
    {
        IsOn = false;
    }
    
    public void Start()
    {
        Console.WriteLine("Engine on");
        IsOn = true;
    }

    public void Stop()
    {
        Console.WriteLine("Engine off");
        IsOn = false;
    }

    public bool IsOn { get; set; }
}