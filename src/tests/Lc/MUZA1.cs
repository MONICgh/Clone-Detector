var numberOfThreads = Convert.ToInt32(Console.ReadLine());
var steps = new List<long>();
var stop = false;
const int checkStep = 1_000_000;
var sums = new List<double>();

double get(int start)
{
    var x = start + steps[start] * numberOfThreads;
    var res = 1.0 / (2 * x + 1);
    if (x % 2 == 1) res *= -1;
    return res;
}

void Calc(int start)
{
    while (true)
    {
        sums[start] += get(start);
        ++steps[start];
        if (steps[start] % checkStep == 0 && stop)
        {
            break;
        }
    }
}

void WaitForStop()
{
    while (true)
    {
        var line = Console.ReadLine();
        if (line == "stop")
        {
            stop = true;
            break;
        }
    }
}

var threads = new List<Thread>();
for (var i = 0; i < numberOfThreads; ++i)
{
    steps.Add(0);
    sums.Add(0);
    var j = i;
    var thread = new Thread(() => Calc(j));
    thread.Start();
    threads.Add(thread);
}

var stopThread = new Thread(WaitForStop);
stopThread.Start();
stopThread.Join();
long max = 0;
for (var i = 0; i < numberOfThreads; ++i)
{
    threads[i].Join();
    max = Math.Max(max, steps[i]);
}

double sum = 0;

for (var i = 0; i < numberOfThreads; ++i)
{
    while (steps[i] < max)
    {
        sums[i] += get(i);
        ++steps[i];
    }
    sum += sums[i];
}

Console.WriteLine(4 * sum);