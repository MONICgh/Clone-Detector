using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Lab13
{
    public static class Deadlock
    {
        public static void PrintHello()
        {
            System.Console.WriteLine("Hello");
        }

        public static void PrintWorld()
        {
            System.Console.WriteLine("World");
        }

        public static void Die()
        {
            object lock1 = new object();
            object lock2 = new object();
            Thread t1 = new Thread(() =>
            {
                lock (lock1)
                {
                    Thread.Sleep(1000);
                    lock(lock2)
                    {
                        PrintHello();
                    }
                }
            });
            Thread t2 = new Thread(() =>
            {
                lock (lock2)
                {
                    Thread.Sleep(1000);
                    lock (lock1)
                    {
                        PrintWorld();
                    }
                }
            });

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
        }
    }
}
