using System;
using System.Threading;
using static System.Collections.Specialized.BitVector32;

namespace Lab16
{
    public class MultithreadArray
    {
        int[] array;
        Mutex ReaderRight = new Mutex();
        Mutex ArrayAccess = new Mutex();
        object ReaderValue = new object();
        object WriterValue = new object();
        int readers = 0;
        int writers = 0;

        ReaderWriterLockSlim lockSlim = new ReaderWriterLockSlim();

        public MultithreadArray(int[] array)
        {
            this.array = array;
        }

        public float TAvg()
        {
            int sum = 0;

            lockSlim.EnterReadLock();
            foreach (int elem in array)
            {
                sum += elem;
            }
            foreach (var i in array)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("(TAvg)");
            lockSlim.ExitReadLock();

            return 1.0f * sum / array.Length;
        }

        public int TMin()
        {
            int min = Int32.MaxValue;

            lockSlim.EnterReadLock();
            foreach (int elem in array)
            {
                min = Math.Min(min, elem);
            }
            foreach (var i in array)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("(TMin)");
            lockSlim.ExitReadLock();

            return min;
        }

        public void TSort()
        {
            lockSlim.EnterWriteLock();
            Array.Sort(array);
            foreach (var i in array)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("(TSort)");
            lockSlim.ExitWriteLock();
        }

        public void TSwap()
        {
            Random random = new Random();
            int a = random.Next(array.Length);
            int b = random.Next(array.Length);

            lockSlim.EnterWriteLock();
            int tmp = array[a];
            array[a] = array[b];
            array[b] = tmp;
            foreach (var i in array)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("(TSwap)");
            lockSlim.ExitWriteLock();
        }
    }
}
