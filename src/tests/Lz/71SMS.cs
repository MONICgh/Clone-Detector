using System.Collections.Generic;
using System.Linq;

namespace PseudoStack;

public class PseudoStack<T>
{
    private int maxStackSize;
    private LinkedList<Stack<T>> stackList = new();

    public PseudoStack(int maxStackSize)
    {
        this.maxStackSize = maxStackSize;
    }

    public void Push(T value)
    {
        if (stackList.Count == 0 || stackList.Last().Count >= maxStackSize)
        {
            stackList.AddLast(new Stack<T>());
        }
        stackList.Last().Push(value);
    }

    public T Pop()
    {
        var element = stackList.Last().Pop();
        if (stackList.Last().Count == 0)
        {
            stackList.RemoveLast();
        }

        return element;
    }

    public int StackCount()
    {
        return stackList.Count;
    }
}