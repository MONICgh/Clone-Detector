using NUnit.Framework;
using Lake;
using System.Collections.Generic;

namespace Tests.LakeTests
{
    [TestFixture]
    public class LakeTests
    {
        [Test]
        public void Test1()
        {
            var lake = new Lake<int>(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 });
            var need = new List<int> { 1, 3, 5, 7, 8, 6, 4, 2 };
            var it = 0;
            foreach (var x in lake)
            {
                Assert.True(it < need.Count);
                Assert.True(x == need[it]);
                it += 1;
            }

            Assert.True(it == need.Count);
        }
        
        [Test]
        public void Test2()
        {
            var lake = new Lake<int>(new List<int> { 13, 23, 1, -8, 4, 9 });
            var need = new List<int> { 13, 1, 4, 9, -8, 23 };
            var it = 0;
            foreach (var x in lake)
            {
                Assert.True(it < need.Count);
                Assert.True(x == need[it]);
                it += 1;
            }

            Assert.True(it == need.Count);
        }
    }
}