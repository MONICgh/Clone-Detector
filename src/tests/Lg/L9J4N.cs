namespace Task1;

public class ZeroEvenOdd {
    private int _n;

    private readonly object _locker = new();
    private int _printed = 0;

    public ZeroEvenOdd(int n) {
        _n = n;
    }
    // printNumber(x) outputs "x", where x is an integer.
    public void Zero(Action<int> printNumber) {
        while (_printed < 2 * _n)
        {
            lock (_locker)
            {
                while (_printed % 2 != 0 && _printed < 2 * _n)
                {
                    Monitor.Wait(_locker);
                }

                if (_printed < 2 * _n)
                {
                    printNumber(0);
                    _printed++;
                }
                
                Monitor.PulseAll(_locker);
            }
        }
    }
    public void Even(Action<int> printNumber) {
        while (_printed < 2 * _n)
        {
            lock (_locker)
            {
                while (_printed % 4 != 3 && _printed < 2 * _n)
                {
                    Monitor.Wait(_locker);
                }

                if (_printed < 2 * _n)
                {
                    printNumber((_printed + 1) / 2);
                    _printed++;
                }

                Monitor.PulseAll(_locker);
            }
        }
    }
    public void Odd(Action<int> printNumber) {
        while (_printed < 2 * _n)
        {
            lock (_locker)
            {
                while (_printed % 4 != 1 && _printed < 2 * _n)
                {
                    Monitor.Wait(_locker);
                }

                if (_printed < 2 * _n)
                {
                    printNumber((_printed + 1) / 2);
                    _printed++;
                }
                
                Monitor.PulseAll(_locker);
            }
        }
    }
} 