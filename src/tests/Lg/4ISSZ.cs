object cLock, isCalcLock;
object[,] aLock, bLock;
bool[,] isCalc;
CountdownEvent countdown;
int[,] a, b, c;
int m, n, k;

void Calc(int i, int j)
{
    var res = 0;
    for (var t = 0; t < n; ++t)
    {
        lock (aLock[i, t])
        {
            lock (bLock[t, j])
            {
                res += a[i, t] * b[t, j];
            }
        }
    }

    lock (cLock)
    {
        c[i, j] = res;
    }
    Console.WriteLine($"[{i}, {j}] is calculated!");
    Thread.Sleep(new Random().Next(500, 1500));
}

void Foo()
{
    for (var i = 0; i < m; ++i)
    {
        for (var j = 0; j < k; ++j)
        {
            var isNotCalc = false;
            lock (isCalcLock)
            {
                if (!isCalc[i, j])
                {
                    isCalc[i, j] = true;
                    isNotCalc = true;
                }
            }

            if (isNotCalc)
            {
                Calc(i, j);
            }
        }
    }

    countdown.Signal();
    Console.WriteLine("Another thread is done!");
}

void Prepare(int _m, int _n, int _k, int[,] _a, int[,] _b, int nThreads)
{
    m = _m;
    n = _m;
    k = _k;
    cLock = new object();
    isCalcLock = new object();
    c = new int[m, k];
    a = new int[m, n];
    b = new int[k, n];
    isCalc = new bool[m, k];
    isCalcLock = new object[m, k];
    for (var i = 0; i < m; ++i)
    {
        for (var j = 0; j < k; ++j)
        {
            isCalc[i, j] = false;
        }
    }
    aLock = new object[m, n];
    for (var i = 0; i < m; ++i)
    {
        for (var j = 0; j < n; ++j)
        {
            aLock[i, j] = new object();
            a[i, j] = _a[i, j];
        }
    }
    bLock = new object[n, k];
    for (var i = 0; i < n; ++i)
    {
        for (var j = 0; j < k; ++j)
        {
            bLock[i, j] = new object();
            b[i, j] = _b[i, j];
        }
    }
    countdown = new CountdownEvent(nThreads);
}

int[,] Mul(int[,] _a, int[,] _b, int nThreads)
{
    var (_m, _n) = (_a.GetLength(0), _a.GetLength(1));
    var (_n1, _k) = (_b.GetLength(0), _b.GetLength(1));
    if (_n1 != _n)
    {
        throw new Exception("The dimensions are mismatched!");
    }
    Prepare(_m, _n, _k, _a, _b, nThreads);
    var threads = new List<Thread>();
    for (var i = 0; i < nThreads; ++i)
    {
        var thread = new Thread(Foo);
        thread.Start();
        threads.Add(thread);
    }

    countdown.Wait();
    for (var i = 0; i < nThreads; ++i)
    {
        threads[i].Join();
    }

    return c;
}

var A = new int[4, 4];
var B = new int[4, 4];
for (var i = 0; i < 4; ++i)
{
    for (var j = 0; j < 4; ++j)
    {
        A[i, j] = i * 4 + j + 1;
        if (i == j)
        {
            B[i, j] = 1;
        }
        else
        {
            B[i, j] = 0;
        }
    }
}

var C = Mul(A, B, 5);
for (var i = 0; i < 4; ++i)
{
    for (var j = 0; j < 4; ++j)
    {
        Console.Write($"{C[i, j]} ");
    }

    Console.WriteLine();
}