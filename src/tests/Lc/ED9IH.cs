object a = new(), b = new();

void Foo1()
{
    lock (a)
    {   
        Thread.Sleep(500);
        lock (b) { }
    }
}

void Foo2()
{
    lock (b)
    {   
        Thread.Sleep(500);
        lock (a) { }
    }
}

var thread1 = new Thread(Foo1);
thread1.Start();
var thread2 = new Thread(Foo2);
thread2.Start();