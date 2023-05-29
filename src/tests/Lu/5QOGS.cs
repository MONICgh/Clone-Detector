namespace TreeSerialization;

public class BinaryTree
{
    public TreeNode Root { get; }

    public BinaryTree(TreeNode root)
    {
        Root = root;
    }

    public string ToSerializeString()
    {
        Stack<TreeNode?> stack = new Stack<TreeNode?>();
        stack.Push(Root);

        List<string> nodeStrings = new List<string>();
        while (stack.Count > 0)
        {
            TreeNode? node = stack.Pop();

            if (node == null)
            {
                nodeStrings.Add("*");
            }
            else
            {
                nodeStrings.Add(node.Value.ToString());
                stack.Push(node.Right);
                stack.Push(node.Left);
            }
        }

        return string.Join(",", nodeStrings);
    }

    public static BinaryTree FromSerializeString(string serialization)
    {
        return new BinaryTree(DeserializeNode(serialization));
    }

    private static int _t;
    
    private static TreeNode? DeserializeNode(string? serialization)
    {
        if (serialization == null)
        {
            return null;
        }

        _t = 0;
        var nodeStrings = serialization.Split(",");
        return Helper(nodeStrings);
    }
 
    private static TreeNode? Helper(string[] nodeStrings)
    {
        if (nodeStrings[_t] == "*")
        {
            return null;
        }

        var root = new TreeNode(Convert.ToInt32(nodeStrings[_t]));
        _t++;
        root.Left = Helper(nodeStrings);
        _t++;
        root.Right = Helper(nodeStrings);
        return root;
    }
}
