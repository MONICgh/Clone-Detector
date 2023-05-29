using System.Runtime.ExceptionServices;
using System.Security.Cryptography;

int Mod(int a, int b)
{
    return a % b;
}

ExceptionDispatchInfo exception = null;

try
{
    for (var i = 0; i < 5; ++i)
    {
        for (var j = 4; j >= 0; --j)
        {
            Console.WriteLine($"{i} % {j} = {Mod(i, j)}");
        }
    }
}
catch (Exception exc)
{
    exception = ExceptionDispatchInfo.Capture(exc);
    Console.WriteLine($"{exc.Message}");
}

int SmartMod(int a, int b)
{
    if (b == 0) exception?.Throw();
    return a % b;
}

try
{
    for (var i = 0; i < 5; ++i)
    {
        for (var j = 4; j >= 0; --j)
        {
            Console.WriteLine($"{i} % {j} = {SmartMod(i, j)}");
        }
    }
}
catch (Exception exc)
{
    Console.WriteLine($"{exc.Message}");
}