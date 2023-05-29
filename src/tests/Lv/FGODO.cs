using System.Diagnostics;
using Task6;

Debug.Assert(MaxiMinni.Apply(12340)[0] == 42310);
Debug.Assert(MaxiMinni.Apply(12340)[1] == 10342);

Debug.Assert(MaxiMinni.Apply(98761)[0] == 98761);
Debug.Assert(MaxiMinni.Apply(98761)[1] == 18769);

Debug.Assert(MaxiMinni.Apply(9000)[0] == 9000);
Debug.Assert(MaxiMinni.Apply(9000)[1] == 9000);

Debug.Assert(MaxiMinni.Apply(11321)[0] == 31121);
Debug.Assert(MaxiMinni.Apply(11321)[1] == 11123);

Console.WriteLine("All is Okay");