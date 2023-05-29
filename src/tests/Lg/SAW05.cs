namespace Application
{
    class Task4
    {
        private static Random rnd = new Random();
        private static int i = 0;
        private static int j = 0;
        private static readonly object obj = new object();

        private static float Product(List<List<float>> A, List<List<float>> B, int ii, int jj)
        {
            Thread.Sleep(rnd.Next(1000));
            float sum = 0;
            
            for (int k = 0; k < A.First().Count; k++)
            {
                sum += A[ii][k] * B[k][jj];
            }
            return sum;
        }
        
        private static void Product(List<List<float>> A, List<List<float>> B, List<List<float>> C)
        {
            int k = B.First().Count;
            int m = C.Count;
            int curI, curJ;

            while (true)
            {
                lock (obj)
                {
                    curI = i;
                    curJ = j;
                    if (j + 1 == k)
                    {
                        i++;
                        j = 0;
                    }
                    else if (curI != m)
                    {
                        j++;
                    }
                }

                if (curI == m)
                {
                    break;
                }
                
                C[curI][curJ] = Product(A, B, curI, curJ);
            }
        }
        
        static void Main()
        {
            int nThreads = 8;

            var A = new List<List<float>>()
            {
                new List<float>() { 1, 2, 3, 4, 5 },
                new List<float>() { 6, 7, 8, 9, 10 },
                new List<float>() { 11, 12, 13, 14, 15 },
                new List<float>() { 16, 17, 18, 19, 20 },
            };
            
            var B = new List<List<float>>()
            {
                new List<float>() { 1, 2, 3 },
                new List<float>() { 4, 5, 6 },
                new List<float>() { 7, 8, 9 },
                new List<float>() { 10, 11, 12 },
                new List<float>() { 13, 14, 15 },
            };
            
            var C = new List<List<float>>()
            {
                new List<float>() {0, 0, 0},
                new List<float>() {0, 0, 0},
                new List<float>() {0, 0, 0},
                new List<float>() {0, 0, 0},
            };
            
            var threads = new List<Thread>();
            for (int i = 0; i < nThreads; i++)
            {
                threads.Add(new Thread(() => Product(A, B, C)));
            }
            
            foreach (var thread in threads)
            {
                thread.Start();
            }
            
            foreach (var thread in threads)
            {
                thread.Join();
            }

            foreach (var line in C)
            {
                Console.WriteLine(String.Join(" ", line));
            }

            Console.WriteLine();
        }
    }
}
