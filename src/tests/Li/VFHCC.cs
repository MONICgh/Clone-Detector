using System.Runtime.ExceptionServices;

namespace ExceptionDispatch
{
    public class Program
    {
        public static void Panic()
        {
            throw new NotImplementedException("From panic");
        }

        public static void Main()
        {
            ExceptionDispatchInfo dispatchInfo = null;
            Exception first = null;
            try
            {
                try
                {
                    Panic();
                }
                catch (Exception exc)
                {
                    dispatchInfo = ExceptionDispatchInfo.Capture(exc);
                    first = exc;
                    throw exc;
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc == first);
                Console.WriteLine("---------------------");
                Console.WriteLine(exc.StackTrace);
                Console.WriteLine("---------------------");
            }

            try
            {
                dispatchInfo.Throw();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.StackTrace);
            }
        }
    }
}