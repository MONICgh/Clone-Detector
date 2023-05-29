void RunH2O(string h2oString)
{
    var h2o = new H2O.H2O();
    var threads = new List<Thread>();

    foreach (var c in h2oString)
    {
        var thread = c == 'O'
            ? new Thread(() => h2o.Oxygen(() => Console.Write('O')))
            : new Thread(() => h2o.Hydrogen(() => Console.Write('H')));
        threads.Add(thread);
    }

    foreach (var thread in threads)
    {
        thread.Start();
    }
    
    foreach (var thread in threads)
    {
        thread.Join();
    }

    Console.WriteLine();
}

RunH2O("HOH");
RunH2O("OOHHHH");
