var writer1 = new SyncWriter("Writer 1");
var writer2 = new SyncWriter("Writer 2");

internal class SyncWriter
{
    static Semaphore sem = new(1, 1);
    private Thread _thread;
    private readonly string _name;

    public SyncWriter(string name)
    {
        _name = name;
        _thread = new Thread(Write);
        _thread.Start();
    }

    private void Write()
    {
        for (int i = 0; i < 10; i++)
        {
            sem.WaitOne();

            Console.WriteLine($"{_name} writes line {i + 1}.");

            Thread.Sleep(100);

            sem.Release();
        }
    }
}