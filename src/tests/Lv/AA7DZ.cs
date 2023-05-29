using System.Linq;
using NUnit.Framework;
using ThreeSum;

namespace Tests.ThreeSumTests
{   
    [TestFixture]
    public class ThreeSumTests
    {
        private readonly Solver solver = new Solver();
        
        [Test]
        public void Test1()
        {
            var res = solver.ThreeSum(new[] { 0, 1, -1, -1, 2 });
            Assert.True(res.SequenceEqual(new[] { (-1, -1, 2), (0, 1, -1)}));
        }
        
        [Test]
        public void Test2()
        {
            var res = solver.ThreeSum(new[] { 0, 0, 0, 5, -5 });
            Assert.True(res.SequenceEqual(new[] { (0, 0, 0), (0, 5, -5)}));
        }
        
        [Test]
        public void Test3()
        {
            var res = solver.ThreeSum(new[] { 1, 2, 3 });
            Assert.True(res.SequenceEqual(new (int, int, int)[] {}));
        }
        
        [Test]
        public void Test4()
        {
            var res = solver.ThreeSum(new int[1]);
            Assert.True(res.SequenceEqual(new (int, int, int)[] {}));
        }
    }
}