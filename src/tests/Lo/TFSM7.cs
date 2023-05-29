namespace HW_14;

public class OrderedWriter
{
    string data = "";

    private void PrintA()
    {
        lock (data)
        {
            data += "first";
            Monitor.PulseAll(data);
        }
    }

    private void PrintB()
    {
        while (true)
        {
            lock (data)
            {
                if (data != "first")
                    Monitor.Wait(data);
                if (data != "first")
                    continue;
                data += "second";
                Monitor.PulseAll(data);
                return;

            }
        }
    }

    private void PrintC()
    {
        while (true)
        {
            lock (data)
            {
                if (data != "firstsecond")
                    Monitor.Wait(data);
                if (data != "firstsecond")
                    continue;
                data += "third";
                return;

            }
        }
    }

    public string getResult(List<int> order)
    {
        var threads = new List<Thread>
        {
            new(PrintA),
            new(PrintB),
            new(PrintC)
        };
        for (var i = 0; i < order.Count; i++)
        {
            threads[i].Start();
        }
        foreach (var t in threads)
        {
            t.Join();
        }
        return data;
    }
}
