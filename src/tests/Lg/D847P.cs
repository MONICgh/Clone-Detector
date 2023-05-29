var array = new List<int> { 4, 7, 9, 11, 3, 5, 5, 1, 9, -1, 3 };
var concurrentArray = new ConcurrentArray.ConcurrentArray(array);

var threads = new List<Thread>
{
    new(() => concurrentArray.Avg()),
    new(() => concurrentArray.Min()),
    new(() => concurrentArray.Swap()),
    new(() => concurrentArray.Sort()),
    new(() => concurrentArray.Swap()),
    new(() => concurrentArray.Min()),
};

foreach (var thread in threads)
{
    thread.Start();
}

foreach (var thread in threads)
{
    thread.Join();
}