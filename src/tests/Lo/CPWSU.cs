namespace Task3;

public static class SortToConsole
{
    public static void Apply(List<string> strings)
    {
        var threads = new List<Thread>();
        foreach (var s in strings)
        {
            threads.Add(new Thread(() =>
            {
                Thread.Sleep(64 * s.Length);
                Console.WriteLine(s);
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
    }
}