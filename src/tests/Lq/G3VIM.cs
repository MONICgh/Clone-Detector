namespace CarManufacturing;

public interface IStereoSystem
{
    void PlayRadio();
    void TurnOffRadio();
}

public class StereoSystem : IStereoSystem
{
    public void PlayRadio()
    {
        Console.WriteLine("Playing radio...");
    }

    public void TurnOffRadio()
    {
        Console.WriteLine("Radio turned off");
    }
}