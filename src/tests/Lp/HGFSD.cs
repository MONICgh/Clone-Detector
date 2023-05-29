using System.Collections;


namespace HashWithIDisposable
{
    internal class UnmanagedResource
    {
        public UnmanagedResource()
        {
            Console.WriteLine("Allocating unmanaged resource");
        }

        public void Clean()
        {
            Int32 generation = GC.GetGeneration(this);
            Console.WriteLine("Cleaning unmanaged resource in {0} generation", generation);
        }
        ~UnmanagedResource(){
            System.Diagnostics.Trace.WriteLine("First's finalizer is called.");
        }
    }

    class DisposableObject : IDisposable
    {
        private readonly UnmanagedResource _resource;
        public Timer _timer;
        public bool isOld { get; private set; }

        public DisposableObject(int max_time)
        {
            isOld = false;
            _resource = new UnmanagedResource();
            _timer = new Timer(Old, null, 0, max_time);
        }

        public void Dispose()
        {
            _resource.Clean();
            GC.SuppressFinalize(this);
        }

        private void Old(Object state)
        {
            if (!isOld)
                Console.WriteLine("Obj is old now");
            isOld = true;
        }

        ~DisposableObject()
        {
            System.Diagnostics.Trace.WriteLine("Second's finalizer is called.");
        }
    }
    class Cash
    {
        DisposableObject[] elems;
        int max_size;
        int cur_cnt = 0;
        int max_time;

        public Cash(int max_size , int time )
        {
            this.max_size = max_size;
            max_time = time;
            elems = new DisposableObject[max_size];
            GC.RegisterForFullGCNotification(10, 10);
            Thread t = new Thread(new ThreadStart(CheckTheGC));
            t.Start();
        }

        public void Add()
        {
            if (cur_cnt == max_size)
            {
                Console.WriteLine("Add Overflow");
                Cleanup();
            }

            for (int i = 0; i < max_size; i++)
            {
                if (elems[i] == null)
                {
                    elems[i] = new DisposableObject(max_time);
                    cur_cnt++;
                    break;
                }
            }
        }

        private void Cleanup()
        {
            Console.WriteLine("Clean Up");
            for (int i = 0; i < max_size; i++)
            {
                if (elems[i] != null && elems[i].isOld)
                {
                    elems[i].Dispose();
                    elems[i] = null;
                    cur_cnt--;
                }
            }
        }

        private void CheckTheGC()
        {
            Console.WriteLine("Waiting GC Notify");
            while (true) 
            {
                GCNotificationStatus s = GC.WaitForFullGCApproach();
                if (s == GCNotificationStatus.Succeeded)
                {
                    Console.WriteLine("GC Notification");
                    Cleanup();
                    Thread.Sleep(1000);
                }
            }
        }

    }


    class Program
    {
        private static Boolean s_carryOn;
        static void TestOverflow()
        {
            var cash = new Cash(10, 130);
            for (int i = 0; i < 15; i++)
            {
                cash.Add();
            }
            Console.WriteLine("End of Test1");
        }

        static void TestGCNotification()
        {
            var cash = new Cash(5, 15);
            for (int i = 0; i < 10; i++)
            {
                cash.Add();
            }

            s_carryOn = true;

            GC.RegisterForFullGCNotification(10, 10);
            Thread t = new Thread(new ThreadStart(CheckTheGC));
            t.Start();

            Int32 secondsPassed = 0;
            ArrayList data = new ArrayList();
            while (s_carryOn)
            {
                Console.WriteLine("{0} seconds passed", secondsPassed++);

                for (Int32 i = 0; i < 1000; i++)
                    data.Add(new Byte[1000]);
                Thread.Sleep(1000);
            }

            Console.WriteLine("End of Test2");

        }

        static void Main(string[] args)
        {
            TestOverflow();
            TestGCNotification();
        }

        private static void CheckTheGC()
        {
            while (true) 
            {
                GCNotificationStatus s = GC.WaitForFullGCApproach();
                if (s == GCNotificationStatus.Succeeded)
                {
                    Console.WriteLine("Full GC Nears");
                    break;
                }
            }

            while (true) 
            {
                GCNotificationStatus s = GC.WaitForFullGCComplete();
                if (s == GCNotificationStatus.Succeeded)
                {
                    Console.WriteLine("Full GC Complete");
                    break;
                }
            }

            s_carryOn = false;
        }
    }
}