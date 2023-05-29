namespace Application;

public class Salon
{
    private Hairdresser hairdresser;
    private int maxClients;
    private Queue<string> clients = new Queue<string>();
    private readonly object _lock = new object();
    private readonly object _cut = new object();

    public Salon(Hairdresser hairdresser, int maxClients)
    {
        this.maxClients = maxClients;
        this.hairdresser = hairdresser;
    }

    public int MaxClients
    {
        get => maxClients;
    }

    public bool isFinish()
    {
        return clients.Count == 0 && hairdresser.HairdresserState == Hairdresser.State.SLEEP;
    }
    
    public void AddClient(string name)
    {
        lock (_lock)
        {
            Console.WriteLine($"Client {name} came");
            if (clients.Count == maxClients)
            {
                Console.WriteLine($"Client {name} left (no places)");
                return;
            }
            clients.Enqueue(name);
            Console.WriteLine($"Client {name} sat down");
            if (clients.Count == 1 && hairdresser.HairdresserState == Hairdresser.State.SLEEP)
            {
                var task = new Task(() => work());  // wakes up hairdresser
                task.Start();
            }
        }
    }
    
    private void work()
    {
        string name;
        bool empty = false;
        while (!empty)
        {
            lock (_cut)
            {
                lock (_lock)
                {
                    if (clients.Count == 0)
                    {
                        empty = true;
                        continue;
                    }
                    name = clients.Dequeue();
                }

                hairdresser.cut(name);
                Console.WriteLine($"Client {name} left");
            }
        }

        hairdresser.sleep();
    }
}
