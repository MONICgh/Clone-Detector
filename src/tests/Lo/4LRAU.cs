namespace HW_14;

public class Sorter
{
    void runSorter(List<String> str)
    {
        var dict = new Dictionary<int, List<string>>();
        foreach (var s in str)
        {
            var list = dict.GetValueOrDefault(s.Length, new List<string>());
            list.Add(s);
            dict[s.Length] = list;
        }
        var answer = new List<string>();
        foreach (var keyValuePair in dict)
        {
            foreach (var s in keyValuePair.Value)
            {
                answer.Add(s);
            }
        }
        var threads = answer.Select(s => new Thread(() =>
        {
            Console.WriteLine(s);
            Thread.Sleep(100 * s.Length);
        })).ToList();
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
