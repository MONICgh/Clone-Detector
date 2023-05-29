using Task1;

void ZeroEvenOdd(int n)
{
    var zeroEvenOdd = new ZeroEvenOdd(n);
    var threads = new List<Thread>();
    threads.Add(new Thread(() => zeroEvenOdd.Zero(Console.Write)));
    threads.Add(new Thread(() => zeroEvenOdd.Even(Console.Write)));
    threads.Add(new Thread(() => zeroEvenOdd.Odd(Console.Write)));
    foreach (var thread in threads)
    {
        thread.Start();
    }

    foreach (var thread in threads)
    {
        thread.Join();
    }
}

ZeroEvenOdd(2);
Console.WriteLine();
ZeroEvenOdd(5);
Console.WriteLine();