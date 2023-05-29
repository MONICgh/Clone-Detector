namespace RacingCar;

public interface ICommand
{
    public State GetNewState(State state);
}

public class ACommand : ICommand
{
    public State GetNewState(State state)
    {
        return new State(
            state.Position + state.Velocity,
            Math.Abs(state.Velocity) * 2
        );
    }

    public override string ToString() => "A";
}

public class RCommand : ICommand
{
    public State GetNewState(State state)
    {
        return new State(
            state.Position,
            -1
        );
    }

    public override string ToString() => "R";
}