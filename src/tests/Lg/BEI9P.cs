namespace task1
{
    public class ZeroEvenOdd
    {
        private int n;

        private readonly System.Threading.Semaphore zeroSemaphore = new System.Threading.Semaphore(1, 1);
        private readonly System.Threading.Semaphore evenSemaphore = new System.Threading.Semaphore(0, 1);
        private readonly System.Threading.Semaphore oddSemaphore = new System.Threading.Semaphore(0, 1);

        public ZeroEvenOdd(int n)
        {
            this.n = n;
        }

        public void Zero(Action<int> printNumber)
        {
            for (int i = 1; i <= this.n; i++)
            {
                zeroSemaphore.WaitOne();
                printNumber(0);

                if (i % 2 == 0)
                    evenSemaphore.Release();
                else
                    oddSemaphore.Release();
            }
        }

        public void Even(Action<int> printNumber)
        {
            for (int i = 2; i <= this.n; i += 2)
            {
                evenSemaphore.WaitOne();
                printNumber(i);
                zeroSemaphore.Release();
            }
        }

        public void Odd(Action<int> printNumber)
        {
            for (int i = 1; i <= this.n; i += 2)
            {
                oddSemaphore.WaitOne();
                printNumber(i);
                zeroSemaphore.Release();
            }
        }
    }
}
