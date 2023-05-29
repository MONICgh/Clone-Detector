// See https://aka.ms/new-console-template for more information

class Deadlock
{
    private bool flag1 = false;
    private bool flag2 = false;

    private void Thread1()
    {
        Console.WriteLine("Start Thread1");
        flag1 = true;
        do
        {
            Thread.Sleep(100);
        } while (flag2);
        Console.WriteLine("Finish Thread1");
    }

    private void Thread2()
    {
        Console.WriteLine("Start Thread2");
        flag2 = true;
        do
        {
            Thread.Sleep(100);
        } while (flag1);
        Console.WriteLine("Finish Thread2");
    }
    
    public static void Main()
    {
        var d = new Deadlock();
        Thread thread1 = new Thread(d.Thread1);
        Thread thread2 = new Thread(d.Thread2);
        
        thread1.Start();
        thread2.Start();
        
        thread1.Join();
        thread2.Join();
    }
}