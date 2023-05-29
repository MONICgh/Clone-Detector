namespace CarFactory.components;

public interface IGearbox
{
    public GearboxPosition Position { get; set; }
}

public enum GearboxPosition
{
    Neutral,
    Reverse,
    Drive,
    Park
}

public class ManualGearbox : IGearbox
{
    public GearboxPosition Position { get; set; }

    public ManualGearbox()
    {
        Position = GearboxPosition.Neutral;
    }
}

public class AutomaticGearbox : IGearbox
{
    public GearboxPosition Position { get; set; }

    public AutomaticGearbox()
    {
        Position = GearboxPosition.Neutral;
    }
}