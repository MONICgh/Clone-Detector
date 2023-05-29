using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Lab6
{
    [TestClass]
    public class LakeTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Lake lake1 = new Lake(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 });
            Lake lake2 = new Lake(new List<int> { 13, 23, 1, -8, 4, 9 });

            List<int> expected1 = new List<int> { 1, 3, 5, 7, 8, 6, 4, 2 };
            List<int> expected2 = new List<int> { 13, 1, 4, 9, -8, 23 };

            int i1 = 0;
            int i2 = 0;

            foreach (int stone in lake1)
            {
                Assert.AreEqual(expected1[i1++], stone);
            }

            foreach (int stone in lake2)
            {
                Assert.AreEqual(expected2[i2++], stone);
            }
        }
    }

    [TestClass]
    public class PerconComparerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Person p1 = new Person("Lucio", 32);
            Person p2 = new Person("Esmeralda", 45);
            Person p3 = new Person("Micky", 74);

            var list1 = (new List<Person> { p1, p2, p3 });
            var list2 = (new List<Person> { p3, p2, p1 });

            list1.Sort(new NameComparer());
            list2.Sort(new AgeComparer());

            var expected1 = new List<Person> { p1, p3, p2 };
            var expected2 = new List<Person> { p1, p2, p3 };

            foreach (var i in list1) Console.WriteLine(i.Name);
            foreach (var i in list2) Console.WriteLine(i.Name);

            CollectionAssert.AreEqual(expected1, list1);
            CollectionAssert.AreEqual(expected2, list2);
        }
    }

    [TestClass]
    public class MyLinkedListTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            MyLinkedList<int> ints = new MyLinkedList<int>();

            ints.Add(1);
            ints.Add(2);
            Assert.AreEqual(2, ints.Count);
            ints.Add(1);
            ints.Add(3);
            Assert.AreEqual(4, ints.Count);

            var expected = new List<int> { 1, 2, 1, 3 };
            int i = 0;
            foreach (var n in ints)
            {
                Console.WriteLine("{0}, {1}", expected[i], n);
                Assert.AreEqual(expected[i++], n);
            }

            ints.Remove(1);
            expected.Remove(1);
            i = 0;
            foreach (var n in ints)
            {
                Assert.AreEqual(expected[i++], n);
            }
        }
    }
}
