namespace Task3;

public class CommandsVariant
{
    public readonly String Commands;
    public readonly Car Car;
        
    public CommandsVariant(string commands, Car car)
    {
        Commands = commands;
        Car = car;
    }

    public CommandsVariant R()
    {
        return new CommandsVariant(Commands + "R", Car.R());
    }

    public CommandsVariant A()
    {
        return new CommandsVariant(Commands + "A", Car.A());
    }
}
