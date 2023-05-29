using System;
using DiceRollSolveTool;
using NUnit.Framework;

namespace Tests.DiceRollTests
{
    [TestFixture]
    public class DiceRollTests
    {
        [Test]
        public void SampleTests()
        {
            var solver = new DiceRollSolver();
            Assert.True(solver.Solve(2, 6) == 5);
            Assert.True(solver.Solve(2, 2) == 1);
            Assert.True(solver.Solve(1, 3) == 1);
            Assert.True(solver.Solve(2, 5) == 4);
            Assert.True(solver.Solve(3, 4) == 3);
            Assert.True(solver.Solve(4, 18) == 80);
            Assert.True(solver.Solve(6, 20) == 4221);
        }
        [Test]
        public void RandomTests()
        {
            const int N = 1000;
            var rng = new Random();
            var solver = new DiceRollSolver();
            for (var it = 0; it < N; ++it)
            {
                var n = rng.Next(1, 6);
                var sum = rng.Next(n, 6 * n);
                Assert.True(solver.Solve(n, sum) == solver.NaiveSolve(n, sum));
            }
        }

        [Test]
        public void OutOfBoundsTests()
        {
            const int N = 100;
            var rng = new Random();
            var solver = new DiceRollSolver();
            for (var it = 0; it < N; ++it)
            {
                var n = rng.Next(1, 6);
                var sumTooSmall = rng.Next(-100, n - 1);
                var sumTooBig = rng.Next(6 * n + 1, 100);
                Assert.True(solver.Solve(n, sumTooSmall) == 0);
                Assert.True(solver.Solve(n, sumTooBig) == 0);
            }
        }
    }
}