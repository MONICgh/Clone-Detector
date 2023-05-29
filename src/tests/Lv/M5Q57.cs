using System.Linq;
using MaxMin;
using NUnit.Framework;

namespace Tests.MaxMinTests
{   
    [TestFixture]
    public class MaxMinTests
    {
        private readonly Solver solver = new Solver();
        
        [Test]
        public void Test1()
        {
            var res = solver.MaxMin(12340);
            Assert.True(res.SequenceEqual(new ulong[] { 42310, 10342 }));
        }
        
        [Test]
        public void Test2()
        {
            var res = solver.MaxMin(98761);
            Assert.True(res.SequenceEqual(new ulong[] { 98761, 18769 }));
        }
        
        [Test]
        public void Test3()
        {
            var res = solver.MaxMin(9000);
            Assert.True(res.SequenceEqual(new ulong[] { 9000, 9000 }));
        }
        
        [Test]
        public void Test4()
        {
            var res = solver.MaxMin(11321);
            Assert.True(res.SequenceEqual(new ulong[] { 31121, 11123 }));
        }
    }
}