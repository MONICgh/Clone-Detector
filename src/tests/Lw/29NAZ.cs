namespace MyWaitAll;

public class CMyWaitAll : IDisposable
{
    private readonly AutoResetEvent _event = new(false);
    private readonly object _locker = new();
    private readonly List<bool> _isSignaled;
    private readonly int _atomsNumber;
    private int _operatedCnt;

    public CMyWaitAll(int atomsNumber)
    {
        _atomsNumber = atomsNumber;
        _operatedCnt = 0;

        _isSignaled = new List<bool>(_atomsNumber + 1);
        for (var i = 0; i <= atomsNumber; i++)
        {
            _isSignaled.Add(false);
        }
    }

    public void SetAtomSignaled(int atomId)
    {
        lock (_locker)
        {
            if (_isSignaled[atomId])
                return;

            _isSignaled[atomId] = true;
            _operatedCnt++;

            if (_operatedCnt == _atomsNumber + 1)
            {
                _event.Set();
            }
        }
    }

    public bool Wait(TimeSpan timeout)
    {
        return _event.WaitOne(timeout);
    }

    public void Dispose()
    {
        _event.Dispose();
    }
}