using System.Reflection;

namespace Application
{
    class Task1
    {
        private static readonly object blocker1 = new object();
        private static readonly object blocker2 = new object();
        
        static void Fun1()
        {
            lock (blocker1)
            {
                Thread.Sleep(100);
                lock (blocker2)
                {
                    Thread.Sleep(100);
                    Console.WriteLine("Fun1");
                }
            }
        }
        
        static void Fun2()
        {
            lock (blocker2)
            {
                Thread.Sleep(100);
                lock (blocker1)
                {
                    Thread.Sleep(100);
                    Console.WriteLine("Fun2");
                }
            }
        }
        
        static void Main()
        {
            Thread fun1Thread = new Thread(Fun1);
            Thread fun2Thread = new Thread(Fun2);
            fun1Thread.Start();
            fun2Thread.Start();
            fun1Thread.Join();
            fun2Thread.Join();
            Console.WriteLine("unreachable");
        }
    }
}
