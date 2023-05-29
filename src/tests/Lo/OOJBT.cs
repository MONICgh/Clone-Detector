namespace OneTwoThree
{
    public class Program
    {
        public static void Main()
        {
            Foo foo = new();
            Barrier barrier12 = new(2);
            Barrier barrier23 = new(2);
            Thread A = new(() =>
            {
                foo.first();
                barrier12.SignalAndWait();
            });
            Thread B = new(() =>
            {
                barrier12.SignalAndWait();
                foo.second();
                barrier23.SignalAndWait();
            });
            Thread C = new(() =>
            {
                barrier23.SignalAndWait();
                foo.third();
            });

            C.Start();
            Thread.Sleep(500);
            B.Start();
            A.Start();

            C.Join();
            B.Join();
            A.Join();
        }
    }
}