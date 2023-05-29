using System.Collections.Concurrent;
using System.Text;

namespace WolfAndSheeps;

public class Position
{
    public int X;
    public int Y;

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Position pos)
        {
            return pos.X == X && pos.Y == Y;
        }

        return false;
    }

    public override string ToString()
    {
        return $"<{X}, {Y}>";
    }
}

public class Field
{
    private readonly object _locker = new();
    private readonly Dictionary<Agent, Position> _field;
    private readonly int _size;

    public Field(int size)
    {
        _size = size;
        _field = new Dictionary<Agent, Position>();
    }

    /*
     * Simulate Earth
     */
    private int _fixValue(int x)
    {
        return (x + _size) % _size;
    }

    private Position FixPosition(Position position)
    {
        return new Position(_fixValue(position.X), _fixValue(position.Y));
    }

    public void Move(Agent agent, Position newPosition)
    {
        newPosition = FixPosition(newPosition);
        Console.WriteLine($"Agent {agent} moved to {newPosition}");
        lock (_locker)
        {
            _field[agent] = newPosition;
            foreach (var (nextAgent, position) in _field)
            {
                if (nextAgent != agent && Equals(newPosition, position))
                {
                    switch (agent.Kind, nextAgent.Kind)
                    {
                        case (Kind.Wolf, Kind.Sheep):
                        {
                            nextAgent.Kill();
                            _field.Remove(nextAgent);
                            break;
                        }
                        case (Kind.Sheep, Kind.Wolf):
                        {
                            agent.Kill();
                            _field.Remove(agent);
                            break;
                        }
                    }
                }
            }
        }
    }
}