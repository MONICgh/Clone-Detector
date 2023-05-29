namespace HW_13;

public class ThreadPrinter
{
    private static readonly object MockConsoleResource = new();
    private static bool _firstIsOwner;
    private static void Print1()
    {
        for (var i = 0; i < 10; i++)
        {
            lock (MockConsoleResource)
            {
                if (_firstIsOwner)
                {
                    Console.WriteLine($"Thread1 ${i}");
                    _firstIsOwner = false;
                }
            }
        }
    }

    private static void Print2()
    {
        for (var i = 0; i < 10; i++)
        {
            lock (MockConsoleResource)
            {
                if (_firstIsOwner)
                    continue;
                Console.WriteLine($"Thread2 ${i}");
                _firstIsOwner = true;
            }
        }
    }

    public void Runner()
    {
        var thread1 = new Thread(Print1);
        var thread2 = new Thread(Print2);
        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }
}
