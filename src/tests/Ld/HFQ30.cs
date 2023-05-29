using LinkedListTask;
using NUnit.Framework;
using System;
using System.Xml.Schema;

namespace Tests.LinkedListTaskTests
{   
    [TestFixture]
    public class LinkedListTaskTests
    {
        private static MyLinkedList CreateRandom()
        {
            var list = new MyLinkedList();
            var rng = new Random();
            var len = rng.Next() % 1000 + 1;
            for (var i = 0; i < len; ++i)
            {
                list.Insert(rng.Next());
            }

            return list;
        }

        [Test]
        public void CheckTest()
        {
            var n1 = new Node(1);
            var n2 = new Node(2);
            var n3 = new Node(3);
            var n4 = new Node(4);
            var n5 = new Node(5);
            var n6 = new Node(6);

            n1.next = n2;
            n2.next = n3;
            n3.next = n4;
            n4.next = n5;
            n5.next = n6;

            var list1 = new MyLinkedList();
            var list2 = new MyLinkedList();
            list1.Insert(10);
            list2.Insert(20);
            list2.Insert(30);
            list2.Insert(40);

            list1.End().next = n1;
            list2.End().next = n4;

            Assert.True(TaskSolver.Solve(list1, list2) == n4);
        }


        [Test]
        public void BigRandomIntersectTest()
        {
            var solver = new TaskSolver();
            for (var it = 0; it < 100; ++it)
            {
                var head1 = CreateRandom();
                var head2 = CreateRandom();
                var tail = CreateRandom();
                head1.End().next = tail.Begin();
                head2.End().next = tail.Begin();
                Assert.True(TaskSolver.Solve(head1, head2) == tail.Begin());
            }
        }
        
        [Test]
        public void NoIntersectionTest()
        {
            var solver = new TaskSolver();
            for (var it = 0; it < 100; ++it)
            {
                var head1 = CreateRandom();
                var head2 = CreateRandom();
                Assert.True(TaskSolver.Solve(head1, head2) == null);
            }
        }
    }
}