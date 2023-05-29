namespace Tests;
using LinkedLists;

public class Tests
{
    [Test]
    public void Test1()
    {
        var n1 = new Node<int>(4);
        var n2 = new Node<int>(3);
        var n3 = new Node<int>(2);
        var n4 = new Node<int>(1);
        n2.next = n1;
        n3.next = n2;
        n4.next = n3;

        var n5 = new Node<int>(5);
        n5.next = n3;

        var list1 = new SingleLinkedList<int>(n4);
        var list2 = new SingleLinkedList<int>(n5);

        var finder = new FirstCommonNodeFinder<int>();
        
        Assert.True(ReferenceEquals(n3, finder.Find(list1, list2)));
    }
    
    [Test]
    public void Test2()
    {
        var n1 = new Node<int>(4);
        var n2 = new Node<int>(3);
        var n3 = new Node<int>(2);
        var n4 = new Node<int>(1);
        n2.next = n1;
        n3.next = n2;
        n4.next = n3;

        var list1 = new SingleLinkedList<int>(n4);
        var list2 = new SingleLinkedList<int>();

        var finder = new FirstCommonNodeFinder<int>();
        
        Assert.True(ReferenceEquals(null, finder.Find(list1, list2)));
    }
    
    [Test]
    public void Test3()
    {
        var list1 = new SingleLinkedList<int>();
        var list2 = new SingleLinkedList<int>();

        var finder = new FirstCommonNodeFinder<int>();
        
        Assert.True(ReferenceEquals(null, finder.Find(list1, list2)));
    }
    
    [Test]
    public void Test4()
    {
        var n = new Node<int>(1);

        var list1 = new SingleLinkedList<int>(n);
        var list2 = new SingleLinkedList<int>(n);

        var finder = new FirstCommonNodeFinder<int>();
        
        Assert.True(ReferenceEquals(n, finder.Find(list1, list2)));
    }
}