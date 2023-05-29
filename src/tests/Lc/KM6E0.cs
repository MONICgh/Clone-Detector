var n = Convert.ToInt32(Console.ReadLine());

var foobar = new FooBar.FooBar(n);
var mutex = new Mutex();

void PrintFoo()
{
    mutex.WaitOne();
    Console.Write("foo");
    mutex.ReleaseMutex();
}

void PrintBar()
{
    mutex.WaitOne();
    Console.Write("bar");
    mutex.ReleaseMutex();
}

var threadFoo = new Thread(() => foobar.Foo(PrintFoo));
threadFoo.Start();
var threadBar = new Thread(() => foobar.Bar(PrintBar));
threadBar.Start();
threadFoo.Join();
threadBar.Join();