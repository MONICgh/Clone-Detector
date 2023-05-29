namespace ZeroEvenOdd;

public class ZeroEvenOdd {
    private readonly int _n;
    private int _curPos;
    private readonly object _locker = new();

    public ZeroEvenOdd(int n) {
        _n = n;
    }
    // printNumber(x) outputs "x", where x is an integer.
    public void Zero(Action<int> printNumber) {
        PrintingCycle(_ => printNumber(0), pos => pos % 2 == 0);
    }
    public void Even(Action<int> printNumber)
    {
        PrintingCycle(pos => printNumber((pos + 1) / 2), pos => pos % 4 == 3);
    }
    public void Odd(Action<int> printNumber) {
        PrintingCycle(pos => printNumber((pos + 1) / 2), pos => pos % 4 == 1);
    }

    private bool IsTerminated => _curPos >= 2 * _n;

    private void PrintingCycle(Action<int> printNumberByPosition, Func<int, bool> printingCondition)
    {
        while (!IsTerminated)
        {
            lock (_locker)
            {
                while (!IsTerminated && !printingCondition(_curPos))
                {
                    Monitor.Wait(_locker);
                }

                if (IsTerminated)
                {
                    break;
                }

                printNumberByPosition(_curPos);
                _curPos++;
                Monitor.PulseAll(_locker);
            }
        }
    }
}