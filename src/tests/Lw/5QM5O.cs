namespace WolfAndSheeps;

public enum Kind
{
    Wolf,
    Sheep
}

static class IdGenerator
{
    private static int _id = 0;

    public static int NextId()
    {
        return _id++;
    }
}

public class Agent
{
    private Position _position;
    private Field _field;
    private bool _idDead = false;
    public Kind Kind;
    private Task _life;
    private int _id;

    public Agent(Position position, Field field, Kind kind)
    {
        _id = IdGenerator.NextId();
        _position = position;
        _field = field;
        Kind = kind;
        _life = new Task(Life);
    }

    public void Run()
    {
        _life.Start();
    }

    public void Kill()
    {
        Console.WriteLine($"Agent {_id} was killed");
        _idDead = true;
        _life.Dispose();
    }

    private void Move()
    {
        var rand = new Random();
        var dx = rand.Next(-1, 1);
        var dy = rand.Next(-1, 1);

        _field.Move(this, new Position(_position.X + dx, _position.Y + dy));
    }

    private void Life()
    {
        while (!_idDead)
        {
            Move();
            Thread.Sleep(new Random().Next(100, 1000));
        }
    }

    public override string ToString()
    {
        return $"{Kind} {_id}";
    }
}