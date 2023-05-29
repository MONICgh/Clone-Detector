int x;

void Delay(double delayProbability = 0.6, int delayMscs = 100)
{
    var p = (new Random().Next() % 100) / 100.0;
    if (p < delayProbability)
    {
        Thread.Sleep(delayMscs);
    }
}

void SetX(int value)
{
    Delay();
    if (x == 0)
    {
        Delay();
        x = value;
    }
}

void XRaceCondition()
{
    x = 0;
    var t1 = new Thread(() => SetX(2));
    var t2 = new Thread(() => SetX(3));
    
    t1.Start();
    t2.Start();
    t1.Join();
    t2.Join();
    
    Console.WriteLine("x = " + x);
}

for (int i = 0; i < 20; i++)
{
    XRaceCondition();
}