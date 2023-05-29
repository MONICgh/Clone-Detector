async Task CreateRandomFiles()
{
    var rng = new Random();
    for (var i = 1; i <= 100; ++i)
    {
        var oper = rng.Next() % 3 + 1;
        var a = (rng.Next() % 10000000) / 10000.0;
        var b = (rng.Next() % 10000000) / 10000.0;
        var text = oper + "\n" + a + " " + b;
        var file = @"../../../Files/" + i + ".txt";
        File.Delete(file);
        await using var writer = File.AppendText(file);
        writer.WriteLine(text);
    }
}

await CreateRandomFiles();

double res = 0;
var mutex = new Mutex();

(int, double, double) ReadFile(int i)
{
    if (i is > 100 or < 1)
    {
        throw new Exception();
    }
    var file = @"../../../Files/" + i + ".txt";
    using var reader = File.OpenText(file);
    var oper = int.Parse(reader.ReadLine()!);
    var tmp = reader.ReadLine()!.Split(' ').Select(float.Parse).ToList();
    var (a, b) = (tmp[0], tmp[1]);
    return (oper, a, b);
}

double Calc(int oper, double a, double b)
{
    return oper switch
    {
        1 => a + b,
        2 => a * b,
        3 => a * a + b * b,
        _ => throw new Exception()
    };
}

void Go(int l, int r)
{
    for (var i = l; i <= r; ++i)
    {
        var (oper, a, b) = ReadFile(i);
        mutex.WaitOne();
        res += Calc(oper, a, b);
        mutex.ReleaseMutex();
    }
}

void Solve(int numberOfThreads, int numberOfFiles)
{
    var threads = new List<Thread>();
    int files = numberOfFiles / numberOfThreads, rem = numberOfFiles % numberOfThreads;
    var sum = 0;
    for (var i = 0; i < numberOfThreads; ++i)
    {
        var cur = files;
        if (i < rem)
        {
            cur += 1;
        }

        int l = sum + 1, r = sum + cur;
        var thread = new Thread(_ => Go(l, r));
        sum += cur;
        threads.Add(thread);
    }

    foreach (var thread in threads)
    {
        thread.Start();
    }

    foreach (var thread in threads)
    {
        thread.Join();
    }
    
    var file = @"../../../out.dat";
    File.Delete(file);
    using var writer = File.AppendText(file);
    writer.WriteLine(res.ToString());
}

Solve(10, 100);