namespace EventBus;

public class EventBus
{
    private readonly Dictionary<string, Publisher> _publishers;

    public EventBus()
    {
        _publishers = new Dictionary<string, Publisher>();
    }

    public void AddPublisher(string publisherName, Publisher publisher)
    {
        _publishers[publisherName] = publisher;
    }

    public void RemovePublisher(string publisherName)
    {
        _publishers[publisherName].ClearSubscribers();
        _publishers.Remove(publisherName);
    }

    public void Subscribe(string publisherName, Subscriber subscriber)
    {
        _publishers[publisherName].OnPost += subscriber.OnEvent;
    }

    public void Unsubscribe(string publisherName, Subscriber subscriber)
    {
        _publishers[publisherName].OnPost -= subscriber.OnEvent;
    }
}