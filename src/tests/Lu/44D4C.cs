using System.Security.Cryptography;
using NUnit.Framework;

namespace BinaryTree;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        BinaryNode root = new BinaryNode(1);
        BinaryNode left = new BinaryNode(2);
        BinaryNode right = new BinaryNode(3);
        BinaryNode rightLeft = new BinaryNode(4);
        BinaryNode rightRight = new BinaryNode(5);
        root.Left = left;
        root.Right = right;
        right.Left = rightLeft;
        right.Right = rightRight;

        var serialized = root.Serialize();
        
        Assert.AreEqual("1,2,3,,,4,5", serialized);
        Assert.AreEqual(root, new BinaryNode(serialized));
    }
}