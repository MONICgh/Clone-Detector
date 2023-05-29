namespace HashTable;

public class HashTable<T>
{
    private int Size { get; set; }
    private int CurrentCount { get; set; }
    private LinkedList<T>[] Data { get; set; }

    public HashTable(int size = 8)
    {
        Size = size;
        CurrentCount = 0;
        Data = new LinkedList<T>[size];
    }

    private int CalcHashCode(T element)
    {
        return element != null ? element.GetHashCode() % Size : 0;
    }

    public void Add(T newElement)
    {
        if (Contains(newElement)) return;
        
        if (CurrentCount > Size)
        {
            Rebuild();
        }

        var hashCode = CalcHashCode(newElement);
        if (Data[hashCode] == null)
        {
            Data[hashCode] = new LinkedList<T>();
        }
        Data[hashCode].AddLast(newElement);
        CurrentCount++;
    }

    public void Delete(T deleteElement)
    {
        if (!Contains(deleteElement)) return;
        var hashCode = CalcHashCode(deleteElement);
        Data[hashCode].Remove(deleteElement);
        CurrentCount--;
    }

    public bool Contains(T containsElement)
    {
        var hashCode = CalcHashCode(containsElement);
        return Data[hashCode] != null && Data[hashCode].Contains(containsElement);
    }

    private List<T> Elements()
    {
        var elements = new List<T>();
        foreach (var hashElements in Data)
        {
            if (hashElements == null) continue;
            foreach (var element in hashElements)
            {
                elements.Add(element);
            }
        }

        return elements;
    }

    private void Rebuild()
    {
        var elements = Elements();
        Size *= 2;
        CurrentCount = 0;
        Data = new LinkedList<T>[Size];
        foreach (var element in elements)
        {
            Add(element);
        }
    }
}
