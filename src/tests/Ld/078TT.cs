using HW_03;
using HW03;
using Xunit;

namespace UnitTests
{
    public class SimplifiedFractionTests
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal("2", SimplifiedFractionSolver.Simplify("8/4"));
            Assert.Equal("2/3", SimplifiedFractionSolver.Simplify("4/6"));
            Assert.Equal("10/11", SimplifiedFractionSolver.Simplify("10/11"));
            Assert.Equal("1/4", SimplifiedFractionSolver.Simplify("100/400"));
            
        }
    }
}
