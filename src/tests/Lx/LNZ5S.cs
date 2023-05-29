using Xunit;

namespace MinValueStack;

public class MinValueStackTest
{
    public static void DoTest()
    {
        var stack = new MinValueStack<int>();
        stack.Push(4);
        Assert.True(stack.MinValue() == 4);
        stack.Push(5);
        Assert.True(stack.MinValue() == 4);
        stack.Push(1);
        Assert.True(stack.MinValue() == 1);
        stack.Push(3);
        Assert.True(stack.MinValue() == 1);

        var elem = stack.Pop();
        Assert.True(elem == 3);
        Assert.True(stack.MinValue() == 1);

        stack.Pop();
        Assert.True(stack.MinValue() == 4);
    }
}