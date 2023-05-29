namespace RacingCar;

public class CommandsSequence
{
    public List<ICommand> Commands { get; }

    public CommandsSequence(List<ICommand>? commands = null)
    {
        Commands = commands ?? new List<ICommand>();
    }

    public override string ToString() => string.Join("", Commands);
}