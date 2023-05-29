
namespace task3
{
    class FooBar
    {
        private static Semaphore foo = new Semaphore(1, 1);
        private static Semaphore bar = new Semaphore(0, 1);

        private int n;
        public FooBar(int n)
        {
            this.n = n;
        }

        public void Foo(Action printFoo)
        {

            for (int i = 0; i < n; i++)
            {

                foo.WaitOne();

                printFoo();

                bar.Release();
            }
        }

        public void Bar(Action printBar)
        {

            for (int i = 0; i < n; i++)
            {
                bar.WaitOne();

                printBar();

                foo.Release();
            }
        }
    }
}
