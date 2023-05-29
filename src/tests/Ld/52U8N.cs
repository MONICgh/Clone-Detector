using System;
using PalindromSolver;
using Xunit;

namespace UnitTests
{
    public class PalindromeTests
    {
        [Fact]
        private void Test()
        {
            Assert.Equal(new Tuple<int, int>(3, 9), PalindromeSolver.Solve(4884));
            Assert.Equal(new Tuple<int, int>(1, 0), PalindromeSolver.Solve(1));
            Assert.Equal(new Tuple<int, int>(5, 2), PalindromeSolver.Solve(11));
        }
    }
}
