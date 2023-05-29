using System.Numerics;
using NUnit.Framework;

namespace HW_04.LuckyTicket;

public class Tests
{
    [Test]
    public void Test2()
    {
        var solver = new Solver();
        Assert.AreEqual(new BigInteger(10), solver.Solve(2));
        Assert.AreEqual(new BigInteger(670), solver.Solve(4));
        Assert.AreEqual(new BigInteger(39581170420), solver.Solve(12));
    }

}
