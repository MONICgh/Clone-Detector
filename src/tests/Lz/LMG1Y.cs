using NUnit.Framework;

namespace EventBus;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        EventBus eventBus = new EventBus();

        Publisher publisher1 = new Publisher("First publisher");
        Publisher publisher2 = new Publisher("Second publisher");

        Subscriber subscriber1 = new Subscriber("First subscriber");
        Subscriber subscriber2 = new Subscriber("Second subscriber");
        Subscriber subscriber3 = new Subscriber("Third subscriber");
        
        eventBus.Subscribe(publisher1, subscriber1);
        eventBus.Subscribe(publisher2, subscriber2);
        eventBus.Subscribe(publisher1, subscriber3);
        eventBus.Subscribe(publisher2, subscriber3);
        
        publisher1.Post("Random post #1");
        publisher1.Post("Random post #2");
        publisher2.Post("Random post #3");
        publisher1.Post("Random post #4");
        publisher2.Post("Random post #5");
        
        eventBus.Unsubscribe(publisher1, subscriber1);
        
        publisher1.Post("Random post #6");
    }
}