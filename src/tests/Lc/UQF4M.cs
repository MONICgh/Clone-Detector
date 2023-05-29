namespace task3
{
    class Program
    {
        static void PrintFoo()
        {
            Console.Write("foo");
        }
        static void PrintBar()
        {
            Console.Write("bar");
        }
        public static void Main(string[] args)
        {
            Console.Write("Number of foobar calls: ");
            var n = int.Parse(Console.ReadLine());

            var foobar = new FooBar(n);
            Task fooTask = new Task(() => foobar.Foo(PrintFoo));
            Task barTask = new Task(() => foobar.Bar(PrintBar));

            fooTask.Start();
            barTask.Start();
            fooTask.Wait();
            barTask.Wait();

            /* Number of foobar calls: 1
             * foobar
             * Number of foobar calls: 3
             * foobarfoobarfoobar
             */

        }
    }
}
