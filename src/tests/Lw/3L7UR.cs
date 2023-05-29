using System;
using System.Threading;
using System.Threading.Tasks;

namespace BearAndBees
{
    class Jar : IDisposable
    {
        readonly int beesCnt;
        readonly int capacity;
        int curHoney = 0;
        private bool BearIsEating = false;
        Random rand = new Random();
        CountdownEvent notifyBear;
        Mutex m = new Mutex();
        Task[] bees;
        Task bear;


        public Jar(int n, int x)
        {
            beesCnt = n;
            capacity = x;
            notifyBear = new CountdownEvent(x);
            bear = new Task(() => EatAll());
            bees = new Task[n];
            for (int i = 0; i < n; i++)
            {
                var copy = i;
                bees[i] = new Task(() => AddHoney(copy));
            }
        }

        public void Run()
        {
            bear.Start();
            for (int i = 0; i < beesCnt; i++)
                bees[i].Start();
        }

        public void WaitBear()
        {
            bear.Wait();
        }

        private void AddHoney(int num)
        {
            Thread.Sleep(rand.Next(500, 1000));
            m.WaitOne();
            if (!BearIsEating)
            {
                curHoney++;
                notifyBear.Signal();
                Console.WriteLine("+ 1");
                if (curHoney == capacity)
                {
                    BearIsEating = true;
                }
            }
            bees[num].ContinueWith(t => AddHoney(num));
            m.ReleaseMutex();
        }

        private void EatAll()
        {
            Console.WriteLine($"Bear is sleeping");
            notifyBear.Wait();
            m.WaitOne();
            curHoney = 0;
            Console.WriteLine($"Bear is eating honey");
            notifyBear.Reset();
            BearIsEating = false;
            bear = bear.ContinueWith(t => EatAll());
            m.ReleaseMutex();
        }

        public void Dispose()
        {
            notifyBear.Dispose();
            m.Dispose();
            bear.Dispose();
            foreach (var bee in bees)
                bee.Dispose();
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Jar jar = new Jar(4, 6);
            jar.Run();
            jar.WaitBear();
            jar.WaitBear();
            jar.WaitBear();
        }
    }
}
