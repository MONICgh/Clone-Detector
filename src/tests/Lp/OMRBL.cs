namespace Cache
{
    public class Item : IDisposable
    {
        private readonly int num;
        public Item(int _num)
        {
            num = _num;
        }

        public void Dispose()
        {
            Console.WriteLine("Free Item with num = {0}", num);
        }
    }

    public class Program
    {
        private static void TestAdd()
        {
            Cache<Item> cache = new(5, 1, false);
            for (int i = 1; i <= 5; i++)
            {
                cache.Add(new Item(i));
            }

            Thread.Sleep(1500);
            Console.WriteLine("Pause 1");
            cache.Get(2);

            for (int i = 6; i <= 10; i++)
            {
                cache.Add(new Item(i));
            }

            Thread.Sleep(1500);
            Console.WriteLine("Pause 2");
            cache.Get(3);

            for (int i = 11; i <= 15; i++)
            {
                cache.Add(new Item(i));
            }
        }

        private static void TestGCNotification()
        {
            Cache<Item> cache = new(100000000, 1, true);
            for (int i = 1; i <= 30; i++)
            {
                for (int j = 1; j <= 100000000; j++)
                {
                    Item x = new Item(i);
                }

                cache.Add(new Item(i));
            }
        }
        public static void Main()
        {
            TestAdd();
            TestGCNotification();
        }
    }
}
