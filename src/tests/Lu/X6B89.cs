using System;
using System.Diagnostics;


namespace TreeSerialization
{
    class Program
    {
        class BinaryTree
        {
            public int[] prev { get; private set; }
            public BinaryTree(int[] prev)
            {
                this.prev = prev;
            }
        }
        static string Serialize(BinaryTree tree)  // формат: единицы в количестве разрядов чисел (условно это 8), затем каждое число в бинарном виде.
        {
            string serialized = "";
            var elem_size = 8;

            for (int i = 0; i < elem_size; i++)
                serialized += '1';
            serialized += '0';

            foreach (var prev in tree.prev)
            {
                Int32 BinaryCode = Convert.ToInt32(Convert.ToString(prev, 2));
                var code = BinaryCode.ToString($"D{elem_size}");
                serialized += code;
            }

            return serialized;
        }

        static BinaryTree Deserialize(string tree)
        {
            int elem_size = 0;

            while (tree[elem_size] == '1')
                elem_size++;

            int n = (tree.Length - 1 - elem_size) / elem_size;
            var prev = new int[n];
            tree = tree.Substring(elem_size + 1);

            for (int i = 0; i < n; i++)
            {
                string leaf = tree.Substring(i * elem_size, elem_size);
                int pre = 0;
                foreach (var c in leaf)
                {
                    pre = pre * 2 + (c - '0');
                }
                prev[i] = pre;
            }

            return new BinaryTree(prev);
        }

        static void Test(int[] prev)
        {
            var tree = new BinaryTree(prev);
            var ser_tree = Serialize(tree);

            Console.WriteLine(ser_tree);
            var des_tree = Deserialize(ser_tree);

            for (int i = 0; i < prev.Length; i++)
                Debug.Assert(prev[i] == des_tree.prev[i]);
        }

        static void Main(string[] args)
        {
            Test(new int[] { 9, 11, 30 });
            Test(new int[] { 0, 0, 0 });
            Test(new int[] { 3, 2, 1, 0, 5 });
        }
    }
}
