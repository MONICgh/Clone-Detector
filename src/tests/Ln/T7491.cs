using System.Diagnostics;
using Task1;

var hm = new OpenHashMap<String>(100);

Debug.Assert(hm.Contains("A") == false);
hm.Add("A");
Debug.Assert(hm.Contains("A") == true);
hm.Add("B");
Debug.Assert(hm.Contains("A") == true);
Debug.Assert(hm.Contains("B") == true);
hm.Add("A");
Debug.Assert(hm.Contains("A") == true);
Debug.Assert(hm.Contains("B") == true);
hm.Delete("A");
Debug.Assert(hm.Contains("A") == false);
Debug.Assert(hm.Contains("B") == true);
hm.Delete("A");
Debug.Assert(hm.Contains("A") == false);
Debug.Assert(hm.Contains("B") == true);

Console.WriteLine("All is OK!");
