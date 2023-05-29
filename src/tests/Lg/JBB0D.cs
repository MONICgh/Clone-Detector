using NUnit.Framework;

namespace HW_16;

[TestFixture]
public class TestZeroEven
{
    private String data = "";

    void printNumber(int x)
    {
        data += x.ToString();
    }

    [Test]
    public void Test()
    {
        ZeroEvenOdd odd = new ZeroEvenOdd(4);
        var t0 = new Thread(() => odd.Zero(printNumber));
        var t1 = new Thread(() => odd.Even(printNumber));
        var t2 = new Thread(() => odd.Odd(printNumber));
        t0.Start();
        t1.Start();
        t2.Start();
        t0.Join();
        t1.Join();
        t2.Join();
        Assert.AreEqual("01020304", data);
    }
}
