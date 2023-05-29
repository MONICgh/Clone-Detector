using Task1.model.body;
using Task1.model.chassis;
using Task1.model.engine;
using Task1.model.gearbox;
using Task1.model.panel;
using Task1.model.stereo;

namespace Task1.model;

public class Car
{
    public AbstractBody Body { get; }
    public AbstractEngine Engine { get; }
    public AbstractChassis Chassis { get; }
    public AbstractGearbox Gearbox { get; }
    public AbstractPanel Panel { get; }
    public AbstractStereo Stereo { get; }
    
    public Car(
        AbstractBody body,
        AbstractEngine engine,
        AbstractChassis chassis,
        AbstractGearbox gearbox,
        AbstractPanel panel,
        AbstractStereo stereo)
    {
        Body = body;
        Engine = engine;
        Chassis = chassis;
        Gearbox = gearbox;
        Panel = panel;
        Stereo = stereo;
    }

    public override string ToString()
    {
        return "Car:\n\t" + Body + "\n\t" + Engine + "\n\t" + Chassis + "\n\t" + Gearbox + "\n\t" + Panel + "\n\t" + Stereo;
    }
}