using System.Diagnostics;
using Task3;

Debug.Assert(SunLoungers.Apply("10001") == 1);
Debug.Assert(SunLoungers.Apply("00101") == 1);
Debug.Assert(SunLoungers.Apply("0") == 1);
Debug.Assert(SunLoungers.Apply("000") == 2);

Console.WriteLine("All is Okay!");