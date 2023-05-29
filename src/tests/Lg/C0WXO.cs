using MultithreadArray;

var mtarray = new MTArray(new int[] {1, 2, 3, 4, 5, 1, 2, 4});

var rng = new Random();
var threads = new List<Thread>();
for (var it = 0; it < 20; ++it)
{
    var i = rng.Next() % 4;
    var thread = i switch
    {
        0 => new Thread(mtarray.TAvg),
        1 => new Thread(mtarray.TMin),
        2 => new Thread(mtarray.TSort),
        _ => new Thread(mtarray.TSwap)
    };
    threads.Add(thread);
}

threads.ForEach(thread => thread.Start());
threads.ForEach(thread => thread.Join());