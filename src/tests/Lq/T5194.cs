namespace CarFactory.components;

public interface IChassis
{
    public List<ChassisWheel> Wheels { get; set; }
}

public class BaseChassis : IChassis
{
    public List<ChassisWheel> Wheels { get; set; }
    
    public BaseChassis(List<ChassisWheel> wheels)
    {
        Wheels = wheels;
    }
}

public class UpgradedChassis : IChassis
{
    public List<ChassisWheel> Wheels { get; set; }
    
    public UpgradedChassis(List<ChassisWheel> wheels)
    {
        Wheels = wheels;
    }
}