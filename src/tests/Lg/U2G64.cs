namespace HW_16;

public class H2O
{

    private const int MaxHydrogen = 1;
    private const int MaxOxygen = 2;

    private int _currentHydrogen;
    private int _currentOxygen;

    public H2O()
    {
    }

    private readonly object _dataLocker = new();
    private string _data = "";

    private void ReleaseHydrogen()
    {
        lock (_dataLocker)
        {
            while (!(_currentHydrogen < MaxHydrogen))
            {
                Monitor.Wait(_dataLocker);
            }

            _data += "H";
            _currentHydrogen += 1;

            if (_currentHydrogen != MaxHydrogen || _currentOxygen != MaxOxygen)
                return;
            _data += " ";
            _currentHydrogen = 0;
            _currentOxygen = 0;
            Monitor.PulseAll(_dataLocker);
        }
    }

    private void ReleaseOxygen()
    {
        lock (_dataLocker)
        {
            while (!(_currentOxygen < MaxOxygen))
            {
                Monitor.Wait(_dataLocker);
            }

            _data += "O";
            _currentOxygen += 1;

            if (_currentHydrogen != MaxHydrogen || _currentOxygen != MaxOxygen)
                return;
            _currentHydrogen = 0;
            _currentOxygen = 0;
            _data += " ";
            Monitor.PulseAll(_dataLocker);
        }
    }

    public String Run(String input)
    {
        _data = "";
        var threads = input.Select(c =>
            c == 'H' ?
                new Thread(() => Hydrogen(ReleaseHydrogen)) :
                new Thread(() => Oxygen(ReleaseOxygen))
        ).ToList();
        foreach (var thread in threads)
        {
            thread.Start();
        }
        foreach (var thread in threads)
        {
            thread.Join();
        }
        return _data;
    }

    public void Hydrogen(Action releaseHydrogen)
    {
        // releaseHydrogen() outputs "H". Do not change or remove this line.
        releaseHydrogen();
    }
    public void Oxygen(Action releaseOxygen)
    {
        // releaseOxygen() outputs "O". Do not change or remove this line.
        releaseOxygen();
    }
}
