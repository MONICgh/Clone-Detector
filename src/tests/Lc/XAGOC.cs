var mutex = new Mutex();

void Foo1()
{
    var cnt = 0;
    while (cnt < 10)
    {
        mutex.WaitOne();
        ++cnt;
        Console.WriteLine($"Thread 1, Line {cnt}");
        mutex.ReleaseMutex();
    }
}

void Foo2()
{
    var cnt = 0;
    while (cnt < 10)
    {
        mutex.WaitOne();
        ++cnt;
        Console.WriteLine($"Thread 2, Line {cnt}");
        mutex.ReleaseMutex();
    }
}

var thread1 = new Thread(Foo1);
thread1.Start();
var thread2 = new Thread(Foo2);
thread2.Start();
thread1.Join();
thread2.Join();