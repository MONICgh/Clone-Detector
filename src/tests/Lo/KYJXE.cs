var sortedList = new List<string>();
var mutex = new Mutex();

void SleepToConsole(string str)
{
    Thread.Sleep(1000 * str.Length);
    Console.WriteLine(str);
}

void SleepToList(string str)
{
    Thread.Sleep(1000 * str.Length);
    mutex.WaitOne();
    sortedList.Add(str);
    mutex.ReleaseMutex();
}

void Sort(string[] s, Action<string> sleep)
{
    var threads = s.Select(str => new Thread(_ => sleep(str))).ToList();
    foreach (var thread in threads)
    {
        thread.Start();
    }

    foreach (var thread in threads)
    {
        thread.Join();
    }
}

var s = new string[]
{
    "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven",
    "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twenty"
};

Sort(s, SleepToConsole);
Sort(s, SleepToList);
Console.WriteLine(string.Join(' ', sortedList));