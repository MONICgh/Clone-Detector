namespace EventBus;

public interface Subscriber
{
    public void OnEvent();
}

public class SubscriberA : Subscriber
{
    public void OnEvent()
    {
        Console.WriteLine("SubscriberA.OnEvent()");
    }
}

public class SubscriberB : Subscriber
{
    public void OnEvent()
    {
        Console.WriteLine("SubscriberB.OnEvent()");
    }
}

public class SubscriberC : Subscriber
{
    public void OnEvent()
    {
        Console.WriteLine("SubscriberC.OnEvent()");
    }
}

public class SubscriberD : Subscriber
{
    public void OnEvent()
    {
        Console.WriteLine("SubscriberD.OnEvent()");
    }
}