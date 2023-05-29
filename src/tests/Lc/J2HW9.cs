// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

class SyncOutput
{
    private readonly Semaphore _semaphore;
    
    public SyncOutput()
    {
        _semaphore = new Semaphore(1, 1);
    }

    void Thread1()
    {
        for (int i = 0; i < 10; i++)
        {
            _semaphore.WaitOne();
            Console.WriteLine($"Thread1 #{i}");
            _semaphore.Release();
        }
    }

    void Thread2()
    {
        for (int i = 0; i < 10; i++)
        {
            _semaphore.WaitOne();
            Console.WriteLine($"Thread2 #{i}");
            _semaphore.Release();
        }
    }

    static void Main()
    {
        var syncOutput = new SyncOutput();
        var thread1 = new Thread(syncOutput.Thread1);
        var thread2 = new Thread(syncOutput.Thread2);
        
        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }
}
