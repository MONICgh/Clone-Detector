using System;

namespace EventBus;

public interface IPublisher
{
    public string getName();
    public event EventHandler<Post> OnPost;
    public void Post(string title);
}

public class Publisher : IPublisher
{
    private readonly string _name;

    public Publisher(string name)
    {
        _name = name;
    }

    public string getName()
    {
        return _name;
    }

    public event EventHandler<Post> OnPost = delegate {  };

    public void Post(string title)
    {
        Console.WriteLine($"Create new post from {getName()} at {DateTime.Now}!");
        OnPost.Invoke(this, new Post(getName(), title));
    }
}