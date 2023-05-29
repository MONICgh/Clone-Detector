namespace Task3;

public class Car
{
    public int Position;
    private int _speed;

    public Car(int position, int speed)
    {
        Position = position;
        _speed = speed;
    }

    public Car R()
    {
        return new Car(Position, -1);
    }

    public Car A()
    {
        return new Car(Position + _speed, Math.Abs(_speed) * 2);
    }
}