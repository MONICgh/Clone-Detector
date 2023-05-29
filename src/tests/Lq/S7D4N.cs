namespace HW_12.car_factory;

public interface IWheels
{
}

class UsualWheels : IWheels
{
}

public interface IEngine
{
    public int CylinderCount { get; }
}

class UsualEngine : IEngine
{
    public UsualEngine()
    {
        CylinderCount = 2;
    }
    public int CylinderCount { get; }
}

public interface IBody
{
    IBody WithNumber(int i);
}

public interface IPanel
{

}

internal class UsualStereoSystem : IStereoSystem
{
}

internal class UsualPanel : IPanel
{
}

internal class UsualTransmission : ITransmission
{
}

public interface ITransmission
{

}

public interface IStereoSystem
{

}

class UsualBody : IBody
{
    private int? _bodyNumber;

    public IBody WithNumber(int i)
    {
        if (_bodyNumber == null)
        {
            _bodyNumber = i;
        }
        else
        {
            throw new Exception("Body already has a number on it");
        }
        return this;
    }
}
