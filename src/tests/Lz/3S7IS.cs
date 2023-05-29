using System.Collections;

namespace HW_05.PseudoStack;

public class ListStack<T>
{
    private int _maxStackSize;
    private List<Stack<T>> _data = new();

    public ListStack(int maxStackSize)
    {
        _maxStackSize = maxStackSize;
    }

    public T Pop()
    {
        var value = _data.Last().Pop();
        if (_data.Last().Any())
            _data.RemoveAt(_data.Count - 1);
        return value;
    }

    public bool Empty()
    {
        return StacksCount() == 0;
    }
    public void Push(T value)
    {
        if (!_data.Any() || _data.Last().Count == _maxStackSize)
            _data.Add(new Stack<T>());
        _data.Last().Push(value);
    }

    public int StacksCount()
    {
        return _data.Count;
    }
}
