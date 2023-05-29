using NUnit.Framework;

namespace HW_09.TreeSer;

[TestFixture]
public class TestTree
{
    [Test]
    public void Check()
    {
        var tree = new Node(
            1,
            new Node(2),
            new Node(
                3,
                new Node(4),
                new Node(5)));
        Assert.AreEqual(tree, Node.FromString(tree.ToString()));
    }
}
