using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab5
{
    [TestClass]
    public class EventBusTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var pub1 = new Publisher("pub1");
            var pub2 = new Publisher("pub2");
            var sub1 = new Subscriber("sub1");
            var sub2 = new Subscriber("sub2");
            var eventBus = new EventBus();

            pub1.ConnectBus(eventBus);
            pub2.ConnectBus(eventBus);

            eventBus.Subscribe(sub1);
            eventBus.Subscribe(sub2);
            pub1.Post();
            pub2.Post();
        }
    }
}
