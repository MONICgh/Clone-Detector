List<object> mutexs = new List<object> { new(), new() };

void ThreadFunc(int i)
{
    lock (mutexs[i % 2])
    {
        Thread.Sleep(500);
        lock (mutexs[(i+1) % 2])
        {
            Console.WriteLine("If you see it, I lost:(");
        }
    }
}

new Thread(() => ThreadFunc(0)).Start();
new Thread(() => ThreadFunc(1)).Start();
