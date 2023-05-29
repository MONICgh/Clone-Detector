namespace BearAndBee
{
    public class Program
    {
        public static void Main()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int volume = Convert.ToInt32(Console.ReadLine());

            int honey = 0;
            object pot = new();
            Task bear = new(() =>
            {
                while (true)
                {
                    lock (pot)
                    {
                        Monitor.Wait(pot);
                        if (honey == volume)
                        {
                            Console.WriteLine("Bear eats all honey");
                            honey = 0;
                        }
                    }
                }
            });

            Task[] bees = new Task[n];
            for (int i = 0; i < n; i++)
            {
                int index = i;
                bees[i] = new Task(() =>
                {
                    Random rnd = new();
                    while (true)
                    {
                        lock (pot)
                        {
                            if (honey < volume)
                            {
                                honey++;
                                Console.WriteLine("Bee {0} add honey, honey = {1}", index, honey);
                            }
                            if (honey == volume)
                            {
                                Monitor.Pulse(pot);
                            }
                        }
                        int time = rnd.Next(10) * 1000;
                        Console.WriteLine("Bee {0} sleep for {1} milliseconds", index, time);
                        Thread.Sleep(time);
                    }
                });
            }

            bear.Start();
            for (int i = 0; i < n; i++)
            {
                bees[i].Start();
            }

            bear.Wait();
            Task.WaitAll(bees);
        }
    }
}