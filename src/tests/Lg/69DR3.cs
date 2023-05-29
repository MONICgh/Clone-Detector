namespace Application
{
    class Task1
    {
        static void printNumber(int x)
        {
            Console.Write(x);
        }
        
        static void Main()
        {
            var zeroEvenOdd = new ZeroEvenOdd(7);
            var threads = new List<Thread>();
            
            threads.Add(new Thread(() => zeroEvenOdd.Zero(x => printNumber(x))));
            threads.Add(new Thread(() => zeroEvenOdd.Even(x => printNumber(x))));
            threads.Add(new Thread(() => zeroEvenOdd.Odd(x => printNumber(x))));
            
            foreach (var thread in threads)
            {
                thread.Start();
            }
            
            foreach (var thread in threads)
            {
                thread.Join();
            }

            zeroEvenOdd.reset();
        }
    }
}
