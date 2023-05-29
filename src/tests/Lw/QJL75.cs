using System.Threading;

namespace task3
{
    class Program
    {
        public static void SimplestTest()
        {
            Console.WriteLine("===Test1===");
            Thread.Sleep(1500);
            Barber barber = new Barber(2);
            Thread task = new Thread(barber.Work);
            task.Start();
            barber.AddClient(new Client("A"));
            barber.AddClient(new Client("B"));
            Thread.Sleep(1500);
            /*
             * ===Test1===
               Added client A
               Added client B
               Served client: A
               Served client: B
             * 
             */
        }

        public static void OverflowTest()
        {
            Console.WriteLine("===Test2===");
            Thread.Sleep(1500);
            Barber barber = new Barber(1);
            Thread task = new Thread(barber.Work);
            task.Start();
            barber.AddClient(new Client("A"));
            Thread.Sleep(1800);
            barber.AddClient(new Client("B"));
            barber.AddClient(new Client("C"));
            Thread.Sleep(1500);

            /*
             * ===Test2===
              Added client A
              Served client: A
              Added client B
              Queue overflow. Skip client C
              Served client: B
             */
        }
        public static void ComplexTest()
        {
            Console.WriteLine("===Test3===");
            Thread.Sleep(1500);
            Barber barber = new Barber(2);
            Thread task = new Thread(barber.Work);
            task.Start();
            barber.AddClient(new Client("A"));
            barber.AddClient(new Client("B"));
            Thread.Sleep(1800);
            barber.AddClient(new Client("C"));
            barber.AddClient(new Client("D"));
            barber.AddClient(new Client("E"));
            Thread.Sleep(1000);

            /*
             * ===Test3===
               Added client A
               Served client: A
               Added client B
               Served client: B
               Added client C
               Added client D
               Queue overflow. Skip client E
               Served client: C
               Served client: D
             */
        }
        public static void Main(string[] args)
       {
           SimplestTest();
           OverflowTest();
           ComplexTest();

        }
    }
}