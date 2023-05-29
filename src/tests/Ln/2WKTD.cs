using NUnit.Framework;
using System.Collections.Generic;
using RainWaterSolveTool;

namespace Tests.RainWaterTests
{
    [TestFixture]
    public class RainWaterTests
    {
        [Test]
        public void Sample1()
        {
            var heights = new List<int> { 0,1,0,2,1,0,1,3,2,1,2,1 };
            var solver = new RainWaterSolver();
            Assert.True(solver.Solve(heights) == 6);
        }

        [Test]
        public void Sample2()
        {
            var heights = new List<int> { 4,2,0,3,2,5 };
            var solver = new RainWaterSolver();
            Assert.True(solver.Solve(heights) == 9);
        }
        
        [Test]
        public void Sample3()
        {
            var heights = new List<int> { 2, 0, 0, 2 };
            var solver = new RainWaterSolver();
            Assert.True(solver.Solve(heights) == 4);
        }
    }
}