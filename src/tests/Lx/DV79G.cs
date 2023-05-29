namespace MinValueStack;

public class MinValueStack<T> where T: IComparable<T>
{
    private Stack<T> Stack;
    private Stack<T> SubMin; // prefix function value: SubMin[i] = Min(Stack.Take(i))

    public MinValueStack()
    {
        Stack  = new Stack<T>(0);
        SubMin = new Stack<T>(0);
    }

    public void Push(T element)
    {
        Stack.Push(element);
        if (SubMin.Count > 0)
        {
            SubMin.Push(element.CompareTo(SubMin.Peek()) <= 0 ? element : SubMin.Peek());
        }
        else
        {
            SubMin.Push(element);
        }
    }

    public T Peek()
    {
        return Stack.Peek();
    }

    public T Pop()
    {
        SubMin.Pop();
        return Stack.Pop();
    }

    public T MinValue()
    {
        return SubMin.Peek();
    }
}