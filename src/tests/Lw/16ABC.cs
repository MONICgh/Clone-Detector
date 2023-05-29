using BearAndBees;

var capacity = 10;
var beesCount = 4;
var notifier = new CountdownEvent(capacity);
var pot = new Pot(notifier);

var bees = new List<Bee>(beesCount);
for (var i = 0; i < beesCount; i++)
{
    bees.Add(new Bee(pot));
}

var beesThreads = bees.Select(it => new Thread(it.Run)).ToList();

var bear = new Bear(pot, notifier);
var bearThread = new Thread(() => bear.Run());

beesThreads.ForEach(it => it.Start());
bearThread.Start();

Thread.Sleep(10000);

bear.Stop();
bees.ForEach(it => it.Stop());

bearThread.Join();
beesThreads.ForEach(it => it.Join());