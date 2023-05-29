using NUnit.Framework;

namespace PseudoStack;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestPushAndResize()
    {
        var pseudoStack = new PseudoStack<int>(3);
        
        pseudoStack.Push(1);
        Assert.AreEqual(1, pseudoStack.StackCount());
        
        pseudoStack.Push(2);
        pseudoStack.Push(3);
        Assert.AreEqual(1, pseudoStack.StackCount());
        
        pseudoStack.Push(4);
        Assert.AreEqual(2, pseudoStack.StackCount());
        
        pseudoStack.Push(5);
        pseudoStack.Push(6);
        pseudoStack.Push(7);
        pseudoStack.Push(8);
        Assert.AreEqual(3, pseudoStack.StackCount());
    }

    [Test]
    public void TestPop()
    {
        var pseudoStack = new PseudoStack<int>(3);
        
        pseudoStack.Push(1);
        pseudoStack.Push(2);
        pseudoStack.Push(3);
        pseudoStack.Push(4);
        pseudoStack.Push(5);
        pseudoStack.Push(6);
        pseudoStack.Push(7);
        pseudoStack.Push(8);
        Assert.AreEqual(3, pseudoStack.StackCount());
        
        Assert.AreEqual(8, pseudoStack.Pop());
        Assert.AreEqual(7, pseudoStack.Pop());
        Assert.AreEqual(6, pseudoStack.Pop());
        Assert.AreEqual(5, pseudoStack.Pop());
        Assert.AreEqual(4, pseudoStack.Pop());
        Assert.AreEqual(1, pseudoStack.StackCount());
    }
}