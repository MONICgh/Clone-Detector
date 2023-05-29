using System.Diagnostics;
using Task5;

Debug.Assert(Rational.Apply(2, 5) == "0.4");
Debug.Assert(Rational.Apply(1, 6) == "0.1(6)");
Debug.Assert(Rational.Apply(1, 3) == "0.(3)");
Debug.Assert(Rational.Apply(1, 7) == "0.(142857)");
Debug.Assert(Rational.Apply(1, 77) == "0.(012987)");

Console.WriteLine("All is Okay!");