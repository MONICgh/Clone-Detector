namespace ZeroEvenOdd
{
    public class Program
    {
        public static void Main()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            ZeroEvenOdd zeo = new(n);

            Action<int> print = (x) => Console.Write(x);

            Thread Zero = new(() =>
            {
                while (!zeo.Finish())
                {
                    Thread.Sleep(1000);
                    zeo.Zero(print);
                }
            });

            Thread Even = new(() =>
            {
                while (!zeo.Finish())
                {
                    Thread.Sleep(2000);
                    zeo.Even(print);
                }
            });

            Thread Odd = new(() =>
            {
                while (!zeo.Finish())
                {
                    Thread.Sleep(3000);
                    zeo.Odd(print);
                }
            });

            Zero.Start();
            Even.Start();
            Odd.Start();

            Zero.Join();
            Even.Join();
            Odd.Join();
        }
    }
}
