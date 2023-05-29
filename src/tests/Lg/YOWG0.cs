using Task3;

int hCount, oCount;
object locker = new();

void CheckReleaseH2O()
{
    if (hCount == 2 && oCount == 1)
    {
        hCount = 0;
        oCount = 0;
    }
}

void ReleaseHydrogen()
{
    lock (locker)
    {
        while (hCount >= 2)
        {
            Monitor.Wait(locker);
        }

        hCount++;
        Console.Write("H");
        
        CheckReleaseH2O();
        Monitor.PulseAll(locker);
    }
}

void ReleaseOxygen()
{
    lock (locker)
    {
        while (oCount >= 1)
        {
            Monitor.Wait(locker);
        }

        oCount++;
        Console.Write("O");
        
        CheckReleaseH2O();
        Monitor.PulseAll(locker);
    }
}

void Generate(string elems)
{
    hCount = 0;
    oCount = 0;
    var h2o = new H2O();
    var threads = new List<Thread>();
    foreach (var elem in elems)
    {
        if (elem == 'H')
        {
            threads.Add(new Thread(() => h2o.Hydrogen(ReleaseHydrogen)));
        } else if (elem == 'O')
        {
            threads.Add(new Thread(() => h2o.Oxygen(ReleaseOxygen)));
        }
    }

    foreach (var thread in threads)
    {
        thread.Start();
    }

    foreach (var thread in threads)
    {
        thread.Join();
    }
}

Generate("HOH");
Console.WriteLine();
Generate("OOHHHH");
Console.WriteLine();
Generate("HHHHHHOOO");
Console.WriteLine();
Generate("HOHOHOHOHHHH");