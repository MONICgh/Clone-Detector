namespace  task4
{
    class Program
    {
        public static int FindMinimumDistance(int[] housePositions, int k)
        {
            Array.Sort(housePositions);
            if (housePositions.Length <= k)
            {
                return 0;
            }
            int minDistance = int.MaxValue;
            if (k==1)
            {
                for(int curPosition = housePositions.First(); curPosition <= housePositions.Last(); curPosition++)
                {
                    int curDistance = housePositions.Sum(housePosition => Math.Abs(housePosition - curPosition));
                    if (curDistance < minDistance)
                    {
                        minDistance = curDistance;  
                    }
                }
            }
            else
            {
                for (int splitPosition = 1; splitPosition <= housePositions.Length - k + 1; splitPosition++)
                {
                    int leftMinDistance = FindMinimumDistance(housePositions.Take(splitPosition).ToArray(), 1);
                    int rightMinDistance = FindMinimumDistance(housePositions.Skip(splitPosition).ToArray(), k-1);
                    int curDistance = leftMinDistance + rightMinDistance;
                    if (curDistance < minDistance)
                    {
                        minDistance = curDistance;
                    }
                }
            }
            
            return minDistance;

            
        }
        public static void Main(string[] args)
        {
          Console.WriteLine(FindMinimumDistance(new int[] { 1, 4, 8, 10, 20 }, 3)); //5
          Console.WriteLine(FindMinimumDistance(new int[] { 2, 3, 5, 12, 18 }, 2)); //9
          Console.WriteLine(FindMinimumDistance(new int[] { 7, 4, 6, 1 }, 1)); //8
          Console.WriteLine(FindMinimumDistance(new int[] {3, 6, 14, 10 }, 4)); //0

        }
    }
}
