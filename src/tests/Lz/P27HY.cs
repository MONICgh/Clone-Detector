// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Task1;

var subscriber1 = new Subscriber();
var subscriber2 = new Subscriber();

var publisher1 = new Publisher();
var publisher2 = new Publisher();

var eventBus = new EventBus();

eventBus.AddPublisher("p1", publisher1);
eventBus.AddPublisher("p2", publisher2);

eventBus.Subscribe(subscriber1, "p1");
eventBus.Subscribe(subscriber1, "p2");

eventBus.Subscribe(subscriber2, "p2");

Debug.Assert(subscriber1.Counter == 0);
Debug.Assert(subscriber2.Counter == 0);

publisher1.Post();

Debug.Assert(subscriber1.Counter == 1);
Debug.Assert(subscriber2.Counter == 0);

publisher2.Post();

Debug.Assert(subscriber1.Counter == 2);
Debug.Assert(subscriber2.Counter == 1);

eventBus.RemovePublisher("p1");

publisher1.Post();

Debug.Assert(subscriber1.Counter == 2);
Debug.Assert(subscriber2.Counter == 1);

publisher2.Post();

Debug.Assert(subscriber1.Counter == 3);
Debug.Assert(subscriber2.Counter == 2);

eventBus.Unsubscribe(subscriber1, "p2");

publisher2.Post();

Debug.Assert(subscriber1.Counter == 3);
Debug.Assert(subscriber2.Counter == 3);

Console.WriteLine("All is Okay!");
