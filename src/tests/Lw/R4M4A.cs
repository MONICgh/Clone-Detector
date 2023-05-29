using System;
using System.Threading;

namespace Lab15
{
    public class Barbershop
    {
        int chairs;
        Mutex queue_mutex = new Mutex();
        Mutex barber_seat = new Mutex();

        public Barbershop(int queue_size)
        {
            chairs = queue_size;
        }

        public void Customer()
        {
            if (chairs <= 0)
            {
                Console.WriteLine($"Queue is full, {Thread.CurrentThread.Name} is leaving.");
                return;
            }

            try
                {
                    queue_mutex.WaitOne();
                    if (chairs <= 0)
                    {
                        Console.WriteLine($"Queue is full, {Thread.CurrentThread.Name} is leaving.");
                        return;
                    }
                    chairs--;

                }
                finally { queue_mutex.ReleaseMutex(); }
            
            try
            {
                barber_seat.WaitOne();
                Console.WriteLine($"{Thread.CurrentThread.Name} gets sheared...");
                Thread.Sleep(300);

                Console.WriteLine($"{Thread.CurrentThread.Name} Finished shearing, leaving"); 
                try
                {
                    queue_mutex.WaitOne();
                    chairs++;

                }
                finally { queue_mutex.ReleaseMutex(); }



            }
            finally { barber_seat.ReleaseMutex(); }

        }
    }
}
