using Deckchairs;
using NUnit.Framework;

namespace Tests.DeckchairsTests
{   
    [TestFixture]
    public class DeckchairsTests
    {
        private DeckchairsSolver solver = new DeckchairsSolver();
        
        [Test]
        public void Test1()
        {
            Assert.True(solver.Solve("10001") == 1);
        }
        
        [Test]
        public void Test2()
        {
            Assert.True(solver.Solve("00101") == 1);
        }
        
        [Test]
        public void Test3()
        {
            Assert.True(solver.Solve("0") == 1);
        }
        
        [Test]
        public void Test4()
        {
            Assert.True(solver.Solve("000") == 2);
        }
    }
}