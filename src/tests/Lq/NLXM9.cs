namespace RacingCar;

public class State
{
    public State(int position, int velocity)
    {
        Position = position;
        Velocity = velocity;
    }

    public int Position { get; }

    public int Velocity { get; }

    private bool Equals(State other)
    {
        return Position == other.Position && Velocity == other.Velocity;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((State)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Position, Velocity);
    }
}