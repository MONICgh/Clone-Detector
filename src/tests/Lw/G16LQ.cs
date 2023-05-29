using SleepingBarber;

void SimulateSingleClient()
{
    var barbershop = new Barbershop(5);
    barbershop.AddClient(new Client(1, 2000));
    barbershop.Wait();
}

void SimulateQueue()
{
    var barbershop = new Barbershop(3);
    barbershop.AddClient(new Client(1, 2000));
    barbershop.AddClient(new Client(2, 2000));
    barbershop.AddClient(new Client(3, 2000));
    barbershop.Wait();
}

void SimulateQueueIsFull()
{
    var barbershop = new Barbershop(3);
    barbershop.AddClient(new Client(1, 2000));
    barbershop.AddClient(new Client(2, 2000));
    barbershop.AddClient(new Client(3, 2000));
    barbershop.AddClient(new Client(4, 2000));
    barbershop.AddClient(new Client(5, 2000));
    barbershop.Wait();
}

void SimulateClientsArriveWithDelays()
{
    var barbershop = new Barbershop(3);
    barbershop.AddClient(new Client(1, 2000));
    barbershop.AddClient(new Client(2, 2000));
    barbershop.AddClient(new Client(3, 2000));
    Thread.Sleep(3000);
    barbershop.AddClient(new Client(4, 2000));
    Thread.Sleep(3000);
    barbershop.AddClient(new Client(5, 2000));
    barbershop.Wait();
}

void SimulateRandom()
{
    var rand = new Random();
    var n = rand.Next(10, 20);
    var s = rand.Next(1, 5);
    Console.WriteLine(n + " clients are on the way! Queue size is " + s);

    var barbershop = new Barbershop(s);
    for (int i = 1; i <= n; i++)
    {
        Thread.Sleep(rand.Next(100, 2000));
        barbershop.AddClient(new Client(i, rand.Next(500, 5000)));
    }
    barbershop.Wait();
}

SimulateRandom();