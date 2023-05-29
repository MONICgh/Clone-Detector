using System.Diagnostics;
using Task3;

var racing = new Racing();

Debug.Assert(racing.GoToGoal(3) == "AA");
Debug.Assert(racing.GoToGoal(6).Length == 5);
Console.WriteLine("All is Okay!");