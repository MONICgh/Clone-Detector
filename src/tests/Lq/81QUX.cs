using CarFactory.components;

namespace CarFactory;

public class Car
{
    public string ModelName { get; }
    
    public IBody Body { get; }

    public IEngine Engine { get; }
    
    public IChassis Chassis { get; }
    
    public IGearbox Gearbox { get; }
    
    public IDashboard Dashboard { get; }
    
    public IStereoSystem StereoSystem { get; }
    
    public Car(string modelName, IBody body, IEngine engine, IChassis chassis, IGearbox gearbox, IDashboard dashboard, IStereoSystem stereoSystem)
    {
        ModelName = modelName;
        Body = body;
        Engine = engine;
        Chassis = chassis;
        Gearbox = gearbox;
        Dashboard = dashboard;
        StereoSystem = stereoSystem;
    }
}