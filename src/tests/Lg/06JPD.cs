using MultithreadArray;

var multiArray = new MultiArray(new List<int> {5, 2, 8, 4, 9, 1});

var random = new Random();
var threads = new List<Thread>();
for (int i = 0; i < 15; i++)
{
    switch (random.Next(0, 4))
    {
        case 0:
        {
            threads.Add(new Thread(() => multiArray.Avg()));
            break;
        }
        case 1:
        {
            threads.Add(new Thread(() => multiArray.Min()));
            break;
        }
        case 2:
        {
            threads.Add(new Thread(() => multiArray.Swap()));
            break;
        }
        case 3:
        {
            threads.Add(new Thread(() => multiArray.Sort()));
            break;
        }
    }
}
threads.ForEach(it => it.Start());
threads.ForEach(it => it.Join());