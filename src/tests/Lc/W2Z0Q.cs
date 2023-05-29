void PrintFooBar(int n)
{
    var foobar = new FooBar.FooBar(n);
    var sem = new Semaphore(1, 1);

    void Print(string str)
    {
        sem.WaitOne();

        Console.Write(str);
        Thread.Sleep(150);

        sem.Release();
    }

    var t1 = new Thread(() => foobar.Foo(() => Print("foo")));
    var t2 = new Thread(() => foobar.Foo(() => Print("bar")));

    t1.Start();
    t2.Start();
    t1.Join();
    t2.Join();

    Console.WriteLine();
}

PrintFooBar(1);
PrintFooBar(2);
PrintFooBar(5);