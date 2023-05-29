using System.Diagnostics;
using Task1;

var lake1 = new Lake(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 });
var lake2 = new Lake(new List<int> { 13, 23, 1, -8, 4, 9 });
var emptyLake = new Lake(new List<int>());

string ans = "";
foreach (var num in lake1)
{
    ans += num + ",";
}
Debug.Assert(ans == "1,3,5,7,8,6,4,2,");

ans = "";
foreach (var num in lake2)
{
    ans += num + ",";
}
Debug.Assert(ans == "13,1,4,9,-8,23,");

ans = "";
foreach (var num in emptyLake)
{
    ans += num + ",";
}
Debug.Assert(ans == "");


Console.WriteLine("All is Okay!");