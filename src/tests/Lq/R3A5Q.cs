namespace HW_12.car_factory;

public class Car
{
    public IBody Body { get; }
    public IEngine Engine { get; }
    public IWheels Wheels { get; }
    public ITransmission Transmission { get; }
    public IPanel Panel { get; }
    public IStereoSystem StereoSystem { get; }
    public Car(IBody body, IEngine engine, IWheels wheels, ITransmission transmission, IPanel panel, IStereoSystem stereoSystem)
    {
        this.Body = body;
        this.Engine = engine;
        this.Wheels = wheels;
        this.Transmission = transmission;
        this.Panel = panel;
        this.StereoSystem = stereoSystem;
    }

}
