namespace Cars;

public interface ITransmission
{
    public int SpeedNumber { get; }
}

public class StandartTransmission : ITransmission
{
    public StandartTransmission()
    {
        SpeedNumber = 5;
    }

    public int SpeedNumber { get; }
}

public class SportTransmission : ITransmission
{
    public SportTransmission()
    {
        SpeedNumber = 10;
    }

    public int SpeedNumber { get; }
}
