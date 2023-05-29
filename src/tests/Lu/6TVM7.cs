using System.Text;

namespace TreeSerialization;

public class Node
{
    public Node? Left { get; }
    public Node? Right { get; }
    public int Num { get; }

    public Node(int num)
    {
        Num = num;
        Left = null;
        Right = null;
    }

    public Node(Node left, int num, Node right)
    {
        Num = num;
        Left = left;
        Right = right;
    }

    public string Serialize()
    {
        var sb = new StringBuilder();
        if (Left != null)
        {
            sb.Append("(" + Left.Serialize() + ")");
        }
        sb.Append(Num);
        if (Right != null)
        {
            sb.Append("(" + Right.Serialize() + ")");
        }

        return sb.ToString();
    }

    public Node(string s)
    {
        var bal = 0;
        var j = -1;
        var k = -1;
        Left = null;
        Right = null;
        for (var i = 0; i < s.Length; ++i)
        {
            if (s[i] == '(')
            {
                bal += 1;
                if (bal == 1 && j != -1)
                {
                    k = i;
                    Num = int.Parse(s.Substring(j + 1, i - j - 1));
                }
            } else if (s[i] == ')')
            {
                bal -= 1;
                if (bal == 0 && j == -1)
                {
                    j = i;
                    Left = new Node(s.Substring(1, i - 1));
                } else if (bal == 0 && k != -1)
                {
                    Right = new Node(s.Substring(k + 1, i - k));
                }
            }
        }
    }
}
