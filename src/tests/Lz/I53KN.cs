using NUnit.Framework;

namespace HW_05.PseudoStack;

[TestFixture]
public class TestStack
{
    [Test]
    public void CheckStack()
    {
        var stack = new ListStack<int>(2);

        Assert.AreEqual(0, stack.StacksCount());
        stack.Push(5);

        Assert.AreEqual(1, stack.StacksCount());
        stack.Push(6);

        Assert.AreEqual(1, stack.StacksCount());
        stack.Push(7);

        Assert.AreEqual(2, stack.StacksCount());

        Assert.AreEqual(7, stack.Pop());
    }
}
