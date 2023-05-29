using minstack;
using Xunit;

namespace Tests;

public class MinStackTests
{
    [Fact]
    public static void BaseStackTest()
    {
        int top;
        var stack = new MinStack<int>();

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);
        stack.Push(6);

        // Wrong top value.
        Assert.Equal(6, stack.Top);

        var array = stack.ToArray();

        // Wrong size!
        Assert.Equal(array.Length, stack.Count);

        top = stack.Pop();

        // Wrong top value.
        Assert.Equal(5, stack.Top);

        stack.Pop();
        stack.Pop();

        // Wrong top value.
        Assert.Equal(3, stack.Top);

        var array2 = stack.ToArray();

        // Wrong size!
        Assert.Equal(array2.Length, stack.Count);
    }

    [Fact]
    public static void MinValueTest()
    {
        int top;
        var stack = new MinStack<int>();

        stack.Push(4);
        stack.Push(2);
        stack.Push(2);
        stack.Push(3);
        stack.Push(1);
        
        Assert.Equal(1, stack.MinValue());

        top = stack.Pop();
        Assert.Equal(2, stack.MinValue());

        top = stack.Pop();
        Assert.Equal(2, stack.MinValue());

        top = stack.Pop();
        Assert.Equal(2, stack.MinValue());

        top = stack.Pop();
        Assert.Equal(4, stack.MinValue());
    }
}