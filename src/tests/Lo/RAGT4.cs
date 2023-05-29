namespace HW_14;

public class RaceExample
{
    private int _x;

    private void Assign2()
    {
        _x = 2;
    }

    private void Assign3()
    {
        _x = 3;
    }

    public int Run1()
    {
        Thread thread2 = new Thread(Assign2);
        Thread thread3 = new Thread(Assign2);
        thread2.Start();
        Thread.Sleep(1000);
        thread3.Start();
        thread2.Join();
        thread3.Join();
        return _x;
    }

    public int Run2()
    {
        Thread thread2 = new Thread(Assign2);
        Thread thread3 = new Thread(Assign2);
        thread3.Start();
        Thread.Sleep(1000);
        thread2.Start();
        thread2.Join();
        thread3.Join();
        return _x;
    }
}
