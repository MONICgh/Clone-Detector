using NUnit.Framework;

namespace HW_04.InterfacesAndClasses;

public class Tests
{

    [Test]
    public void Test()
    {
        var controller = new PrintController();
        var s = controller.ToPrintableStr("kek");
        Assert.AreEqual(s, "kek abstract");
    }

    [Test]
    public void Test2()
    {
        var controller = new PrintController();
        var s = (controller as IOutput).ToPrintableStr("kek");
        Assert.AreEqual(s, "kek IOutput");
    }

    [Test]
    public void Test3()
    {
        var controller = new PrintController();
        var s = (controller as IPrintable).ToPrintableStr("kek");
        Assert.AreEqual(s, "kek IPrintable");
    }
}
