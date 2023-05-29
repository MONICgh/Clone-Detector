using System.Diagnostics;
using Task4;

Debug.Assert(ExpressFactors.Apply(2) == "2");
Debug.Assert(ExpressFactors.Apply(4) == "2^2");
Debug.Assert(ExpressFactors.Apply(10) == "2 x 5");
Debug.Assert(ExpressFactors.Apply(60) == "2^2 x 3 x 5");

Console.WriteLine("All is Okay!");