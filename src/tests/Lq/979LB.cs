using System.Diagnostics;
using Task4;

var mailPlaces = new MailPlaces();

Debug.Assert(mailPlaces.Apply(new List<int> {1, 4, 8, 10, 20}, 3) == 5);
Debug.Assert(mailPlaces.Apply(new List<int> {2, 3, 5, 12, 18}, 2) == 9);
Debug.Assert(mailPlaces.Apply(new List<int> {7, 4, 6, 1}, 1) == 8);
Debug.Assert(mailPlaces.Apply(new List<int> {3, 6, 14, 10}, 4) == 0);
Console.WriteLine("All is Okay!");