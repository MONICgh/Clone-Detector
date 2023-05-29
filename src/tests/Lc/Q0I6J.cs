Mutex mutex = new Mutex();

var first = true;
    
void F1()
{
    for (int i = 0; i < 10; i++)
    {
        while (true)
        {
            mutex.WaitOne();
            if (first)
            {
                Console.WriteLine("foo");
                first = !first;
                mutex.ReleaseMutex();
                break;
            }

            mutex.ReleaseMutex();
        }
    }
}

void F2()
{
    for (int i = 0; i < 10; i++)
    {
        while (true)
        {
            mutex.WaitOne();
            if (!first)
            {
                Console.WriteLine("bar");
                first = !first;
                mutex.ReleaseMutex();
                break;
            }

            mutex.ReleaseMutex();
        }
    }
}

var T1 = new Thread(F1);
var T2 = new Thread(F2);

T1.Start();
T2.Start();

T1.Join();
T2.Join();

