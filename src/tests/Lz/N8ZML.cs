namespace EventBus;

public class EventBus
{
    public void Subscribe(IPublisher publisher, ISubscriber subscriber)
    {
        publisher.OnPost += subscriber.OnEvent;
    }
    
    public void Unsubscribe(IPublisher publisher, ISubscriber subscriber)
    {
        publisher.OnPost -= subscriber.OnEvent;
    }
}