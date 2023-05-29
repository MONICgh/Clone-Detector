using System.Diagnostics;

List<List<int>> MultipleMatrices(List<List<int>> A, List<List<int>> B, int numberThreads)
{
    int i = 0;
    int j = 0;
    var locker = new object();
    var threads = new List<Thread>();
    var C = new List<List<int>>();
    for (int it = 0; it < A.Count; it++)
    {
        C.Add(new List<int>(B[0].Count));
        for (int jt = 0; jt < B.Count; jt++)
        {
            C[it].Add(0);
        }
    }

    for (int t = 0; t < numberThreads; t++)
    {
        threads.Add(new Thread(() =>
        {
            while (i < A.Count)
            {
                int ti, tj;
                lock (locker)
                {
                    ti = i;
                    tj = j;
                    j++;
                    if (j >= B[0].Count)
                    {
                        i++;
                        j = 0;
                    }
                }
                
                if (ti >= A.Count)
                    break;

                C[ti][tj] = 0;
                for (int k = 0; k < B.Count; k++)
                {
                    C[ti][tj] += A[ti][k] * B[k][tj];
                }
                Thread.Sleep(50);
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

    return C;
}

var a = new List<List<int>>()
{
    new List<int>() { 1, 2, 3, 4 },
    new List<int>() { 5, 6, 7, 8 },
    new List<int>() { 9, 10, 11, 12 }
};

var b = new List<List<int>>()
{
    new List<int>() { 8, 7 },
    new List<int>() { 6, 5 },
    new List<int>() { 4, 3 },
    new List<int>() { 2, 1 },
};

var c = new List<List<int>>
{
    new List<int>() {40, 30},
    new List<int>() {120, 94},
    new List<int>() {200, 158}
};

var c1 = MultipleMatrices(a, b, 1);
for (int i = 0; i < c.Count; i++)
{
    for (int j = 0; j < c[i].Count; j++)
    {
        Debug.Assert(c1[i][j] == c[i][j]);
    }
}

var c2 = MultipleMatrices(a, b, 2);
for (int i = 0; i < c.Count; i++)
{
    for (int j = 0; j < c[i].Count; j++)
    {
        Debug.Assert(c2[i][j] == c[i][j]);
    }
}

var c3 = MultipleMatrices(a, b, 6);
for (int i = 0; i < c.Count; i++)
{
    for (int j = 0; j < c[i].Count; j++)
    {
        Debug.Assert(c3[i][j] == c[i][j]);
    }
}

Console.WriteLine("All is Okay!");