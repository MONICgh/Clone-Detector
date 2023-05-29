using OrderedPrint;

void Main()
{
    var orderer = new Orderer();
    var foo = new Foo();

    var threads = new List<Thread>
    {
        new Thread(() => orderer.Run(2, foo.second)),
        new Thread(() => orderer.Run(3, foo.third)),
        new Thread(() => orderer.Run(1, foo.first)),
    };
    
    threads.ForEach(it => it.Start());
    threads.ForEach(it => it.Join());
}

Main();