using System.Diagnostics;
using Task3;

var el = new Child();
Debug.Assert(el.Plus1(10) == 11);
Debug.Assert(el.PlusBonus(20) == 40);
var elParent = new Parent();
Debug.Assert(elParent.Plus1(10) == 11);
Debug.Assert(elParent.PlusBonus(20) == 30);

Console.WriteLine("All is OK!");