var zeroEvenOdd = new ZeroEvenOdd.ZeroEvenOdd(5);
var threads = new List<Thread>
{
    new Thread(() => zeroEvenOdd.Zero(Console.Write)),
    new Thread(() => zeroEvenOdd.Odd(Console.Write)),
    new Thread(() => zeroEvenOdd.Even(Console.Write))
};

threads.ForEach(it => it.Start());
threads.ForEach(it => it.Join());