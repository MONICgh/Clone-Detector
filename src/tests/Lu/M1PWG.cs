using System.Diagnostics;
using Task3;

var tree = new TreeNode(1,
    new TreeNode(2), new TreeNode(3,
        new TreeNode(4), new TreeNode(5)));
        
var serialized = tree.Serialize();
var deserializedTree = TreeNode.Deserialize(serialized);

Debug.Assert(tree.Equals(deserializedTree));

Console.WriteLine("All is Okay!");