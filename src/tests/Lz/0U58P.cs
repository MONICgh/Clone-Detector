using EventBus;

var eventBus = new EventBus.EventBus();

var publisherA = new PublisherA();
var publisherB = new PublisherB();
var publisherC = new PublisherC();

var subscriberA = new SubscriberA();
var subscriberB = new SubscriberB();
var subscriberC = new SubscriberC();
var subscriberD = new SubscriberD();

eventBus.AddPublisher("publisherA", publisherA);
eventBus.AddPublisher("publisherB", publisherB);
eventBus.AddPublisher("publisherC", publisherC);

eventBus.Subscribe("publisherA", subscriberA);
eventBus.Subscribe("publisherA", subscriberB);
eventBus.Subscribe("publisherA", subscriberC);
eventBus.Subscribe("publisherA", subscriberD);

eventBus.Subscribe("publisherB", subscriberA);
eventBus.Subscribe("publisherB", subscriberC);

eventBus.Subscribe("publisherC", subscriberB);
eventBus.Subscribe("publisherC", subscriberD);

publisherA.Post();
publisherB.Post();
publisherC.Post();

eventBus.Unsubscribe("publisherA", subscriberD);
publisherA.Post();

eventBus.RemovePublisher("publisherA");
publisherA.Post();