using System;
using NUnit.Framework;
using MyLinkedList;
using System.Collections.Generic;
using System.Linq;

namespace Tests.LinkedListTests
{   
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void CountTest()
        {
            var linkedList = new MyLinkedList<int>();
            Assert.True(linkedList.Count == 0);
            for (var i = 1; i <= 5; ++i)
            {
                linkedList.Push(i);
                Assert.True(linkedList.Count == i);
            }
            for (var i = 1; i <= 5; ++i)
            {
                linkedList.Erase(i);
                linkedList.Erase(10);
                Assert.True(linkedList.Count == 5 - i);
            }
        }

        [Test]
        public void PushTest()
        { var linkedList = new MyLinkedList<int>();
            var list = new List<int>();
            for (var i = 1; i <= 1000; ++i)
            {
                linkedList.Push(i);
                list.Add(i);
                Assert.True(list.SequenceEqual(linkedList.ToList()));
            }
        }

        [Test]
        public void EraseTest()
        {
            var linkedList = new MyLinkedList<int>();
            var list = new List<int>();
            for (var i = 1; i <= 1000; ++i)
            {
                linkedList.Push(i);
                list.Add(i);
            }
            for (var i = 1; i <= 1000; ++i)
            {
                linkedList.Push(i);
                list.Add(i);
            }
            for (var i = 1; i <= 1000; ++i)
            {
                linkedList.Erase(i);
                list.Remove(i);
                Assert.True(list.SequenceEqual(linkedList.ToList()));
            }
            for (var i = 1; i <= 1000; ++i)
            {
                linkedList.Erase(i);
                list.Remove(i);
                Assert.True(list.SequenceEqual(linkedList.ToList()));
            }
        }
    }
}