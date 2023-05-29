namespace task2
{
    class Foo
    {
        private static Semaphore semaphore1 = new Semaphore(1, 1);
        private static Semaphore semaphore2 = new Semaphore(0, 1);
        private static Semaphore semaphore3 = new Semaphore(0, 1);

        public void first()
        {
            semaphore1.WaitOne();
            Console.Write("first");
            semaphore2.Release();
        }

        public void second()
        {
            semaphore2.WaitOne();
            Console.Write("second");
            semaphore3.Release();
        }

        public void third()
        {
            semaphore3.WaitOne();
            Console.Write("third");
            semaphore1.Release();
        }
    }
}
