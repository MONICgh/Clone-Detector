using NUnit.Framework;

namespace HW_10;

[TestFixture]
public class BlackBoxTest
{
    [Test]
    public void CheckBlackBox()
    {
        var runner = new ReflectionBlackBoxRunner();
        Assert.AreEqual(100, runner.ExecuteCommandAndGetValue("Add 100"));
        Assert.AreEqual(80, runner.ExecuteCommandAndGetValue("Subtract 20"));
        Assert.AreEqual(16, runner.ExecuteCommandAndGetValue("Divide 5"));
        Assert.AreEqual(32, runner.ExecuteCommandAndGetValue("Multiply 2"));
    }

    [Test]
    public void CheckEnvelopSolver()
    {
        var result = EnvelopSolver.Solve(new List<Envelop>
        {
            new(5, 4),
            new(6, 4),
            new(6, 7),
            new(2, 3)
        });

        Assert.AreEqual(3, result);
    }
}
