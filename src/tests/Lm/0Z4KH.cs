namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var stones = new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8 };
            var lake = new Lake(stones);
            int step = 0;
            foreach (int stone in lake)
            {
                step++;
                if (step != stones.Count)
                {
                    Console.Write(stone + ", ");
                }
                else
                {
                    Console.Write(stone);
                }
            }
            Console.WriteLine(); //1, 3, 5, 7, 8, 6, 4, 2

            stones = new List<int> { 13, 23, 1, -8, 4, 9 };
            lake = new Lake(stones);
            step = 0;
            foreach (int stone in lake)
            {
                step++;
                if (step != stones.Count)
                {
                    Console.Write(stone + ", ");
                }
                else
                {
                    Console.Write(stone);
                }
            }
            Console.WriteLine(); //13, 1, 4, 9, -8, 23
        }
    }
}
