using System.Collections.Concurrent;

namespace Task3;

public class Barbershop
{
    private int _maxWait;
    private object _waitingLocker = new();
    private ConcurrentQueue<Client> _waitingClients = new ConcurrentQueue<Client>();
    private Random _random = new Random();

    public Barbershop(int maxWait)
    {
        _maxWait = maxWait;
    }

    private bool _flag = true;

    public void Stop()
    {
        _flag = false;
    }

    public void Start()
    {
        while (_flag)
        {
            TrySleep();
            Cut();
        }
    }

    public void NewClient(Client client)
    {
        lock (_waitingLocker)
        {
            if (_waitingClients.Count >= _maxWait)
            {
                client.Leave();
                return;
            }
            _waitingClients.Enqueue(client);            
        }
    }

    public void TrySleep()
    {
        while (_waitingClients.IsEmpty && _flag) {}
    }

    public void Cut()
    {
        _waitingClients.TryDequeue(out var client);
        Thread.Sleep(_random.Next(1000));
        client?.Cut();
        client?.Leave();
    }
}