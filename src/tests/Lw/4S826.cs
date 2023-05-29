using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lab15
{
    public static class BearBees
    {
        public static void BearAndBees(int N, int X) 
        {
            const int beeLifetime = 15;
            int honey = 0;

            Mutex honey_mutex = new Mutex();

            Action bear = () =>
            {
                honey_mutex.WaitOne();
                if (honey < X)
                {
                    Console.WriteLine("WHAT??!!! THERE IS NOT ENOUGH HONEY!!! - Bear");
                    throw new Exception("Bear awoken incorrectly");
                }

                Console.WriteLine("FEASTING - Bear");
                honey = 0;
                Task.Delay(400);
                Console.WriteLine("BACK TO SLEEP - Bear");
                honey_mutex.ReleaseMutex();
            };

            Action bee = () =>
            {
                Random random = new Random();
                int beeLife = beeLifetime;
                while (beeLife-- > 0)
                {
                    Task.Delay(random.Next(100, 1000));
                    honey_mutex.WaitOne();
                    Console.WriteLine($"{Thread.CurrentThread.Name} collected honey: {honey + 1}/{X}");
                    if (honey + 1 == X)
                    {
                        honey++;
                        Task t = new Task(bear);
                        t.Start();
                    }
                    else
                    {
                        honey++;
                    }
                    honey_mutex.ReleaseMutex();
                }
            };

            List<Task> tasks = new List<Task>();
            for (int i = 0; i < N; ++i)
            {
                tasks.Add(new Task(bee));
                tasks[tasks.Count - 1].Start();
            }
            foreach (var t in tasks)
                t.Wait();
        }
    }

}
