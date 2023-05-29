namespace Task1.model.chassis;

public class AbstractChassis
{
    private int _length;
    private int _width;

    protected AbstractChassis(int length, int width)
    {
        _length = length;
        _width = width;
    }

    public override string ToString()
    {
        return "Chassis: length = " + _length + ", width = " + _width;
    }
}