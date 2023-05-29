const int size = 7;

bool InBounds(int x, int y)
{
    return x is >= 0 and < size && y is >= 0 and < size;
}

var isWolf = new bool[size, size];
var isRam = new HashSet<int>[size, size];

for (var i = 0; i < size; ++i)
{
    for (var j = 0; j < size; ++j)
    {
        isRam[i, j] = new HashSet<int>();
        isWolf[i, j] = false;
    }
}

var (curX, curY) = (new List<int>(), new List<int>());
var threads = new List<Thread>();
var destroyed = new List<bool>();
var myLock = new object();

(List<int>, List<int>) ValidMoves(int x, int y)
{
    var (validX, validY) = (new List<int>(), new List<int>());
    for (var dx = -1; dx <= 1; ++dx)
    {
        for (var dy = -1; dy <= 1; ++dy)
        {
            if (dx == 0 && dy == 0) continue;
            var (nx, ny) = (x + dx, y + dy);
            if (InBounds(nx, ny))
            {
                validX.Add(nx);
                validY.Add(ny);
            }
        }
    }

    return (validX, validY);
}

void Ram(int i)
{
    var rng = new Random();
    while (true)
    {
        Thread.Sleep(rng.Next(500, 999));
        lock (myLock)
        {
            if (destroyed[i])
            {
                break;
            }
            var (validX, validY) = ValidMoves(curX[i], curY[i]);
            var nMoves = validX.Count;
            var id = rng.Next() % nMoves;
            var (nx, ny) = (validX[id], validY[id]);
            isRam[curX[i], curY[i]].Remove(i);
            if (isWolf[nx, ny])
            {
                destroyed[i] = true;
                break;
            } 
            if (isRam[nx, ny].Count > 0)
            {
                NewRam(nx, ny);
            }

            isRam[nx, ny].Add(i);
            curX[i] = nx;
            curY[i] = ny;
        }
    }
}

void NewRam(int x, int y)
{
    var id = threads.Count;
    isRam[x, y].Add(id);
    destroyed.Add(false);
    curX.Add(x);
    curY.Add(y);
    threads.Add(new Thread(_ => Ram(id)));
    threads.Last().Start();
}

void Wolf()
{
    var rng = new Random();
    while (true)
    {
        Thread.Sleep(rng.Next(500, 999));
        lock (myLock)
        {
            var (validX, validY) = ValidMoves(curX[0], curY[0]);
            var nMoves = validX.Count;
            var id = rng.Next() % nMoves;
            var (nx, ny) = (validX[id], validY[id]);
            isWolf[curX[0], curY[0]] = false;
            if (isRam[nx, ny].Count > 0)
            {
                var rams = isRam[nx, ny].ToList();
                foreach (var j in rams)
                {
                    destroyed[j] = true;
                    isRam[nx, ny].Remove(j);
                }
            }

            isWolf[nx, ny] = true;
            curX[0] = nx;
            curY[0] = ny;
        }
    }
}

void Print()
{
    while (true)
    {
        Thread.Sleep(3000);
        lock (myLock)
        {
            for (var i = 0; i < size; ++i)
            {
                for (var j = 0; j < size; ++j)
                {
                    if (isWolf[i, j])
                    {
                        Console.Write('W');
                    } 
                    else if (isRam[i, j].Count > 0)
                    {
                        Console.Write('R');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

destroyed.Add(false);
curX.Add(0);
curY.Add(0);
var wolf = new Thread(Wolf);
threads.Add(wolf);
wolf.Start();

lock (myLock)
{
    NewRam(0, size - 1);
}
lock (myLock)
{
    NewRam(size - 1, 0);
}
lock (myLock)
{
    NewRam(size - 1, size - 1);
}

var print = new Thread(Print);
print.Start();