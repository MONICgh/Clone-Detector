namespace Application
{
    class Task3
    {
        private static List<string> names = new List<string>()
        {
            "Anton",
            "Fedor",
            "Ishmael",
            "Vasya",
            "Petya",
            "Grisha",
            "Gabriel",
            "Isaac",
            "Michael",
            "Athanasius"
        };
        
        private static Random rnd = new Random();

        private static void addClients(Salon salon, int k, int waitMs = 0, bool withRand=false)
        {
            for (int i = 0; i < k; i++)
            {
                salon.AddClient(names[i % 10]);
                if (withRand)
                {
                    Thread.Sleep(rnd.Next(waitMs));
                }
                else
                {
                    Thread.Sleep(waitMs);
                }
            }

            while (!salon.isFinish())
            {
                Thread.Sleep(100);
            }
            Console.WriteLine();
        }
        
        public static void RandomClients(Salon salon)
        {
            Console.WriteLine("RandomClients");
            addClients(salon, salon.MaxClients * 3, 300, true);
        }
        
        public static void DistributionClients(Salon salon)
        {
            Console.WriteLine("DistributionClients");
            addClients(salon, salon.MaxClients * 2, 100);
        }
        
        public static void manyClients3Groups(Salon salon)
        {
            Console.WriteLine("manyClients3Groups");
            addClients(salon, salon.MaxClients + 1, 30);
            addClients(salon, salon.MaxClients + 1, 20);
            addClients(salon, salon.MaxClients + 1, 10);
        }
        
        public static void manyClients(Salon salon)
        {
            Console.WriteLine("manyClients");
            addClients(salon, salon.MaxClients * 2);
        }
        
        public static void fewClients(Salon salon)
        {
            Console.WriteLine("fewClients");
            addClients(salon, salon.MaxClients / 2);
        }
        
        public static void enoughClients(Salon salon)
        {
            Console.WriteLine("enoughClients");
            addClients(salon, salon.MaxClients);
        }
        
        static void Main()
        {
            Hairdresser hairdresser = new Hairdresser();
            Salon salon = new Salon(hairdresser, 5);
            
            fewClients(salon);
            enoughClients(salon);
            manyClients(salon);
            DistributionClients(salon);
            manyClients3Groups(salon);
            RandomClients(salon);
        }
    }
}
