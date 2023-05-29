namespace Task1;

public abstract class AbstractPublisher
{
    public event Action OnPost = delegate {  };
    public abstract void Post();

    public void Clear()
    {
        OnPost = delegate {  };
    }

    public void Invoke()
    {
        OnPost.Invoke();
    }
}