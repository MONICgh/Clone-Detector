using System;
using System.Collections.Generic;
using HW_03;
using Xunit;

namespace UnitTests
{
    public class TwoListTests
    {
        [Fact]
        public void Test1()
        {
            var common = new Node<int>(1, new Node<int>(2, new Node<int>(3)));
            var list1 = new Node<int>(4, common);
            var list2 = new Node<int>(5, common);

            Assert.Equal(1, TwoListsSolver.GetFirstMatch(list1, list2).Value);
        }
        
        [Fact]
        public void Test2()
        {
            var list1 = new Node<int>(4);
            var list2 = new Node<int>(5);

            Assert.Equal(null, TwoListsSolver.GetFirstMatch(list1, list2));
        }
    }
}
