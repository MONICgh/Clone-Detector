using System.Text;

namespace SerializeTree
{
    public class Vertex
    {
        public Vertex LeftSon { get; }
        public Vertex RightSon { get; }
        public int Number { get; }

        public Vertex(Vertex leftSon, Vertex rightSon, int number)
        {
            LeftSon = leftSon;
            RightSon = rightSon;
            Number = number;
        }

        public static string Serialize(Vertex node)
        {
            if (node == null)
            {
                return "";
            }
            StringBuilder sb = new();
            sb.Append('(');
            sb.Append(Serialize(node.LeftSon));
            sb.Append(')');
            sb.Append(string.Format("[{0}]", node.Number));
            sb.Append(Serialize(node.RightSon));
            return sb.ToString();
        }

        public static Vertex Deserialize(string s)
        {
            if (s == "")
            {
                return null;
            }

            int balance = 0;
            int position = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    balance++;
                }
                if (s[i] == ')')
                {
                    balance--;
                }
                if (balance == 0)
                {
                    position = i;
                    break;
                }
            }

            int closeBracket = s.IndexOf(']', position);
            return new Vertex(Deserialize(s[1..position]), Deserialize(s[(closeBracket + 1)..]),
                                int.Parse(s[(position + 2)..closeBracket]));
        }
    }
}