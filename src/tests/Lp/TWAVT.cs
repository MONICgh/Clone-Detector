using NUnit.Framework;
using AllPermutations;

namespace Tests.PermutationsTests
{
    [TestFixture]
    public class Tests
    {
        private Solver solver = new Solver();
        
        [Test]
        public void Test1()
        {
            Assert.True(solver.Permutations("AB") == "AB BA");
        }
        
        [Test]
        public void Test2()
        {
            Assert.True(solver.Permutations("CD") == "CD DC");
        }
        
        [Test]
        public void Test3()
        {
            Assert.True(solver.Permutations("EF") == "EF FE");
        }
        
        [Test]
        public void Test4()
        {
            Assert.True(solver.Permutations("NOT") == "NOT NTO ONT OTN TNO TON");
        }
        
        [Test]
        public void Test5()
        {
            Assert.True(solver.Permutations("RAM") == "AMR ARM MAR MRA RAM RMA");
        }
        
        [Test]
        public void Test6()
        {
            Assert.True(solver.Permutations("YAW") == "AWY AYW WAY WYA YAW YWA");
        }
    }
}