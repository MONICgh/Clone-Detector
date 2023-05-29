using System.Diagnostics;
using Task6;

Debug.Assert(StringyFib.Apply(1).Equals("invalid"));
Debug.Assert(StringyFib.Apply(3).Equals("b, a, ab"));
Debug.Assert(StringyFib.Apply(7).Equals("b, a, ab, aba, abaab, abaababa, abaababaabaab"));

Console.WriteLine("All is Okay!");