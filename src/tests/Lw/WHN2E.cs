namespace task1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Honey pot size: ");
            int potSize = int.Parse(Console.ReadLine());
            Console.Write("Bees number: ");
            int beesNumber = int.Parse(Console.ReadLine());

            HoneyPot pot = new HoneyPot(potSize);
            Bear bear = new Bear();

            for (var i = 0; i < beesNumber; ++i)
            {
                int beeIndex = i;
                Bee bee = new Bee();
                Task.Run(() => bee.Work(beeIndex, ref pot));
            }

            Task.Run(() => bear.Work(ref pot)).Wait();
        }
        /*Honey pot size: 3
          Bees number: 5
          Bee 3: 1
          Bee 2: 2
          Bee 2: 3
          Bear: 0
          Bee 4: 1
          Bee 0: 2
          Bee 3: 3
          Bear: 0
          ...
         */
    }
}

