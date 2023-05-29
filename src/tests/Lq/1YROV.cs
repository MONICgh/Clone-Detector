namespace Cars;

public interface IStereoSystem
{
    public bool IsTouch { get; }
    public bool WithCD { get; }
}

public class StereoSystem : IStereoSystem
{
    public StereoSystem(bool isTouch, bool withCD)
    {
        IsTouch = isTouch;
        WithCD = withCD;
    }

    public bool IsTouch { get; }
    public bool WithCD { get; }
}