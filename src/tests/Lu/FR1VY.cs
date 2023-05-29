using System.Text;

namespace Task3;

public class TreeNode
{
    private int _value;
    private TreeNode? _left = null;
    private TreeNode? _right = null;
    
    public TreeNode(int value)
    {
        _value = value;
    }

    public TreeNode(int value, TreeNode left, TreeNode right)
    {
        _value = value;
        _left = left;
        _right = right;
    }

    public string Serialize()
    {
        if (_left == null || _right == null)
        {
            return _value.ToString();
        }

        return new StringBuilder().Append(_value)
            .Append("(").Append(_left.Serialize()).Append(")(")
            .Append(_right.Serialize()).Append(")").ToString();
    }

    public static TreeNode Deserialize(string s)
    {
        int startLeft = -1;
        int startRight = -1;
        int balance = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(' && balance == 0)
            {
                if (startLeft == -1)
                    startLeft = i;
                else
                    startRight = i;
            }

            if (s[i] == '(')
                balance++;
            if (s[i] == ')')
                balance--;
        }
        
        if (startLeft == -1)
        {
            return new TreeNode(int.Parse(s));
        }

        return new TreeNode(int.Parse(s.Substring(0, startLeft)),
            Deserialize(s.Substring(startLeft + 1, startRight - startLeft - 2)),
            Deserialize(s.Substring(startRight + 1, s.Length - startRight - 2)));
    }

    public override bool Equals(object? obj)
    {
        if (obj is not TreeNode other)
        {
            return false;
        }

        if (_value != other._value)
        {
            return false;
        }

        if ((_left != null && other._left == null) || (_left == null && other._left != null))
        {
            return false;
        }
        if ((_right != null && other._right == null) || (_right == null && other._right != null))
        {
            return false;
        }

        if (_left != null && other._left != null && !_left.Equals(other._left))
        {
            return false;
        }
        
        if (_right != null && other._right != null && !_right.Equals(other._right))
        {
            return false;
        }

        return true;
    }
}