using System.Collections.Concurrent;

namespace task3
{
    class Barber
    {
        public readonly int Chairs;
        private ConcurrentQueue<Client> _clients;
        private readonly object locker = new object();  
        
        public Barber(int chairs)
        {
            Chairs = chairs;
            _clients = new ConcurrentQueue<Client>();
        }

        public void AddClient(Client client)
        {

            if (_clients.Count == Chairs)
            {
                Console.WriteLine($"Queue overflow. Skip client {client.Name}");
            }
            else
            {
                lock(locker)
                {
                    _clients.Enqueue(client);
                    Console.WriteLine($"Added client {client.Name}");
                    Monitor.Pulse(locker);
                }
            }
        }
        
        public void Work()
        {
            while(true)
            {
                lock (locker)
                {
                    while (_clients.Count == 0)
                    {
                        Monitor.Wait(locker);
                    }


                    if (_clients.TryDequeue(out Client client))
                    {
                        
                        Console.WriteLine($"Served client: {client.Name}");
                        Thread.Sleep(100);
                    }
                    Monitor.Pulse(locker);
                }
                
            }
        }
    }
}
