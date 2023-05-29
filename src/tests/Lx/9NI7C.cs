namespace Task3;

public class StackWithMinValue
{
    private Stack<int> values = new Stack<int>();
    private Stack<int> mins = new Stack<int>();
    
    public int Peek()
    {
        return values.Peek();
    }

    public int Pop()
    {
        if (values.Peek() == mins.Peek())
        {
            mins.Pop();
        }
        return values.Pop();
    }

    public void Push(int el)
    {
        if (mins.Count == 0 || el <= mins.Peek())
        {
            mins.Push(el);
        }
        values.Push(el);
    }

    public int MinValue()
    {
        return mins.Peek();
    }
}