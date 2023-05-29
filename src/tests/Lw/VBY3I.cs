namespace Application
{
    class Task1
    {
        private static void live(int potCapacity = 10, int beesCount = 15)
        {
            Pot pot = new Pot(potCapacity);
            Bear bear = new Bear(pot);
            var bees = new List<Bee>();
            for (int i = 0; i < beesCount; i++)
            {
                var bee = new Bee(pot, i, bear);
                bees.Add(bee);
                bee.Work();
            }
        }
        
        static void Main()
        {
            live();
            Thread.Sleep(5_000);
        }
    }
}
