using MyLinkedList;

void printLinkedList(MyLinkedList<int> list)
{
    Console.WriteLine("Size: " + list.Count);
    Console.WriteLine(string.Join(", ", list));
}

var myLinkedList = new MyLinkedList<int>();
printLinkedList(myLinkedList);

myLinkedList.Add(1);
printLinkedList(myLinkedList);

myLinkedList.Add(2);
myLinkedList.Add(3);
myLinkedList.Add(4);
myLinkedList.Add(3);
myLinkedList.Add(3);
myLinkedList.Add(1);
printLinkedList(myLinkedList);

myLinkedList.Remove(3);
printLinkedList(myLinkedList);
myLinkedList.Remove(3);
printLinkedList(myLinkedList);
myLinkedList.Remove(1);
printLinkedList(myLinkedList);
myLinkedList.Remove(1);
printLinkedList(myLinkedList);