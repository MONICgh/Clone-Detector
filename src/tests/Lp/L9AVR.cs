using System.Collections.Generic;
using BusRoutes;
using NUnit.Framework;

namespace Tests.BusRoutesTests
{
    [TestFixture]
    public class Tests
    {
        private Solver solver = new Solver();
        
        [Test]
        public void Test1()
        {
            Assert.True(solver.Solve(new List<int[]> {new int[]{1, 2, 7}, new int[]{3, 6, 7}}, 1, 6) == 2);
        }
        
        [Test]
        public void Test2()
        {
            Assert.True(solver.Solve(new List<int[]> { 
                new int[] { 7, 12 }, 
                new int[] { 4, 5, 15 }, 
                new int[] { 6 }, 
                new int[] { 15, 19 },
                new int[] { 9, 12, 13}
            }, 15, 12) == -1);
        }
    }
}