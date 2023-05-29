double res = 0;
const int numberOfThreads = 100;

void Calc(int i)
{
    for (var it = 0; it < 1000; ++it, i += numberOfThreads)
    {
        var j = 1.0 / i;
        if (i % 2 == 0) j *= -1;
        res += j;
    }
}

double CalculateLn2()
{
    res = 0;
    var threads = new List<Thread>();
    for (var it = 1; it <= 10; ++it)
    {
        var thread = new Thread(_ => Calc(it));
        thread.Start();
        threads.Add(thread);
    }

    for (var it = 0; it < 10; ++it)
    {
        threads[it].Join();
    }
    return res;
}

for (var i = 0; i < 10; ++i)
{
    Console.WriteLine(CalculateLn2());
}

/*
0,6082878763990881
0,5342287769358948
1,2126134983935557
0,9378849987489097
1,4629284426149165
2,4484643044636494
2,6520021374621465
2,2574900281428496
1,2760650982812962
0,7090569218565131
*/