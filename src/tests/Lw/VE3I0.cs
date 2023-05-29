namespace Application;

public class Pot    // only for honey
{
    private int capacity;
    private int honey;
    private readonly object _lock = new object();

    public Pot(int capacity)
    {
        this.capacity = capacity;
    }

    public int Capacity
    {
        get => capacity;
    }
    
    public int Honey
    {
        get => honey;
    }

    public bool AddHoney()
    {
        var spin = new SpinWait();
        bool added = false;
        bool isFull = false;
        while (!added)
        {
            lock (_lock)
            {
                if (honey != capacity)
                {
                    honey++;
                    added = true;
                    Console.WriteLine($"Honey added, {honey}/{capacity}");
                }
                isFull = honey == capacity;
            }
            spin.SpinOnce();
        }

        return isFull;
    }

    public void Clear()
    {
        lock (_lock)
        {
            if (honey != capacity)
            {
                throw new Exception("Clear: pot if not full yet");
            }
            Console.WriteLine("Pot cleared");
            honey = 0;
        }
    }
}