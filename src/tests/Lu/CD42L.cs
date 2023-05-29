using TreeSerialization;

//         20
//        /    
//       8     
//      /  \
//     4    12 
//         /  \
//        10  14

var node14 = new TreeNode(14);
var node10 = new TreeNode(10);
var node12 = new TreeNode(12, node10, node14);
var node4 = new TreeNode(4);
var node8 = new TreeNode(8, node4, node12);
var node20 = new TreeNode(20, node8);

var tree = new BinaryTree(node20);

Console.WriteLine(tree.ToSerializeString());

var deserializedTree = BinaryTree.FromSerializeString(tree.ToSerializeString());
Console.WriteLine(deserializedTree.ToSerializeString());
