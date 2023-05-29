namespace CarFactory.components;

public interface IStereoSystem
{
    public void TurnOn();

    public void TurnOff();
}

public class BaseStereoSystem : IStereoSystem
{
    public bool IsOn { get; private set; }

    public BaseStereoSystem()
    {
        IsOn = true;
    }

    public void TurnOn()
    {
        IsOn = true;
    }

    public void TurnOff()
    {
        IsOn = false;
    }
}