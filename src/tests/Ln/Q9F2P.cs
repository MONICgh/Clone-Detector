using System.Collections.Generic;
using System.Numerics;

namespace Application
{
    class Task1
    {
        static int residualWater(int[] heightMap)
        {
            var q = new Stack<Tuple<int, int>>();
            int sum = 0, last = 0, i = 0;
            foreach(int h in heightMap)
            {
                for (;;)
                {
                    if (q.Count != 0 && q.Peek().Item1 <= h) {
                        sum += (q.Peek().Item1 - last) * (i - q.Peek().Item2 - 1);
                        last = q.Pop().Item1;
                    }
                    else
                    {
                        if (q.Count != 0)
                        {
                            sum += (h - last) * (i - q.Peek().Item2 - 1);
                        }
                        q.Push(new Tuple<int, int>(h, i));
                        last = q.Peek().Item1;
                        break;
                    }
                }
                i++;
            }
            return sum;
        }

        static int Main()
        {
            var heightMap = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            Console.WriteLine("residualWater([{0}]) => {1}", string.Join(",", heightMap), residualWater(heightMap));
            heightMap = new int[] { 4, 2, 0, 3, 2, 5 };
            Console.WriteLine("residualWater([{0}]) => {1}", string.Join(",", heightMap), residualWater(heightMap));
            return 0;
        }
    }
}
