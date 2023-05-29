using MyWaitAll;

void SimpleTest()
{
    var atomsNumber = 10;
    var waitAll = new CMyWaitAll(atomsNumber);

    var tasks = new List<Task>(atomsNumber + 1);
    for (var i = 0; i <= atomsNumber; i++)
    {
        var id = i;
        tasks.Add(new Task(() =>
        {
            Thread.Sleep((int) Random.Shared.NextInt64(500, 1000));
            Console.WriteLine($"Signal {id}");
            waitAll.SetAtomSignaled(id);
        }));
    }

    foreach (var task in tasks)
    {
        task.Start();
    }
    
    var result = waitAll.Wait(TimeSpan.FromSeconds(2));
    Console.WriteLine($"Wait result: {result}");

    Task.WaitAll(tasks.ToArray());
}

void WaitAllBlockedTest()
{
    var atomsNumber = 10;
    var waitAll = new CMyWaitAll(atomsNumber);

    var tasks = new List<Task>(atomsNumber + 1);
    for (var i = 0; i <= atomsNumber; i++)
    {
        var id = i;
        tasks.Add(new Task(() =>
        {
            Thread.Sleep((int) Random.Shared.NextInt64(100, 400));
            Console.WriteLine($"Signal {id}");
            waitAll.SetAtomSignaled(id);
        }));
    }

    foreach (var task in tasks)
    {
        task.Start();
    }
    
    var result = waitAll.Wait(TimeSpan.FromMilliseconds(200));
    Console.WriteLine($"Wait result: {result}");
    
    result = waitAll.Wait(TimeSpan.FromSeconds(2));
    Console.WriteLine($"Wait result: {result}");

    Task.WaitAll(tasks.ToArray());
}

void LargeAtomsNumberTest()
{
    var atomsNumber = 500 - 1;
    var signaledCnt = 0;
    var locker = new object();
    var waitAll = new CMyWaitAll(atomsNumber);
    var result = false;

    var tasks = new List<Task>(atomsNumber + 1);
    for (var i = 0; i <= atomsNumber; i++)
    {
        var id = i;
        tasks.Add(new Task(() =>
        {
            Thread.Sleep((int) Random.Shared.NextInt64(100, 300));
            lock (locker)
            {
                signaledCnt += 1;
                if (signaledCnt % 50 == 0)
                {
                    Console.WriteLine($"Signaled {signaledCnt}/{atomsNumber + 1}");
                }                
            }
            waitAll.SetAtomSignaled(id);
        }));
    }

    foreach (var task in tasks)
    {
        task.Start();
    }

    for (int i = 1; i <= 12; i += 3)
    {
        result = waitAll.Wait(TimeSpan.FromSeconds(i));
        Console.WriteLine($"Wait result: {result}");
    }

    Task.WaitAll(tasks.ToArray());
}

SimpleTest();