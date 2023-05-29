namespace CarManufacturing;

public interface IWheel
{
    void TurnRight();
    void TurnLeft();
}

public class Wheel : IWheel
{
    public void TurnRight()
    {
        Console.WriteLine("Turning right");
    }

    public void TurnLeft()
    {
        Console.WriteLine("Turning left");
    }
}

public class LargeWheel : IWheel
{
    public void TurnRight()
    {
        Console.WriteLine("Turning right");
    }

    public void TurnLeft()
    {
        Console.WriteLine("Turning left");
    }
}