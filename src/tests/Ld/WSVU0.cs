using System.Collections.Generic;
using NUnit.Framework;

namespace TwoLinkedLists;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var list1 = new LinkedList<int>();
        list1.AddLast(1);
        list1.AddLast(2);
        list1.AddLast(3);
        list1.AddLast(4);
        list1.AddLast(5);
        
        var list2 = new LinkedList<int>();
        list2.AddLast(1);
        list2.AddLast(2);
        list2.AddLast(3);
        list2.AddLast(4);
        list2.AddLast(5);
        Assert.AreEqual(list1.First.Value, TwoLinkedLists<int>.FindFirstIntersection(list1, list2).Value);
    }
    
    [Test]
    public void Test2()
    {
        var list1 = new LinkedList<int>();
        list1.AddLast(1);
        list1.AddLast(2);
        list1.AddLast(3);
        list1.AddLast(4);
        list1.AddLast(5);
        
        var list2 = new LinkedList<int>();
        list2.AddLast(4);
        list2.AddLast(5);
        Assert.AreEqual(list2.First.Value, TwoLinkedLists<int>.FindFirstIntersection(list1, list2).Value);
    }
    
    [Test]
    public void Test3()
    {
        var list1 = new LinkedList<int>();
        list1.AddLast(1);
        list1.AddLast(2);
        list1.AddLast(3);
        list1.AddLast(4);
        list1.AddLast(5);
        
        var list2 = new LinkedList<int>();
        list2.AddLast(4);
        list2.AddLast(0);
        list2.AddLast(4);
        list2.AddLast(5);
        Assert.AreEqual(4, TwoLinkedLists<int>.FindFirstIntersection(list1, list2).Value);
    }
    
    [Test]
    public void Test4()
    {
        var list1 = new LinkedList<int>();
        list1.AddLast(1);
        list1.AddLast(2);
        list1.AddLast(3);
        list1.AddLast(4);
        list1.AddLast(5);
        
        var list2 = new LinkedList<int>();
        list2.AddLast(4);
        list2.AddLast(0);
        list2.AddLast(4);
        list2.AddLast(8);
        Assert.IsNull(TwoLinkedLists<int>.FindFirstIntersection(list1, list2));
    }
    
    [Test]
    public void Test5()
    {
        var list1 = new LinkedList<int>();
        list1.AddLast(1);
        list1.AddLast(2);
        list1.AddLast(3);
        list1.AddLast(4);
        list1.AddLast(5);
        
        var list2 = new LinkedList<int>();
        Assert.IsNull(TwoLinkedLists<int>.FindFirstIntersection(list1, list2));
    }
    
    [Test]
    public void Test6()
    {
        var list1 = new LinkedList<int>();
        var list2 = new LinkedList<int>();
        Assert.IsNull(TwoLinkedLists<int>.FindFirstIntersection(list1, list2));
    }
}