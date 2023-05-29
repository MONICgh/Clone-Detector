using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Serialization
{
    class BinaryTreeSerializer
    {
        private readonly int _lenOfMaxValue;
        private readonly string _format;

        public BinaryTreeSerializer()
        {
            _lenOfMaxValue = Int32.MaxValue.ToString().Length; // 10
            _format = "D" + _lenOfMaxValue.ToString(); // D10
        }

        public void Serialize(FileStream fs, BinaryTree binaryTree)
        {
            var list = new List<Int32>();
            PreOrderAndFillList(binaryTree, list);
            WriteInFile(fs, list);
        }

        public BinaryTree Deserialize(FileStream fs)
        {
            string resultString = GetStringFromFile(fs);
            return GetBinaryTreeFromString(resultString);
        }
        
        private void PreOrderAndFillList(BinaryTree binaryTree, List<Int32> list)
        {
            if (binaryTree.Value == null)
            {
                return;
            }

            Int32 notNullValue = (Int32)binaryTree.Value;
            list.Add(notNullValue);

            if (binaryTree.Left != null) 
                PreOrderAndFillList(binaryTree.Left, list);
            if (binaryTree.Right != null) 
                PreOrderAndFillList(binaryTree.Right, list);
        }

        private void WriteInFile(FileStream fs, List<Int32> list)
        {
            // тут вы используете string, но лучше будет StringBuilder, т.к. в цикле добавляете к строке множество раз (что приведет к многочисленному созданию временных строк в памяти)
            var resultString = "";
            foreach (var value in list)
            {
                resultString += value.ToString(_format);
            }

            using (TextWriter writer = new StreamWriter(fs))
            {
                writer.WriteLine(resultString);
            }
        }

        private string GetStringFromFile(FileStream fs)
        {
            string resultString = "";
            using (TextReader reader = new StreamReader(fs))
            {
                resultString = reader.ReadLine();
            }

            return resultString;
        }

        private BinaryTree GetBinaryTreeFromString(string binaryTreeAsString)
        {
            BinaryTree bt = new BinaryTree();
            for (int i = 0; i < binaryTreeAsString.Length; i += _lenOfMaxValue)
            {
                string node = binaryTreeAsString.Substring(i, _lenOfMaxValue);
                int value = Convert.ToInt32(node);
                bt.Insert(value);
            }

            return bt;
        }
    }
}