using System.Diagnostics;
using Task5;

var array3d = new BigRangeArray<int>();

var values = new List<int> { 210, 1070 };
    
array3d[0, 1, 2] = values[0];
array3d[0, 7, 10] = values[1];


int i = 0;
foreach (var el in array3d)
{
    Debug.Assert(el.Equals(values[i]));
    i++;
} 

Debug.Assert(i == 2);

var array2d = new BigRangeArray<int>();

array2d[0, 1] = values[0];
array2d[0, 7] = values[1];


i = 0;
foreach (var el in array2d)
{
    Debug.Assert(el.Equals(values[i]));
    i++;
} 

Debug.Assert(i == 2);

Console.WriteLine("All is Okay!");
