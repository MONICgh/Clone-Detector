using System.Collections.Generic;
using HW01.CollectWater;
using Xunit;

namespace UnitTests.WaterCollectorTests
{
    public class Tests
    {
        [Fact]
        public void Test1()
        {
            var numbers = new List<int> { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            Assert.Equal(6, WaterCollectorSolver.Solve(numbers));
        }


        [Fact]
        public void Test2()
        {
            var numbers = new List<int> { 4,2,0,3,2,5 };
            Assert.Equal(9, WaterCollectorSolver.Solve(numbers));
        }
    }
}
