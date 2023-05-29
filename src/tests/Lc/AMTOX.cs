using System.Reflection;

namespace Application
{
    class Task2
    {
        static void Fun(string name, ManualResetEventSlim mre1, ManualResetEventSlim mre2)
        {
            for (int i = 0; i < 10; i++)
            {
                mre1.Wait();
                Thread.Sleep(50);
                Console.WriteLine($"{name} {i}");
                mre2.Set();
                mre1.Reset();
            }
        }
        
        static void Main()
        {
            ManualResetEventSlim mre1 = new ManualResetEventSlim(true); 
            ManualResetEventSlim mre2 = new ManualResetEventSlim(false); 
            Thread fun1Thread = new Thread(() => Fun("thread1", mre1, mre2));
            Thread fun2Thread = new Thread(() => Fun("thread2", mre2, mre1));
            fun1Thread.Start();
            fun2Thread.Start();
            fun1Thread.Join();
            fun2Thread.Join();
            mre1.Dispose();
            mre2.Dispose();
        }
    }
}
