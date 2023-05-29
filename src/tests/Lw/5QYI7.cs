using System.Collections.Concurrent;

void SortRange(ref int[] array, int index, int len)
{   
    Thread.Sleep(new Random().Next(250, 750));
    Array.Sort(array, index, len);
    Console.WriteLine($"Sorted [{index}; {index + len - 1}]");
}

List<int> Merge(List<int> left, List<int> right)
{
    var res = new List<int>();
    var (i, j) = (0, 0);
    var (n, m) = (left.Count, right.Count);
    while (i < n || j < m)
    {
        if (j == m || (i < n && left[i] <= right[j]))
        {
            res.Add(left[i++]);
        }
        else
        {
            res.Add(right[j++]);
        }
    }
    
    Console.WriteLine("Merged!");

    return res;
}

int[] MergeSortWaitForAll(int[] array, int numberOfThreads)
{
    var n = array.Length;
    var q = n / numberOfThreads;
    var r = n % numberOfThreads;
    var ranges = new List<(int, int)>();
    var tasks = new List<Task>();
    for (var (i, cur) = (0, 0); i < numberOfThreads; ++i)
    {
        var (index, len) = (cur, q);
        if (i < r) ++len;
        var task = Task.Run(() => SortRange(ref array, index, len));
        tasks.Add(task);
        ranges.Add((index, len));
        cur += len;
    }

    Task.WaitAll(tasks.ToArray());
    var segments = new List<List<int>>();
    var list = array.ToList();
    foreach (var (index, len) in ranges)
    {
        segments.Add(list.GetRange(index, len));
    }
    while (segments.Count > 1)
    {
        var newSegments = new List<List<int>>();
        for (var i = 0; i < segments.Count; i += 2)
        {
            newSegments.Add(i + 1 < segments.Count ? Merge(segments[i], segments[i + 1]) : segments[i]);
        }

        segments = newSegments;
    }

    return segments[0].ToArray();
}

int[] MergeSortNoWait(int[] array, int numberOfThreads)
{
    var n = array.Length;
    var q = n / numberOfThreads;
    var r = n % numberOfThreads;
    var finished = new ConcurrentQueue<(int, int)>();
    var tasks = new List<Task>();
    for (var (i, cur) = (0, 0); i < numberOfThreads; ++i)
    {
        var (index, len) = (cur, q);
        if (i < r) ++len;
        var task = Task.Run(() => SortRange(ref array, index, len));
        task.ContinueWith(_ =>
        {
            finished.Enqueue((index, len));
        });
        tasks.Add(task);
        cur += len;
    }

    var res = new List<int>();
    while (res.Count < n)
    {
        while (finished.IsEmpty) {}

        if (!finished.TryDequeue(out var cur)) continue;
        var list = new List<int>();
        for (var i = 0; i < cur.Item2; ++i)
        {
            list.Add(array[cur.Item1 + i]);
        }

        res = Merge(res, list);
    }
    Task.WaitAll(tasks.ToArray());
    return res.ToArray();
}

var array = new int[] {5, 4, 3, 2, 1};
var sorted = MergeSortWaitForAll(array, 2);
Console.WriteLine(string.Join(' ', sorted));

sorted = MergeSortNoWait(array, 2);
Console.WriteLine(string.Join(' ', sorted));

var bigList = new List<int>();
for (var it = 0; it < 1000; ++it)
{
    bigList.Add(new Random().Next(1000));
}

array = bigList.ToArray();
sorted = MergeSortWaitForAll(array, 12);
Console.WriteLine(string.Join(' ', sorted));

sorted = MergeSortNoWait(array, 50);
Console.WriteLine(string.Join(' ', sorted));