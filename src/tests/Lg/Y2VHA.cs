using WaterMolecules;

void Foo(string s)
{
    var h2o = new H2O();
    var threads = s.Select(c => c == 'H' ? 
        new Thread(() => h2o.Hydrogen(() => Console.Write(c))) :
        new Thread(() => h2o.Oxygen(() => Console.Write(c))))
        .ToList();

    threads.ForEach(thread => thread.Start());
    threads.ForEach(thread => thread.Join());
    Console.WriteLine();
}

Foo("HOH");
Foo("OOHHHH");
Foo("OOOOOOOOOOHHHHHHHHHHHHHHHHHHHH");