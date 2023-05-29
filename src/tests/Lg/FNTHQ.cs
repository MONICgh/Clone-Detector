namespace ZeroEvenOdd;

public class ZeroEvenOdd
{
    private int n;
    private AutoResetEvent zero = new AutoResetEvent(true);
    private AutoResetEvent even = new AutoResetEvent(false);
    private AutoResetEvent odd = new AutoResetEvent(false);

    public ZeroEvenOdd(int n)
    {
        this.n = n;
    }

    // printNumber(x) outputs "x", where x is an integer.
    public void Zero(Action<int> printNumber)
    {
        for (var i = 0; i < n; ++i)
        {
            zero.WaitOne();
            printNumber(0);
            zero.Reset();

            if (i % 2 == 0)
            {
                odd.Set();
            }
            else
            {
                even.Set();
            }
        }
    }

    public void Even(Action<int> printNumber)
    {
        for (var i = 2; i <= n; i += 2)
        {
            even.WaitOne();
            printNumber(i);
            even.Reset();
            zero.Set();
        }
    }

    public void Odd(Action<int> printNumber)
    {
        for (var i = 1; i <= n; i += 2)
        {
            odd.WaitOne();
            printNumber(i);
            odd.Reset();
            zero.Set();
        }
    }
}
