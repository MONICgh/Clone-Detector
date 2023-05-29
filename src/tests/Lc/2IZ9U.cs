var a = new object();
var b = new object();

var threadAB = new Thread(() =>
{
    lock (a)
    {
        Thread.Sleep(100);
        lock (b)
        {
            Console.WriteLine("Locked A and B");
        }
    }
});
var threadBA = new Thread(() =>
{
    lock (b)
    {
        Thread.Sleep(100);
        lock (a)
        {
            Console.WriteLine("Locked B and A");
        }
    }
});

threadAB.Start();
threadBA.Start();