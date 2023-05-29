namespace HW_05.EventBusImpl;

public class EventBus
{
    public delegate string SubscriberContainer(int x);

    public event SubscriberContainer Notify = null!;
    public void NumberFlowController(int x)
    {
        Notify(x);
    }

    public List<string> Data = new();

}
