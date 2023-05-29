namespace HW_13;

public class FooBar
{
    private readonly int n;

    private static readonly object MockConsoleResource = new();
    private static bool _firstIsOwner = true;

    public FooBar(int n)
    {
        this.n = n;
    }

    public void Foo(Action printFoo)
    {
        for (int i = 0; i < n; i++)
        {
            lock (MockConsoleResource)
            {
                if (_firstIsOwner)
                {
                    // printFoo() outputs "foo". Do not change or remove this line.
                    printFoo();
                    _firstIsOwner = false;
                }
            }
        }
    }
    public void Bar(Action printBar)
    {
        for (int i = 0; i < n; i++)
        {
            lock (MockConsoleResource)
            {
                if (!_firstIsOwner)
                {
                    // printBar() outputs "foo". Do not change or remove this line.
                    printBar();
                    _firstIsOwner = true;
                }
            }
        }
    }
}
