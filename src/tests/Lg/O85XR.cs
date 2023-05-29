void RunZeroEvenOdd(int n)
{
    var zeroEvenOdd = new ZeroEvenOdd.ZeroEvenOdd(n);
    var threads = new List<Thread>
    {
        new(() => zeroEvenOdd.Zero(Console.Write)),
        new(() => zeroEvenOdd.Even(Console.Write)),
        new(() => zeroEvenOdd.Odd(Console.Write))
    };

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

RunZeroEvenOdd(2);
RunZeroEvenOdd(5);