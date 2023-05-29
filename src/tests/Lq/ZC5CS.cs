namespace Task1;

public class ComponentFactory<T>
{
    private Queue<T> _ready = new Queue<T>();
    
    public virtual void MakeNew(T newT) {
        _ready.Enqueue(newT);
    }

    public T Take()
    {
        return _ready.Dequeue();
    }

    public bool HaveAny()
    {
        return _ready.Count > 0;
    }
}