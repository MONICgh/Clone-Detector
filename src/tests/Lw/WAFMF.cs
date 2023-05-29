
using System;

namespace task1
{
    class Bee
    {
        private static readonly Random _random = new Random();

        public Bee() {}   

        public void Work(int index, ref HoneyPot pot)
        {
            while(true)
            {
                Thread.Sleep(_random.Next() % 100);

                lock (pot)
                {
                    if (!pot.IsFull())
                    {
                        pot.AddPortion();
                        Console.WriteLine($"Bee {index}: {pot.Portions}");
                        Monitor.PulseAll(pot);
                    }
                }
            }
        }
    }
}
