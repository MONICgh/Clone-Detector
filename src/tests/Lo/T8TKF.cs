// See https://aka.ms/new-console-template for more information

var x = "";

void Add(string y)
{
    Thread.Sleep(new Random().Next(100, 500));
    x += y;
}

void Main()
{
    x = "";
    var thread1 = new Thread(_ => Add("1"));
    var thread2 = new Thread(_ => Add("2"));
    thread1.Start();
    thread2.Start();
    thread1.Join();
    thread2.Join();
    Console.WriteLine($"New value: {x}");
}

for (var i = 0; i < 10; i++)
{
    Main();
}
