using NUnit.Framework;
using FractionSimplifier;

namespace Tests.FractionSimplifierTests
{
    [TestFixture]
    public class FractionSimplifierTests
    {
        [Test]
        public void Tests()
        {
            var solver = new Solver();
            Assert.True(solver.Simplify("4/6") == "2/3");
            Assert.True(solver.Simplify("10/11") == "10/11");
            Assert.True(solver.Simplify("100/400") == "1/4");
            Assert.True(solver.Simplify("8/4") == "2");
        }
    }
}