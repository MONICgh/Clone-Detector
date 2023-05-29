namespace OrderedPrint;

public class Orderer
{
    private int _current;
    private readonly object _locker;

    public Orderer()
    {
        _current = 1;
        _locker = new object();
    }

    public void Run(int order, Action action)
    {
        lock (_locker)
        {
            while (order > _current)
            {
                Monitor.Wait(_locker);
            }

            _current++;
            action();
            Monitor.PulseAll(_locker);
        }     
    }
}
