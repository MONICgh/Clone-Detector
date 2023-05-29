namespace HW_13;

public class DeadlockExample
{
    private static readonly object Obj1 = new();
    private static readonly object Obj2 = new();

    private void Method1()
    {
        lock (Obj1)
        {
            Thread.Sleep(3000);
            lock (Obj2)
            {

            }
        }
    }

    private void Method2()
    {
        lock (Obj2)
        {
            Thread.Sleep(3000);
            lock (Obj1)
            {

            }
        }
    }

    public void DeadlockRun()
    {
        var thread1 = new Thread(Method1);
        var thread2 = new Thread(Method2);
        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }
}
