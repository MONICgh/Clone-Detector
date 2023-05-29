using System.Collections.Concurrent;

namespace SleepingHairdresser;

public class Hairdresser
{
    private BlockingCollection<Client> _queue;
    private readonly object _locker = new();
    private readonly Random _random = new();
    private bool _stop;
    private readonly Task _hairdresserTask;

    public Hairdresser(int queueSize)
    {
        _queue = new BlockingCollection<Client>(queueSize);
        _hairdresserTask = Task.Run(Work);
    }

    public void Stop()
    {
        _stop = true;
        _hairdresserTask.Wait();
    }

    private void Work()
    {
        while (!(_stop && _queue.Count == 0))
        {
            lock (_locker)
            {
                while (_queue.Count == 0)
                {
                    Console.WriteLine("I am sleeping");
                    Monitor.Wait(_locker);
                    Console.WriteLine("I was woken up!");
                }
            }

            if (_queue.TryTake(out Client client))
            {
                Console.WriteLine($"I am working with {client}");
                Thread.Sleep(_random.Next(500, 1000));
                Console.WriteLine($"I finished with {client}");
            }
        }
    }

    public void AddClient(Client client)
    {
        if (_queue.Count == _queue.BoundedCapacity)
        {
            Console.WriteLine($"I do not have free space in queue. Sorry, {client}.");
        }
        else
        {
            _queue.Add(client);

            lock (_locker)
            {
                Monitor.Pulse(_locker);
            }
        }
    }
}