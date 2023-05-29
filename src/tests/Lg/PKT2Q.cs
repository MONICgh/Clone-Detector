namespace ZeroEvenOdd;

public class ZeroEvenOdd
{
    private int n;
    private readonly AutoResetEvent _zeroEvent = new AutoResetEvent(true);
    private readonly AutoResetEvent _oddEvent = new AutoResetEvent(false);
    private readonly AutoResetEvent _evenEvent = new AutoResetEvent(false);

    public ZeroEvenOdd(int n)
    {
        this.n = n;
    }

    // printNumber(x) outputs "x", where x is an integer.
    public void Zero(Action<int> printNumber)
    {
        for (int i = 1; i <= n; i++)
        {
            _zeroEvent.WaitOne();
            printNumber(0);
            _zeroEvent.Reset();

            if (i % 2 == 0)
            {
                _evenEvent.Set();
            }
            else
            {
                _oddEvent.Set();
            }
        }
    }

    public void Even(Action<int> printNumber)
    {
        for (int i = 2; i <= n; i+=2)
        {
            _evenEvent.WaitOne();
            printNumber(i);
            _evenEvent.Reset();
            _zeroEvent.Set();
        }
    }

    public void Odd(Action<int> printNumber)
    {
        for (int i = 1; i <= n; i+=2)
        {
            _oddEvent.WaitOne();
            printNumber(i);
            _oddEvent.Reset();
            _zeroEvent.Set();
        }
    }
}