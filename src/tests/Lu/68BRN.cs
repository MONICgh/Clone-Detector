using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Application
{
    class Node
    {
        public Node? Left = null;
        public Node? Right = null;
        public int Value = 0;
        public Node(int value, Node? left = null, Node? right = null)
        {
            Value = value;
            Left = left;
            Right = right;
        }
        public override string ToString()
        {
            return $"({Value},{Left},{Right})";
        }
    }

    class Tree
    {
        public Node? Root;
        public Tree(Node? root = null)
        {
            Root = root;
        }

        public override string ToString()
        {
            return Root.ToString();
        }
    }

    class Task3
    {
        static string SaveTree(Tree tree)
        {
            return tree.ToString();
        }

        static Tuple<Node, int> LoadNode(StringBuilder s, int i = 0)
        {
            if (s[i] != '(') throw new Exception("wrong input");
            i += 1;
            int j = 0;
            while (s[i+j] != ',')
            {
                j++;
            }
            int value = Int32.Parse(s.ToString(i, j));
            Node left = null;
            Node right = null;
            i += j + 1;
            if (s[i] != ',')
            {
                var res = LoadNode(s, i);
                left = res.Item1;
                i = res.Item2;
                if (s[i] != ',') throw new Exception("wrong input");
            }
            i++;
            if (s[i] != ')')
            {
                var res = LoadNode(s, i);
                right = res.Item1;
                i = res.Item2;
                if (s[i] != ')') throw new Exception("wrong input");
            }
            i++;
            return Tuple.Create(new Node(value, left, right), i);
        }

        static Tree LoadTree(StringBuilder s)
        {
            Node root = LoadNode(s).Item1;
            Tree tree = new Tree(root);
            return tree;
        }

        static void Main()
        {
            Node root = new Node(1, new Node(2), new Node(3, new Node(4), new Node(5)));
            Tree tree = new Tree(root);
            var treeSaved = SaveTree(tree);
            Console.WriteLine(treeSaved);
            var tree_copy = LoadTree(new StringBuilder(treeSaved));
            var r = tree_copy.Root;
            if (!(r.Value == 1 &&
                r.Left.Value == 2 &&
                    r.Left.Left == null &&
                    r.Left.Right == null &&
                r.Right.Value == 3 &&
                    r.Right.Left.Value == 4 &&
                        r.Right.Left.Left == null &&
                        r.Right.Left.Right == null &&
                    r.Right.Right.Value == 5 &&
                        r.Right.Right.Left == null &&
                        r.Right.Right.Right == null)) throw new Exception("wrong load");
            var treeCopySaved = SaveTree(tree_copy);
            if (treeSaved != treeCopySaved) throw new Exception("wrong save");
        }
    }
}
