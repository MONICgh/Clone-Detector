namespace EventBus;

public interface Publisher
{
    public event Action OnPost;

    public void Post();

    public void ClearSubscribers();
}

public class PublisherBase : Publisher
{
    public event Action OnPost = delegate {  };

    public virtual void Post()
    {
        OnPost.Invoke();
    }

    public void ClearSubscribers()
    {
        OnPost = delegate {  };
    }
}

public class PublisherA : PublisherBase
{
    public override void Post()
    {
        Console.WriteLine("PublisherA.Post()");
        base.Post();
    }
}

public class PublisherB : PublisherBase
{
    public override void Post()
    {
        Console.WriteLine("PublisherB.Post()");
        base.Post();
    }
}

public class PublisherC : PublisherBase
{
    public override void Post()
    {
        Console.WriteLine("PublisherC.Post()");
        base.Post();
    }
}