namespace RacingCar;

public class RaceSolver
{
    private readonly State _initialState = new (0, 1);

    public CommandsSequence Solve(int targetPosition)
    {
        var used = new HashSet<State>();
        var queue = new Queue<Path>();
        
        queue.Enqueue(new Path(_initialState));
        used.Add(_initialState);

        while (queue.Count > 0)
        {
            var path = queue.Dequeue();
            if (path.State.Position == targetPosition)
            {
                return path.Commands;
            }
            foreach (var (state, command) in path.GenerateNextStates())
            {
                if (used.Contains(state))
                {
                    continue;
                }

                used.Add(state);
                var prevCommands = path.Commands.Commands.ToList();
                prevCommands.Add(command);
                queue.Enqueue(new Path(state, new CommandsSequence(prevCommands)));
            }
        }

        throw new Exception("Unreachable!");
    }
}

internal class Path
{
    public readonly State State;

    public readonly CommandsSequence Commands;

    public Path(State state, CommandsSequence? prevCommands = null)
    {
        State = state;
        Commands = prevCommands ?? new CommandsSequence();
    }

    public List<(State, ICommand)> GenerateNextStates()
    {
        var a = new ACommand();
        var r = new RCommand();
        return new List<(State, ICommand)>
        {
            (a.GetNewState(State), a),
            (r.GetNewState(State), r)
        };
    }
}