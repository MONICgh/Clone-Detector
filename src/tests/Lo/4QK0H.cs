using Task2;

void runInOrder(int first, int second, int third)
{
    var foo = new Foo();
    var order = 0;
    var locker = new object();

    var tA = new Thread(() =>
    {
        lock (locker)
        {
            foo.first();
            order = 1;
            Monitor.PulseAll(locker);
        }
    });

    var tB = new Thread(() =>
    {
        lock (locker)
        {
            while (order < 1)
            {
                Monitor.Wait(locker);
            }

            foo.second();
            order = 2;
            Monitor.PulseAll(locker);
        }
    });

    var tC = new Thread(() =>
    {
        lock (locker)
        {
            while (order < 2)
            {
                Monitor.Wait(locker);
            }

            foo.third();
            order = 3;
            Monitor.PulseAll(locker);
        }
    });

    var threads = new List<Thread> { tA, tB, tC };
    threads[first-1].Start();
    threads[second-1].Start();
    threads[third-1].Start();
    foreach (var thread in threads)
    {
        thread.Join();
    }
    Console.WriteLine();
}

runInOrder(1, 2, 3);
runInOrder(1, 3, 2);
runInOrder(3, 2, 1);