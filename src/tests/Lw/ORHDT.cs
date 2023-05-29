const int n = 10;
const int x = 100;
var cur = 0;
var mutex = new Mutex();

void Bee()
{
    var rng = new Random();
    while (true)
    {
        Thread.Sleep(rng.Next() % 1000);
        mutex.WaitOne();
        if (cur < x)
        {
            ++cur;
        }
        mutex.ReleaseMutex();
    }
}

void Bear()
{
    while (true)
    {
        mutex.WaitOne();
        if (cur == x)
        {
            Console.WriteLine("Honeypot is full! Bear is back to sleep.");
            cur = 0;
        }
        mutex.ReleaseMutex();
    }
}

for (var i = 0; i < n; ++i)
{
    Task.Run(Bee);
}
Task.Run(Bear).Wait();