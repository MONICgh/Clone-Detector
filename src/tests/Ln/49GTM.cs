using NUnit.Framework;
using StructInheritance;

namespace Tests.StructInheritanceTests
{   
    [TestFixture]
    public class StructInheritanceTests
    {
        [Test]
        public void Test()
        {
            AdvancedCalculator calc;
            Assert.True(calc.Sum(1, 2) == 3);
            Assert.True(calc.Product(5, 3) == 15);
        }
    }
}