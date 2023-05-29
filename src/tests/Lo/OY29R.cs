namespace Task3;

public static class SortToList
{
    public static List<string> Apply(List<string> strings)
    {
        var threads = new List<Thread>();
        var ans = new List<string>();
        var locker = new object();
        
        foreach (var s in strings)
        {
            threads.Add(new Thread(() =>
            {
                Thread.Sleep(64 * s.Length);
                lock (locker)
                {
                    ans.Add(s);
                }
            }));
        }
        
        foreach (var thread in threads)
        {
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        return ans;
    }
}