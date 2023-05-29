namespace FooBar
{
    public class Program
    {
        public static void Main()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            FooBar foobar = new(n);

            Barrier barrier = new(2);
            Thread threadA = new(() => foobar.Foo(() =>
            {
                Console.Write("foo");
                barrier.SignalAndWait();
                barrier.SignalAndWait();
            }));
            Thread threadB = new(() => foobar.Bar(() =>
            {
                barrier.SignalAndWait();
                Console.Write("bar");
                barrier.SignalAndWait();
            }));

            threadA.Start();
            threadB.Start();

            threadA.Join();
            threadB.Join();
        }
    }
}