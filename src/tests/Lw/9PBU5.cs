namespace BearAndBees;

public class Pot
{
    private readonly CountdownEvent _notifier;
    private readonly object _potLock = new();
    private readonly Random _rand = new Random();

    public Pot(CountdownEvent notifier)
    {
        _notifier = notifier;
    }

    public void AddHoney()
    {
        Thread.Sleep(_rand.Next(100, 1000));
        lock (_potLock)
        {
            while (_notifier.CurrentCount == 0)
            {
                Monitor.Wait(_potLock);
            }
            _notifier.Signal();
        }
        
    }

    public void GetHoney()
    {
        lock (_potLock)
        {
            if (_notifier.CurrentCount == 0)
            {
                Thread.Sleep(_rand.Next(100, 500));
                _notifier.Reset();
                Monitor.PulseAll(_potLock);
            }    
        }
    }
}