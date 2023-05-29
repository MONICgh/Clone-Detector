for (var i = 1; i <= 10; ++i)
{
    var zeo = new ZeroEvenOdd.ZeroEvenOdd(i);
    var A = new Thread(_ => zeo.Zero(Console.Write));
    var B = new Thread(_ => zeo.Even(Console.Write));
    var C = new Thread(_ => zeo.Odd(Console.Write));
    A.Start();
    B.Start();
    C.Start();
    A.Join();
    B.Join();
    C.Join();
    Console.WriteLine();
}