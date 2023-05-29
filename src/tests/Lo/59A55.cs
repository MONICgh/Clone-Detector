using OrderedPrint;

int actionsCount;
object o;

void Delay(double delayProbability = 0.33, int delayMscs = 500)
{
    var p = (new Random().Next() % 100) / 100.0;
    if (p < delayProbability)
    {
        Thread.Sleep(delayMscs);
    }
}

void OrderedAction(Action action, int order)
{
    lock (o)
    {
        while (actionsCount < order)
        {
            Monitor.Wait(o);
        }

        Delay();
        action();
        actionsCount += 1;
        Monitor.PulseAll(o);
    }
}

void OrderedPrint(List<int> order)
{
    actionsCount = 0;
    o = new object();
    var foo = new Foo();

    var threads = new List<Thread>
    {
        new(() => OrderedAction(foo.First, 0)),
        new(() => OrderedAction(foo.Second, 1)),
        new(() => OrderedAction(foo.Third, 2))
    };

    threads = threads
        .Select((thread, i) => (thread, order[i]))
        .OrderBy(tuple => tuple.Item2)
        .Select(tuple => tuple.thread)
        .ToList();

    foreach (var thread in threads)
    {
        thread.Start();
    }

    foreach (var thread in threads)
    {
        thread.Join();
    }
    
    Console.WriteLine();
}

for (var i = 0; i < 20; i++)
{
    var order = new List<int> { 1, 2, 3 };
    var rand = new Random();
    order = order.OrderBy(_ => rand.Next()).ToList();
    Console.WriteLine("[" + String.Join(", ", order) + "]");
    OrderedPrint(order);
}