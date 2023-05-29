using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading;
using static System.Collections.Specialized.BitVector32;

namespace Lab16
{
    [TestClass]
    public class MultiThreadArrayTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            const int iter_count = 100;
            int[] array = { 1, 2, 7, 8, 3, 4, 5, 6, 1, 2, 3, 4, 11, 10 };
            MultithreadArray mA = new MultithreadArray(array);

            Random random = new Random();
            List<Thread> threads = new List<Thread>();

            Func<int, Action> byNum = (int num) =>
            {
                switch (num)
                {
                    case 0:
                        return () => { Console.WriteLine($"{mA.TAvg()}"); };
                    case 1:
                        return () => { Console.WriteLine($"{mA.TMin()}"); };
                    case 2:
                        return mA.TSort;
                    case 3:
                        return mA.TSwap;
                    default:
                        return () => { };
                }
            };

            for (int i = 0; i < iter_count; ++i)
            {
                int action_num = random.Next(4);
                Action action = byNum(action_num);
                Thread thread = new Thread(new ThreadStart(action));
                threads.Add(thread);
            }

            foreach (var t in threads)
            {
                t.Start();
            }
            foreach (var t in threads)
            {
                t.Join();
            }

        }
    }
    [TestClass]
    public class OtherTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int participantCount = 5;
            CMyBarrier barrier = new CMyBarrier(participantCount);
            Action<object> run = (object obj) => 
            { 
                int i = (int)obj;
                Console.WriteLine($"Thread {i} started");
                barrier.SignalAndWait(TimeSpan.FromMilliseconds(1000));
                Console.WriteLine($"Thread {i} finished");
            };

            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < participantCount; ++i)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(run));
                threads.Add(thread);
                thread.Start(i);
            }

            foreach(var t in threads)
            {
                t.Join();
            }
        }
    }
}
