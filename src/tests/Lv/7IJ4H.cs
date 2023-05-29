using System.Linq;
using NUnit.Framework;
using Task2;

namespace Tests.Task2Tests
{   
    [TestFixture]
    public class Task2Tests
    {
        [Test]
        public void Test()
        {
            var solver = new Solver();
            var elem = new string[6];
            elem[0] = "Alex";
            elem[1] = "Bob";
            elem[2] = "Charles";
            elem[3] = "Donald";
            elem[4] = "Ethan";
            elem[5] = "Frank";
            
            Assert.True(solver.Solve(elem).SequenceEqual(elem.Take(5)));
        }
    }
}