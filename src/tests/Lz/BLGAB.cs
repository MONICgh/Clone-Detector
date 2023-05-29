using EventBusLib;

namespace EventBusTesting
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var eventBus = new EventBus();
            var publisher = new Publisher("cool_user");
            var subscriber = new Subscriber();
            eventBus.NewPublisher(publisher);
            eventBus.Subscribe(publisher.Username(), subscriber);
            publisher.Post("Hello!");
            eventBus.Unsubscribe(publisher.Username(), subscriber);
            publisher.Post("Hello!");
        }
    }
}