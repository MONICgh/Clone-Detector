using System.Runtime.ExceptionServices;

int div(int a, int b)
{
    return a / b;
}

ExceptionDispatchInfo exceptionDispatchInfo = null;

try
{
    Console.WriteLine("Before exception");
    int c = div(0, 0);
}
catch (ArithmeticException exception)
{
    exceptionDispatchInfo = ExceptionDispatchInfo.Capture(exception);
    Console.WriteLine("Exception captured");
}

try
{
    exceptionDispatchInfo?.Throw();
}
catch (ArithmeticException exception)
{
    Console.WriteLine("Exception reThrown");
}


exceptionDispatchInfo = null;

try
{
    Console.WriteLine("Division without exception");
    int c = div(1, 1);
}
catch (ArithmeticException exception)
{
    exceptionDispatchInfo = ExceptionDispatchInfo.Capture(exception);
    Console.WriteLine("Exception captured");
}

try
{
    exceptionDispatchInfo?.Throw();
    Console.WriteLine("Exception not rethrown because wasn't captured");
}
catch (ArithmeticException exception)
{
    Console.WriteLine("Exception rethrown");
}