using System;
using System.Threading;
using System.Threading.Tasks;

namespace DeadLock
{
    public class DeadLock
    {
        public void MakeDeadLock()
        {
            object lock1 = new object();
            object lock2 = new object();
            
            var firstTask = Task.Run(() =>
            {
                lock (lock1)
                {
                    Thread.Sleep(1000);
                    lock (lock2)
                    {
                        Console.WriteLine("Waiting for lock 2...");
                    }
                }
            });
 
            var secondTask = Task.Run(() =>
            {
                lock (lock2)
                {
                    Thread.Sleep(1000);
                    lock (lock1)
                    {
                        Console.WriteLine("Waiting for lock 1...");
                    }
                }
            });
            
            Task.WaitAll(firstTask, secondTask);
        }
    }
}