namespace BearAndBees;

static class BeeId
{
    private static int _id = 0;
    private static readonly object _locker = new ();

    public static int NextId()
    {
        lock (_locker)
        {
            return _id++;
        }
    }
}


public class Bee
{
    private bool _stop = false;
    private readonly Pot _pot;
    private readonly int _id;

    public Bee(Pot pot)
    {
        _pot = pot;
        _id = BeeId.NextId();
    }

    public void Run()
    {
        while (!_stop)
        {
            Console.WriteLine($"Bee {_id} is collecting honey");
            _pot.AddHoney();
            Console.WriteLine($"Bee {_id} added honey");
        }
    }

    public void Stop()
    {
        _stop = true;
    }
}