using System;

namespace Serialization
{
    public class BinaryTree
    {
        public Int32? Value;
        public BinaryTree Left = null;
        public BinaryTree Right = null;
        public int Count;

        public BinaryTree()
        {
            Count = 0;
        }

        public BinaryTree(Int32 value)
        {
            Value = value;
            Count = 1;
        }
        
        public void Insert(Int32 value)
        {
            if (Value == null)
            {
                Value = value;
                Count++;
            }
            else
            {
                if (value < Value)
                {
                    if (Left == null)
                    {
                        Left = new BinaryTree();
                    }
                    Left.Insert(value);
                }
                else if (value > Value)
                {
                    if (Right == null)
                    {
                        Right = new BinaryTree();
                    }
                    Right.Insert(value);
                }
            }
        }
    }
}