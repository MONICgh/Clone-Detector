using System.Runtime.ExceptionServices;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers1 = { 0, 1, 2 };
            int[] numbers2 = { 3, 4, 5 };
            int sum = 0;

            ExceptionDispatchInfo exceptionHandler = null;

            try
            {
                for (int i = 0; i < numbers1.Length; i++)
                {
                    sum += sum / numbers1[i];

                }
                Console.WriteLine("Loop 1 successfully finished");
            }
            catch (Exception e)
            {
                exceptionHandler = ExceptionDispatchInfo.Capture(e);
                Console.WriteLine($"Caught an exception: {e.Message.ToLower()} Stack trace: {e.StackTrace.Length}");
            }

            try
            {
                exceptionHandler?.Throw();
            }

            catch (Exception e)
            {
                Console.WriteLine($"Warning. There was an exception in the loop 1: {e.Message.ToLower()} Stack trace: {e.StackTrace.Length}");
            }

            try
            {
                for (int i = 0; i < numbers2.Length; i++)
                {
                    sum += sum / numbers2[i];

                }
                Console.WriteLine("Loop 2 successfully finished");
            }
            catch (Exception e)
            {
                exceptionHandler = ExceptionDispatchInfo.Capture(e);
                Console.WriteLine($"Caught an exception: {e.Message.ToLower()} Stack trace: {e.StackTrace.Length}");
            }

        }
        /*
         Caught an exception: attempted to divide by zero. Stack trace: 100
         Warning. There was an exception in the loop 1: attempted to divide by zero. Stack trace: 253
         Loop 2 successfully finished*/
    }
}
