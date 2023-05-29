namespace SleepingHairdresser;

public class Client
{
    private readonly string _name;

    public Client(string name)
    {
        _name = name;
    }

    public override string ToString()
    {
        return _name;
    }
}