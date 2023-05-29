// Test:

using System.Diagnostics;
using Task3;

var stack = new StackWithMinValue();
stack.Push(10);
stack.Push(7);
stack.Push(14);
Debug.Assert(stack.MinValue() == 7);
stack.Pop();
Debug.Assert(stack.MinValue() == 7);
stack.Pop();
Debug.Assert(stack.MinValue() == 10);
stack.Push(4);
Debug.Assert(stack.MinValue() == 4);
Console.WriteLine("All is OK!");
