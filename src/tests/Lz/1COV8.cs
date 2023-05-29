namespace Task1;

public class EventBus
{
    private readonly Dictionary<string, AbstractPublisher> _dictPublishers;

    public EventBus()
    {
        _dictPublishers = new Dictionary<string, AbstractPublisher>();
    }

    public void AddPublisher(string name, AbstractPublisher abstractPublisher)
    {
        if (_dictPublishers.ContainsKey(name))
        {
            throw new ArgumentException("There are already publisher " + name + " added");
        }
        
        _dictPublishers.Add(name, abstractPublisher);
    }

    public void RemovePublisher(string name)
    {
        if (!_dictPublishers.ContainsKey(name))
        {
            throw new ArgumentException("There are no publisher with name " + name);
        }

        _dictPublishers[name].Clear();
        _dictPublishers.Remove(name);
    }

    public void Subscribe(ISubscriber subscriber, string publisherName)
    {
        _dictPublishers[publisherName].OnPost += subscriber.OnEvent;
    }

    public void Unsubscribe(ISubscriber subscriber, string publisherName)
    {
        _dictPublishers[publisherName].OnPost -= subscriber.OnEvent;
    }
}