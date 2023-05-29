namespace Program
{
    public class Program
    {
        public static void PrintA(ref bool firstTurn, object myLock)
        {
            for (int i = 1; i <= 10; i++)
            {
                while (true)
                {
                    lock (myLock)
                    {
                        if (!firstTurn)
                        {
                            continue;
                        }
                        Console.WriteLine("First thread prints: {0}", i);
                        firstTurn = false;
                        break;
                    }
                }
            }
        }

        public static void PrintB(ref bool firstTurn, object myLock)
        {
            for (int i = 1; i <= 10; i++)
            {
                while (true)
                {
                    lock (myLock)
                    {
                        if (firstTurn)
                        {
                            continue;
                        }
                        Console.WriteLine("Second thread prints: {0}", i);
                        firstTurn = true;
                        break;
                    }
                }
            }
        }

        public static void Main()
        {
            bool firstTurn = true;
            object myLock = new();
            Thread threadA = new(() => PrintA(ref firstTurn, myLock));
            Thread threadB = new(() => PrintB(ref firstTurn, myLock));
            threadA.Start();
            threadB.Start();

            threadA.Join();
            threadB.Join();
        }
    }
}