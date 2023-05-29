using NUnit.Framework;

namespace HW_05.EventBusImpl;

public class Tests
{
    [Test]
    public void TestRun()
    {
        var bus = new EventBus();
        bus.Notify += PrinterSubscriber1.GetBeautifulStringWithOutput;
        bus.Notify += PrinterSubscriber1.GetUglyString;

        var counter10 = new ClassCounter10();
        var counter15 = new ClassCounter15();

        counter10.Push += bus.NumberFlowController;
        counter15.Push += bus.NumberFlowController;

        counter10.Count();
        counter15.Count();
    }

}
