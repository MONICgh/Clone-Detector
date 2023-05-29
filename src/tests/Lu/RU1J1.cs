namespace HW_09.TreeSer;

public class Node
{
    protected bool Equals(Node? other)
    {
        if (other == null)
            return false;
        var left = (Left == null && other.Left == null) || Left != null && Left.Equals(other.Left);
        var right = (Right == null && other.Right == null) || Right != null && Right.Equals(other.Right);
        return Value == other.Value && left && right;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        return obj.GetType() == GetType() && Equals((Node)obj);
    }

    private Node? Left { get; }
    private Node? Right { get; }
    private int Value { get; }
    public Node(int value, Node? left, Node? right)
    {
        Left = left;
        Right = right;
        Value = value;
    }

    public override string ToString()
    {
        var leftNode = Left == null ? "nil" : Left.ToString();
        var rightNode = Right == null ? "nil" : Right.ToString();
        return "Node(" + Value + "|" + leftNode + "|" + rightNode + ")";
    }

    public static Node? FromString(string str)
    {
        if (str == "nil")
            return null;
        const string expectedPrefix = "Node(";
        const string expectedSuffix = ")";
        if (!str.StartsWith(expectedPrefix) || !str.EndsWith(expectedSuffix))
        {
            throw new ArgumentException("Wrong format str");
        }
        str = str[expectedPrefix.Length..^expectedSuffix.Length];
        var symbolPos = str.IndexOf('|');

        var value = int.Parse(str[..symbolPos]);
        str = str[(symbolPos + 1)..];
        var (leftStr, rightStr) = ExtractSubNodes(str);

        var left = FromString(leftStr);
        var right = FromString(rightStr);
        return new Node(value, left, right);
    }

    private static (string, string) ExtractSubNodes(string data)
    {
        var balance = 0;
        var sepIndex = -1;
        for (var i = 0; i < data.Length; ++i)
        {
            if (data[i] == '(')
                balance++;
            if (data[i] == ')')
                balance--;
            if (balance != 0)
                continue;
            if (data[i] != '|')
                continue;
            sepIndex = i;
            break;
        }
        if (sepIndex == -1)
        {
            throw new ArgumentException("Wrong format str");
        }
        return (data[..sepIndex], data[(sepIndex + 1)..]);
    }

    public Node(int value)
    {
        Left = null;
        Right = null;
        Value = value;
    }
}
