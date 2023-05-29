// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Task3;

Debug.Assert(SimplifyUtil.Simplify("4/6") == "2/3");
Debug.Assert(SimplifyUtil.Simplify("10/11") == "10/11");
Debug.Assert(SimplifyUtil.Simplify("100/400") == "1/4");
Debug.Assert(SimplifyUtil.Simplify("8/4") == "2");

Console.WriteLine("All is Ok!");