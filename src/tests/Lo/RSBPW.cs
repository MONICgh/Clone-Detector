using System;
using System.Threading;

namespace MyCountDownEvent
{
    public class CMyCountdownEvent : IDisposable
    {
        int count;
        ManualResetEvent _event;
        public CMyCountdownEvent(int initialCount)
        {
            count = initialCount;
            _event = new ManualResetEvent(false);
        }

        public void Signal()
        {
            Signal(1);
        }

        public void Signal(int signalCount)
        {
            if (count < signalCount)
                throw new Exception("bad signal");
            count -= signalCount;
            if (count == 0)
            {
                _event.Set();
            }
        }

        public bool Wait(TimeSpan timeout)
        {
            return _event.WaitOne(timeout);
        }

        public void Dispose()
        {
            _event.Dispose();
        }
    }

    class Program
    {
        const int Threads = 7;
        static CMyCountdownEvent _cde = new CMyCountdownEvent(Threads);
        static void DoIt()
        {
            Console.WriteLine("DoIt");
            _cde.Signal();
            Console.WriteLine("after signal");
        }

        static void Main(string[] args)
        {
            Thread[] threads = new Thread[Threads];
            for (int i = 0; i < Threads; i++)
            {
                threads[i] = new Thread(DoIt);
                threads[i].Start();
            }

            Console.WriteLine("Wait for event");
            _cde.Wait(new TimeSpan(100));
            Console.WriteLine("event signaled");

            foreach (var thr in threads)
                thr.Join();
        }
    }
}
