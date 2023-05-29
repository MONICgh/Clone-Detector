namespace HW_15;

class HoneyPot
{
    private readonly object _honeyPotLock = new();
    uint _currentPortions = 0;
    private uint maxPortions;

    public HoneyPot(uint maxPortions)
    {
        this.maxPortions = maxPortions;
    }

    public void AddPortion(int beeNumber)
    {
        lock (_honeyPotLock)
        {
            while (true)
            {
                if (_currentPortions < maxPortions)
                {
                    _currentPortions += 1;
                    Console.WriteLine("Bee #" + beeNumber + " added a portion");
                    break;
                }
                Monitor.Wait(_honeyPotLock);
            }
        }
    }

    public bool IsFull()
    {
        return _currentPortions == maxPortions;
    }

    public void ConsumeAll()
    {
        lock (_honeyPotLock)
        {
            Console.WriteLine("Bear ate all portions" + _currentPortions);
            _currentPortions = 0;
            Monitor.PulseAll(_honeyPotLock);
        }
    }
}

class Simulation
{
    private HoneyPot _honeyPot;
    private int times;
    public Simulation(HoneyPot honeyPot, int times)
    {
        _honeyPot = honeyPot;
        this.times = times;
    }

    void BeeWork(int beeNumber)
    {
        var random = new Random();
        while (true)
        {
            Thread.Sleep(random.Next() % 100 + 100);
            _honeyPot.AddPortion(beeNumber);
            if (_honeyPot.IsFull())
            {
                NotifyBear();
            }
        }
    }

    private readonly object _bearLock = new();
    private void NotifyBear()
    {
        lock (_bearLock)
        {
            Monitor.Pulse(_bearLock);
        }

    }

    void BearWork()
    {
        lock (_bearLock)
        {
            while (times > 0)
            {
                if (_honeyPot.IsFull())
                {
                    _honeyPot.ConsumeAll();
                    times--;
                }
                Monitor.Wait(_bearLock);
            }
        }
    }

    public void Run(int nBees)
    {
        for (var i = 0; i < nBees; ++i)
        {
            var i1 = i;
            Task.Run(() => BeeWork(i1));
        }
        var task = Task.Run(BearWork);
        task.Wait();
    }
}
