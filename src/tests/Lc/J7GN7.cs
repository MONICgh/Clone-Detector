using FooBar;

void FooBarWriter(int n)
{
    var counter = 0;
    MutexLocker locker = new MutexLocker();
    
    var foobar = new FooBar.FooBar(n);
    
    void WriteFoo()
    {
            locker.ObjMutex.WaitOne();
            if (locker.Index % 2 == 0)
            {
                Console.Write("foo");
                locker.Index += 1;
            }
            locker.ObjMutex.ReleaseMutex();
    }

    void WriteBar()
    {
            locker.ObjMutex.WaitOne();
            if (locker.Index % 2 != 0)
            {
                Console.Write("bar");
                locker.Index += 1;
            }
            locker.ObjMutex.ReleaseMutex();
    }

    var thread1 = new Thread(_ => foobar.Foo(WriteFoo));
    var thread2 = new Thread(_ => foobar.Bar(WriteBar));

    thread1.Start();
    thread2.Start();
    
    thread1.Join();
    thread2.Join();
}

FooBarWriter(3);