// See https://aka.ms/new-console-template for more information

<<<<<<< HEAD
Console.WriteLine("Hello, World!");
=======
string lock1 = "lock1";
string lock2 = "lock2";
int x = 0;

void Foo()
{
    lock (lock1)
    {
        Thread.Sleep(10);
        lock (lock2)
        {
        }
    }
}

void Bar()
{
    lock (lock2)
    {
        lock (lock1)
        {
        }
    }
}

var thread1 = new Thread(Foo);
var thread2 = new Thread(Bar);

thread1.Start();
thread2.Start();
>>>>>>> 021164f2e7594728ef632520dc911e4dc073d6fe
