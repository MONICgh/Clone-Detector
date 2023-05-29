namespace Application
{
    class Task2
    {
        private static Random rnd = new Random();
        
        private static Tuple<int, int> genPos(int width, int height)
        {
            int x = rnd.Next(width);
            int y = rnd.Next(height);
            return Tuple.Create(x, y);
        }
        
        private static void live(int width = 5, int height = 5, int ramsCount = 3, int iters = 15)
        {
            var field = new Field(width, height); 
            for (int i = 0; i < ramsCount; i++)
            {
                new Ram(field, genPos(width, height));
            }
            new Wolf(field, genPos(width, height));
            
            Thread.Sleep(500);
            for (int i = 0; i < iters; i++)
            {
                Console.WriteLine(field.Show());
                Console.WriteLine();
                Thread.Sleep(1000);
            }
        }
        
        static void Main()
        {
            live();
        }
    }
}
