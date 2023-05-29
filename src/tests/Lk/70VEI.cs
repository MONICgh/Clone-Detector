using System;
using Integral;
using NUnit.Framework;

namespace Tests.IntegralTests
{   

    [TestFixture]
    public class Tests
    {   
        IntegralCalculator solver = new IntegralCalculator();

        private bool Compare(double a, double b, double eps = 1e-4)
        {
            return Math.Abs(a - b) <= eps;
        }
        
        [Test]
        public void TestLinear()
        {
            var f = new Function(x => 2 * x);
            var F = new Function(x => x * x);
            Assert.True(Compare(solver.Integrate(f, 0, 10), F(10) - F(0)));
            Assert.True(Compare(solver.Integrate(f, -5, 5), F(5) - F(-5)));
        }
        
        [Test]
        public void TestQuadratic()
        {
            var f = new Function(x => x * x);
            var F = new Function(x => x * x * x / 3);
            Assert.True(Compare(solver.Integrate(f, 0, 10), F(10) - F(0)));
            Assert.True(Compare(solver.Integrate(f, -5, 5), F(5) - F(-5)));
        }
        
        [Test]
        public void TestSin()
        {
            var f = new Function(Math.Sin);
            var F = new Function(x => -Math.Cos(x));
            Assert.True(Compare(solver.Integrate(f, 0, 10), F(10) - F(0)));
            Assert.True(Compare(solver.Integrate(f, -5, 5), F(5) - F(-5)));
        }
    }
}