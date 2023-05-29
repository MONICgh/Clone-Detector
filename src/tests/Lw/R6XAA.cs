var curHoneyAmount = 0;
var random = new Random();
object locker = new();

const int minDelay = 100;
const int maxDelay = 5000;

void PrintHoneyPot()
{
    Console.WriteLine("Honey amount: " + curHoneyAmount);
}

void BearWorkingCycle(int maxHoneyAmount)
{
    while (true)
    {
        lock (locker)
        {
            while (curHoneyAmount < maxHoneyAmount)
            {
                Monitor.Wait(locker);
            }

            curHoneyAmount = 0;
            Console.WriteLine("== Bear ate honey ==");
            PrintHoneyPot();
        }
    }
}

void BeeWorkingCycle(int id, int maxHoneyAmount)
{
    while (true)
    {
        Thread.Sleep(random.Next(minDelay, maxDelay));
        lock (locker)
        {
            if (curHoneyAmount >= maxHoneyAmount)
                continue;

            curHoneyAmount++;
            Console.WriteLine("== Bee " + id + " added honey ==");
            PrintHoneyPot();
            Monitor.PulseAll(locker);
        }
    }
}

void SimulateBearAndBees(int N, int X)
{
    for (var i = 0; i < N; ++i)
    {
        var id = i;
        Task.Run(() => BeeWorkingCycle(id, X));
    }

    Task.Run(() => BearWorkingCycle(X)).Wait();
}

SimulateBearAndBees(4, 10);