namespace task1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Sequence length: ");
            var n = int.Parse(Console.ReadLine());
            var zeroEvenOddInstance = new ZeroEvenOdd(n);

            var zeroThread = new Thread(() => zeroEvenOddInstance.Zero((i) => Console.Write($"{i}")));
            var evenThread = new Thread(() => zeroEvenOddInstance.Even((i) => Console.Write($"{i}")));
            var oddThread = new Thread(() => zeroEvenOddInstance.Odd((i) => Console.Write($"{i}")));

            zeroThread.Start();   
            evenThread.Start();
            oddThread.Start();

            zeroThread.Join();
            evenThread.Join();
            oddThread.Join();
        }
        /*
         * Sequence length: 2
           0102

           Sequence length: 5
           0102030405
         */
    }
}
