void printOxygen()
{
    Console.Write("O");
}

void printHydrogen()
{
    Console.Write("H");
}

var waterMaker = new H2O.H2O();

var hydrogenThreads = new List<Thread>();
for (int i = 0; i < 8; i++)
{
    hydrogenThreads.Add(new Thread(() => waterMaker.Hydrogen(printHydrogen)));
}

var oxygenThreads = new List<Thread>();
for (int i = 0; i < 4; i++)
{
    oxygenThreads.Add(new Thread(() => waterMaker.Oxygen(printOxygen)));
}

hydrogenThreads.ForEach(it => it.Start());
oxygenThreads.ForEach(it => it.Start());

hydrogenThreads.ForEach(it => it.Join());
oxygenThreads.ForEach(it => it.Join());
