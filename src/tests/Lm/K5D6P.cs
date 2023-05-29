using System.Diagnostics;
using Task3;

var list = new MyLinkedList<int>();

Debug.Assert(list.Count == 0);
Debug.Assert(list.Remove(0) == false);

list.AddLast(1);

Debug.Assert(list.Count == 1);
Debug.Assert(list.Remove(0) == false);
Debug.Assert(list.Count == 1);
Debug.Assert(list.Remove(1) == true);
Debug.Assert(list.Count == 0);

list.AddLast(1);
list.AddLast(2);
list.AddLast(3);
list.AddLast(2);

Debug.Assert(list.Count == 4);
Debug.Assert(list.Remove(2));
Debug.Assert(list.Count == 3);

var curList = new List<int> { 1, 3, 2 };
int i = 0;
foreach (var el in list)
{
    Debug.Assert(curList[i].Equals(el));
    i++;
}

Debug.Assert(i == 3);

Console.WriteLine("All is Okay!");