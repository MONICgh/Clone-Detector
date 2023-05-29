namespace CarManufacturing;

public interface ICar
{
    IBody Body { get; set; }
    Gearbox Gearbox { get; set; }
    IControlPanel ControlPanel { get; set; }
    IEngine Engine { get; set; }
    IStereoSystem StereoSystem { get; set; }
    IWheel Wheels { get; set; }
    bool IsEngineOn { get; }
    void FirstGear();
    void SecondGear();
    void ReverseGear();
    void PlayRadio();
    void TurnOffRadio();
    void StartEngine();
    void StopEngine();
    void TurnRight();
    void TurnLeft();
}

public class Ford : ICar
{
    public IBody Body { get; set; }
    public Gearbox Gearbox { get; set; }
    public IControlPanel ControlPanel { get; set; }
    public IEngine Engine { get; set; }
    public IStereoSystem StereoSystem { get; set; }
    public IWheel Wheels { get; set; }
    public bool IsEngineOn => Engine.IsOn;
    public void FirstGear()
    {
        Gearbox.FirstGear();
    }

    public void SecondGear()
    {
        Gearbox.SecondGear();
    }

    public void ReverseGear()
    {
        Gearbox.ReverseGear();
    }

    public void PlayRadio()
    {
        StereoSystem.PlayRadio();
    }

    public void TurnOffRadio()
    {
        StereoSystem.TurnOffRadio();
    }

    public void StartEngine()
    {
        Engine.Start();
    }

    public void StopEngine()
    {
        Engine.Stop();
    }

    public void TurnRight()
    {
        Wheels.TurnRight();
    }

    public void TurnLeft()
    {
        Wheels.TurnLeft();
    }

    public Ford(int num)
    {
        Wheels = new Wheel();
        StereoSystem = new StereoSystem();
        Engine = new ElectricEngine();
        ControlPanel = new HighTechControlPanel();
        Gearbox = new Gearbox();
        Body = new Sedan(num);
    }
}

public class Mercedes : ICar
{
    public IBody Body { get; set; }
    public Gearbox Gearbox { get; set; }
    public IControlPanel ControlPanel { get; set; }
    public IEngine Engine { get; set; }
    public IStereoSystem StereoSystem { get; set; }
    public IWheel Wheels { get; set; }
    public bool IsEngineOn => Engine.IsOn;
    public void FirstGear()
    {
        Gearbox.FirstGear();
    }

    public void SecondGear()
    {
        Gearbox.SecondGear();
    }

    public void ReverseGear()
    {
        Gearbox.ReverseGear();
    }

    public void PlayRadio()
    {
        StereoSystem.PlayRadio();
    }

    public void TurnOffRadio()
    {
        StereoSystem.TurnOffRadio();
    }

    public void StartEngine()
    {
        Engine.Start();
    }

    public void StopEngine()
    {
        Engine.Stop();
    }

    public void TurnRight()
    {
        Wheels.TurnRight();
    }

    public void TurnLeft()
    {
        Wheels.TurnLeft();
    }

    public Mercedes(int num)
    {
        Wheels = new Wheel();
        StereoSystem = new StereoSystem();
        Engine = new GasEngine();
        ControlPanel = new HighTechControlPanel();
        Gearbox = new Gearbox();
        Body = new Sedan(num);
    }
}

public class LandRover : ICar
{
    public IBody Body { get; set; }
    public Gearbox Gearbox { get; set; }
    public IControlPanel ControlPanel { get; set; }
    public IEngine Engine { get; set; }
    public IStereoSystem StereoSystem { get; set; }
    public IWheel Wheels { get; set; }
    public bool IsEngineOn => Engine.IsOn;
    public void FirstGear()
    {
        Gearbox.FirstGear();
    }

    public void SecondGear()
    {
        Gearbox.SecondGear();
    }

    public void ReverseGear()
    {
        Gearbox.ReverseGear();
    }

    public void PlayRadio()
    {
        StereoSystem.PlayRadio();
    }

    public void TurnOffRadio()
    {
        StereoSystem.TurnOffRadio();
    }

    public void StartEngine()
    {
        Engine.Start();
    }

    public void StopEngine()
    {
        Engine.Stop();
    }

    public void TurnRight()
    {
        Wheels.TurnRight();
    }

    public void TurnLeft()
    {
        Wheels.TurnLeft();
    }

    public LandRover(int num)
    {
        Wheels = new LargeWheel();
        StereoSystem = new StereoSystem();
        Engine = new GasEngine();
        ControlPanel = new ControlPanel();
        Gearbox = new Gearbox();
        Body = new Jeep(num);
    }
}