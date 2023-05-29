namespace HW_16;

public class ZeroEvenOdd
{
    private readonly int _maxNumber;

    private readonly object _indexLock = new();
    private int _index = 0;

    public ZeroEvenOdd(int maxNumber)
    {
        _maxNumber = maxNumber;
    }

    // printNumber(x) outputs "x", where x is an integer.
    public void Zero(Action<int> printNumber)
    {
        while (true)
        {
            lock (_indexLock)
            {
                while (_index % 2 != 0 && _index < 2 * _maxNumber)
                {
                    Monitor.Wait(_indexLock);
                }

                if (_index < 2 * _maxNumber)
                {
                    printNumber(0);
                    _index++;
                    Monitor.PulseAll(_indexLock);
                }
                else
                {
                    Monitor.PulseAll(_indexLock);
                    return;
                }
            }
        }
    }

    public void Even(Action<int> printNumber)
    {
        while (true)
        {
            lock (_indexLock)
            {
                while (_index % 4 != 3 && _index < 2 * _maxNumber)
                {
                    Monitor.Wait(_indexLock);
                }

                if (_index < 2 * _maxNumber)
                {
                    printNumber((_index + 1) / 2);
                    _index++;
                    Monitor.PulseAll(_indexLock);
                }
                else
                {
                    Monitor.PulseAll(_indexLock);
                    return;
                }
            }
        }
    }

    public void Odd(Action<int> printNumber)
    {
        while (true)
        {
            lock (_indexLock)
            {
                while (_index % 4 != 1 && _index < 2 * _maxNumber)
                {
                    Monitor.Wait(_indexLock);
                }

                if (_index < 2 * _maxNumber)
                {
                    printNumber((_index + 1) / 2);
                    _index++;
                    Monitor.PulseAll(_indexLock);
                }
                else
                {
                    Monitor.PulseAll(_indexLock);
                    return;
                }
            }
        }
    }
}
