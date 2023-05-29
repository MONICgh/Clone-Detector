using System.Collections.Concurrent;

List<string> TimeSort(List<string> items)
{
    var timeForChar = 100 / items.Sum(it => it.Length);
    var queue = new BlockingCollection<string>();
    var threads = items.Select(it =>
    {
        return new Thread(() =>
        {
            Thread.Sleep(10*it.Length);
            // Для 3a:
            // Console.WriteLine(it);
            // Для 3б
            queue.Add(it);
        });
    }).ToList();
    threads.ForEach(it => it.Start());
    threads.ForEach(it => it.Join());
    return queue.ToList();
}

var items = new List<string>
{
    "ArchLinux",
    "Debian",
    "Ubuntu",
    "Mint",
    "CentOS",
    "Fedora",
    "PopOS",
    "AstraLinux",
    "Trinity",
};

var sortedItems = TimeSort(items);

// Для 3б
Console.WriteLine(string.Join(" ", sortedItems));
