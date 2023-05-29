namespace H2O
{
    public class Program
    {
        public static void Main()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            H2O vodichka = new();
            Semaphore hydroSem = new(2, 2);
            Semaphore oxySem = new(1, 1);
            Barrier barrier = new(3);

            Thread[] hydro = new Thread[2 * n];
            Thread[] oxy = new Thread[n];
            for (int i = 0; i < 2 * n; i++)
            {
                int curIndex = i;
                hydro[i] = new(() =>
                {
                    vodichka.Hydrogen(() =>
                    {
                        Thread.Sleep(curIndex * 1000);
                        hydroSem.WaitOne();
                        barrier.SignalAndWait();
                        Console.Write("H");
                        hydroSem.Release();
                    });
                });
            }
            for (int i = 0; i < n; i++)
            {
                int curIndex = i;
                oxy[i] = new(() =>
                {
                    vodichka.Oxygen(() =>
                    {
                        Thread.Sleep(curIndex * 1000);
                        oxySem.WaitOne();
                        barrier.SignalAndWait();
                        Console.Write("O");
                        oxySem.Release();
                    });
                });
            }

            for (int i = 0; i < 2 * n; i++)
            {
                hydro[i].Start();
            }
            for (int i = 0; i < n; i++)
            {
                oxy[i].Start();
            }

            for (int i = 0; i < 2 * n; i++)
            {
                hydro[i].Join();
            }
            for (int i = 0; i < n; i++)
            {
                oxy[i].Join();
            }
        }
    }
}
