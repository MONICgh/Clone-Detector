using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab7
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<ObjectWithName> list = new List<ObjectWithName> {
                new ObjectWithName("Foo"),
                new ObjectWithName("Bar"),
                new ObjectWithName("Baz"),
                new ObjectWithName("Hello"),
                new ObjectWithName("World!") };

            Assert.IsTrue("Hello World!".Equals(LinqQueries.Query1(list, ' ')));
        }

        [TestMethod]
        public void TestMethod2()
        {
            List<ObjectWithName> list = new List<ObjectWithName> {
                new ObjectWithName("Every"),
                new ObjectWithName("one"),
                new ObjectWithName("I"),
                new ObjectWithName("know"),
                new ObjectWithName("are"),
                new ObjectWithName("here"),
                new ObjectWithName("(At least if I'm not forgetting anyone)") };

            var expected = LinqQueries.Query2(list);

            string result = String.Join("", from e in expected select e.Name);
            Assert.AreEqual("Everyoneknow(At least if I'm not forgetting anyone)", result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string a = "��� ��� �� ����������: ������, ������ � �����, � ����� ��� - ������ �����";

            LinqQueries.Query3(a);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("AFTER", "�����");
            dict.Add("DOG", "������");
            dict.Add("EATS", "���");
            dict.Add("LUNCH", "�����");
            dict.Add("MUCH", "�����");
            dict.Add("THIS", "���");
            dict.Add("TOO", "�������");
            dict.Add("VEGETABLES", "������");
            string a = "This dog eats too much vegetables after lunch";

            List<string> n = LinqQueries.Translator(dict, a, 3);

            Assert.AreEqual(3, n.Count);
            Assert.IsTrue("��� ������ ���".Equals(n[0]));
            Assert.IsTrue("������� ����� ������".Equals(n[1]));
            Assert.IsTrue("����� �����".Equals(n[2]));
        }
        [TestMethod]
        public void TestMethod5()
        {
            string[] examples = new string[4] { "��� ������� ������� �������� � ����",
                                               "���� �������� ����� ���",
                                               "��������� ���� ������� ������",
                                               "a b c d e" };
            int[] n = new int[4] { 16, 8, 15, 2 };

            string[][] expected = new string[4][] { new string[] { "��� �������", "������� ��������", "� ����" },
                                                    new string[] { "����", "��������", "�����", "���" },
                                                    new string[] { "��������� ����", "������� ������" },
                                                    new string[] { "a", "b", "c", "d", "e" }};

            for (int i = 0; i < 4; ++i)
            {
                var res = LinqQueries.bucketize(examples[i], n[i]);
                for (int j = 0; j < expected[i].Length; ++j)
                {
                    Assert.IsTrue(res[j].Equals(expected[i][j]));
                }
            }
    }
}
}
