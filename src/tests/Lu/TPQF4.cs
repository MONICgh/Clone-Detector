using TreeSerialization;

var tree = new Node(
    new Node(2), 
    1, 
    new Node(
        new Node(4), 
        3, 
        new Node(5)));

var s = tree.Serialize();
Console.WriteLine(s);
var ntree = new Node(s);
var ns = ntree.Serialize();
Console.WriteLine(s);
