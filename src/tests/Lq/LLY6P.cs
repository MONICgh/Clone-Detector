namespace Cars;

public interface ICylinder
{
    public float Power { get; }
}

public class Cylinder: ICylinder
{
    private float _power;

    public Cylinder(float power = 100)
    {
        _power = power;
    }

    public float Power => _power;
}

public class SportCylinder: ICylinder
{
    private float _power;

    public SportCylinder(float power = 500)
    {
        _power = power;
    }

    public float Power => _power;
}
