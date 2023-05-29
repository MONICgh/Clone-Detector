using NUnit.Framework;

namespace EventBus
{
    public class EventBusTest
    {
        [Test]
        public void Test1()
        {
            EventBus eventBus = new EventBus();
            Writer writer1 = new Writer("Oleg", eventBus);
            writer1.WriteEvent();

            Reader reader1 = new Reader("Maxim");
            eventBus.Subscribe(reader1.OnEvent);
            writer1.WriteEvent();

            Reader reader2 = new Reader("Igor");
            eventBus.Subscribe(reader2.OnEvent);

            Writer writer2 = new Writer("Pavel", eventBus);
            writer2.WriteEvent();

            eventBus.Unsubscribe(reader1.OnEvent);
            writer2.WriteEvent();
        }
    }
}
