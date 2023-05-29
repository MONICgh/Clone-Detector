namespace Task1.model.gearbox;

public class AbstractGearbox
{
    private int _numberOfGears;

    protected AbstractGearbox(int numberOfGears)
    {
        _numberOfGears = numberOfGears;
    }

    public override string ToString()
    {
        return "Gearbox: number of gears = " + _numberOfGears;
    }
}