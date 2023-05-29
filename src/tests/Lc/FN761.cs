namespace Task3;

public class PrintNFooBar
{
    public static void Apply(int n)
    {
        Mutex mutex = new Mutex();

        var foobar = new FooBar(n);
        var first = true;
    
        void PrintFoo()
        {
            while (true)
            {
                mutex.WaitOne();
                if (first)
                {
                    Console.Write("foo");
                    first = !first;
                    mutex.ReleaseMutex();
                    break;
                }
                mutex.ReleaseMutex();
            }
        }

        void PrintBar()
        {
            while (true)
            {
                mutex.WaitOne();
                if (!first)
                {
                    Console.Write("bar");
                    first = !first;
                    mutex.ReleaseMutex();
                    break;
                }
                mutex.ReleaseMutex();
            }
        }

        var threads = new List<Thread>()
        {
            new(_ => foobar.Foo(PrintFoo)),
            new(_ => foobar.Bar(PrintBar))
        };

        foreach (var thread in threads)
        {
            thread.Start();
        }
        foreach (var thread in threads)
        {
            thread.Join();
        }
    }
}