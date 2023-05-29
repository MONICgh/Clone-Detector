namespace SleepingBarber;

public class Barbershop
{
    private readonly object _locker;
    private readonly int _queueSize;
    private readonly Queue<Client> _queue;
    private readonly Task _task;

    public Barbershop(int queueSize)
    {
        _queueSize = queueSize;
        _queue = new Queue<Client>();
        _locker = new object();
        _task = Task.Run(WorkingCycle);
    }

    public void Wait()
    {
        _task.Wait();
    }
    
    public void AddClient(Client client)
    {
        lock (_locker)
        {
            if (_queue.Count == _queueSize)
            {
                Console.WriteLine(client + " left barbershop: queue is full");
                return;
            }

            Console.WriteLine(client + " is waiting in the queue");
            _queue.Enqueue(client);
            Monitor.Pulse(_locker);
        }
    }

    private void WorkingCycle()
    {
        while (true)
        {
            Client client;
            lock (_locker)
            {
                while (_queue.Count == 0)
                {
                    Monitor.Wait(_locker);
                }

                client = _queue.Dequeue();
            }
            Console.WriteLine(client + " is now being operated");
            Thread.Sleep(client.processingTime);
            Console.WriteLine(client + " is operated and left barbershop");
        }
    }
}