namespace Cars;

public class Car
{
    public Car(
        string model, 
        IBody body,
        IEngine engine,
        List<IChassis> chassis,
        ITransmission transmission,
        IDashBoard dashboard,
        IStereoSystem stereoSystem
        )
    {
        Model = model;
        Body = body;
        Engine = engine;
        Chassis = chassis;
        Transmission = transmission;
        Dashboard = dashboard;
        StereoSystem = stereoSystem;
    }

    public override string ToString()
    {
        return $"Car {Model}";
    }

    public int BodyID()
    {
        return Body.ID;
    }

    public string Model { get; init; }
    public IBody Body { get; set; }
    public IEngine Engine { get; set; }
    public List<IChassis> Chassis { get; set; }
    public ITransmission Transmission { get; set; }
    public IDashBoard Dashboard { get; set; }
    public IStereoSystem StereoSystem { get; set; }
}

public abstract class SportCar : Car
{
    public SportCar(
        string model,
        IBody body,
        IEngine engine,
        List<IChassis> chassis,
        ITransmission transmission,
        IDashBoard dashboard,
        IStereoSystem stereoSystem
        ) : base(
        model,
        body,
        engine,
        chassis,
        transmission,
        dashboard,
        stereoSystem
    ) {}

    public override string ToString()
    {
        return $"SportCar {Model}";
    }
}