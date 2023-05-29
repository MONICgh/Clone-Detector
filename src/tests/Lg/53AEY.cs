namespace ZeroEvenOdd
{
    public class ZeroEvenOdd
    {
        private int n;
        private object print;
        private int writtenNumbers;

        public ZeroEvenOdd(int _n)
        {
            n = _n;
            print = new object();
            writtenNumbers = 0;
        }

        // printNumber(x) outputs "x", where x is an integer.
        public void Zero(Action<int> printNumber)
        {
            lock(print)
            {
                if (writtenNumbers < 2 * n && writtenNumbers % 2 == 0)
                {
                    printNumber(0);
                    writtenNumbers++;
                }
            }
        }
        public void Even(Action<int> printNumber)
        {
            lock(print)
            {
                if (writtenNumbers < 2 * n && writtenNumbers % 4 == 3)
                {
                    printNumber((writtenNumbers + 1) / 2);
                    writtenNumbers++;
                }
            }
        }
        public void Odd(Action<int> printNumber)
        {
            lock(print)
            {
                if (writtenNumbers < 2 * n && writtenNumbers % 4 == 1)
                {
                    printNumber((writtenNumbers + 1) / 2);
                    writtenNumbers++;
                }
            }
        }

        public bool Finish()
        {
            lock(print)
            {
                return writtenNumbers == 2 * n;
            }
        }
    }
}