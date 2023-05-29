namespace Task1.model.engine;

public abstract class AbstractEngine
{
    private int _power;

    protected AbstractEngine(int power)
    {
        _power = power;
    }

    public override string ToString()
    {
        return "Engine: power = " + _power;
    }
}