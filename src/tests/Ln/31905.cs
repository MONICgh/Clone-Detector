namespace HashTable;

public class HashTable<TK, TV> where TK: IComparable
{
    private int Size { get; set; }
    private int CurrentCount { get; set; }
    private Tuple<TK, TV, bool>?[] Data { get; set; }  // <Key, Value, Deleted>

    public HashTable(int size = 8)
    {
        Size = size;
        CurrentCount = 0;
        Data = new Tuple<TK, TV, bool>[size];
    }

    private int CalcHashCode(TK key)
    {
        return key.GetHashCode() % Size;
    }

    private int GetNextIndex(int index)
    {
        return (index + 1) % Size;
    }

    public void Add(TK key, TV value)
    {
        if (CurrentCount >= Size)
        {
            Rebuild();
        }

        var hashCode = CalcHashCode(key);

        var flag = true;
        while (flag)
        {
            // If we found free space or this element was deleted
            if (Data[hashCode] == null || Data[hashCode]!.Item3)
            {
                Data[hashCode] = Tuple.Create(key, value, false);
                CurrentCount++;
                flag = false;
            }
            else
            {
                // If key equals new element key we update old value
                if (Equals(Data[hashCode]!.Item1, key))
                {
                    Data[hashCode] = Tuple.Create(key, value, false);
                    flag = false;
                }
                else
                {
                    // Else go to the next element
                    hashCode = GetNextIndex(hashCode);
                }
            }
        }
    }

    public void Delete(TK key)
    {
        var counter = 0;
        var hashCode = CalcHashCode(key);
        
        while (counter < Size)
        {
            if (Data[hashCode] != null && !Data[hashCode]!.Item3)
            {
                if (Equals(Data[hashCode]!.Item1, key))
                {
                    Data[hashCode] = Tuple.Create(Data[hashCode]!.Item1, Data[hashCode]!.Item2, true);
                    Size--;
                    return;
                }
            }
            hashCode = GetNextIndex(hashCode);
            counter++;
        }
    }

    public bool Contains(TK key)
    {
        var counter = 0;
        var hashCode = CalcHashCode(key);
        
        while (counter < Size)
        {
            if (Data[hashCode] != null && !Data[hashCode]!.Item3)
            {
                if (Equals(Data[hashCode]!.Item1, key))
                {
                    return true;
                }
            }
            hashCode = GetNextIndex(hashCode);
            counter++;
        }

        return false;
    }

    private void Rebuild()
    {
        var elements = Data.Select(tuple => Tuple.Create(tuple.Item1, tuple.Item2)).ToList();
        Size *= 2;
        CurrentCount = 0;
        Data = new Tuple<TK, TV, bool>[Size];
        foreach (var element in elements)
        {
            Add(element.Item1, element.Item2);
        }
    }
}
