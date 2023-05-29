namespace BearAndBees;

public class Bear
{
    private bool _stop = false;
    private readonly Pot _pot;
    private readonly CountdownEvent _notifier;

    public Bear(Pot pot, CountdownEvent notifier)
    {
        _pot = pot;
        _notifier = notifier;
    }

    public void Run()
    {
        while (!_stop)
        {
            Console.WriteLine("Bear is sleeping");
            _notifier.Wait();
            Console.WriteLine("Bear start eating");
            _pot.GetHoney();
            Console.WriteLine("Bear finish eating");
        }
    }

    public void Stop()
    {
        _stop = true;
    }
}