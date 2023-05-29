namespace Program
{
    public class Program
    {
        public static void FuncA(Mutex A, Mutex B)
        {
            A.WaitOne();
            Thread.Sleep(100);
            B.WaitOne();
            B.ReleaseMutex();
            A.ReleaseMutex();
        }

        public static void FuncB(Mutex A, Mutex B)
        {
            B.WaitOne();
            Thread.Sleep(100);
            A.WaitOne();
            A.ReleaseMutex();
            B.ReleaseMutex();
        }

        public static void Main()
        {
            Mutex A = new();
            Mutex B = new();
            Thread threadA = new(() => FuncA(A, B));
            Thread threadB = new(() => FuncB(A, B));
            threadA.Start();
            threadB.Start();

            threadA.Join();
            threadB.Join();
        }
    }
}