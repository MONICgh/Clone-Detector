using System;

namespace EventBus;

public interface ISubscriber
{
    public string getName();

    public void OnEvent(object? sender, Post post);
}

public class Subscriber: ISubscriber
{
    private readonly string _name;

    public Subscriber(string name)
    {
        _name = name;
    }

    public string getName()
    {
        return _name;
    }

    public void OnEvent(object? sender, Post post)
    {
        
        Console.WriteLine($"Subscriber {_name} received post {post.Title} from {post.Author} at {DateTime.Now}.");
    }
}