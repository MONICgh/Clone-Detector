namespace Cars;

public interface IChassis
{
    public int Endurance { get; }
}

public class CityChassis : IChassis
{
    public CityChassis(int lifeTime = 200)
    {
        Endurance = lifeTime;
    }

    public int Endurance { get; }
}

public class SportChassis : IChassis
{
    public SportChassis(int lifeTime = 1000)
    {
        Endurance = lifeTime;
    }

    public int Endurance { get; }
}
