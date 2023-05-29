using Task3;

void Test1()
{
    // Ситуация, когда парихмахер успевает всех обслуживать
    var barbershop = new Barbershop(2);
    var thread = new Thread(barbershop.Start);
    thread.Start();
    for (int i = 0; i < 2; i++)
    {
        barbershop.NewClient(new Client(i));
    }
    Thread.Sleep(2500);
    for (int i = 0; i < 2; i++)
    {
        barbershop.NewClient(new Client(i + 2));
    }
    Thread.Sleep(2500);
    barbershop.Stop();
}

Test1();

Console.WriteLine();

void Test2()
{
    // Ситуация, когда парихмахер не успевает всех обслужить
    var barbershop = new Barbershop(2);
    var thread = new Thread(barbershop.Start);
    thread.Start();
    for (int i = 0; i < 4; i++)
    {
        barbershop.NewClient(new Client(i));
    }
    Thread.Sleep(3500);
    barbershop.Stop();
}

Test2();

Console.WriteLine();

void Test3()
{
    // Ситуация, когда люди приходят через случайное время
    var barbershop = new Barbershop(2);
    var thread = new Thread(barbershop.Start);
    var random = new Random();
    thread.Start();
    for (int i = 0; i < 20; i++)
    {
        Thread.Sleep(random.Next(500));
        barbershop.NewClient(new Client(i));
    }
    Thread.Sleep(3500);
    barbershop.Stop();
}

Test3();
