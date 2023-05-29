using NUnit.Framework;
using Task1;
using System.Collections.Generic;

namespace Tests.Task1Tests
{   
    [TestFixture]
    public class Task1Tests
    {
        [Test]
        public void Test()
        {
            var solver = new Solver();
            var elem = new Element[6];
            elem[0] = new Element("Alex");
            elem[1] = new Element("Bob");
            elem[2] = new Element("Charles");
            elem[3] = new Element("Donald");
            elem[4] = new Element("Ethan");
            elem[5] = new Element("Frank");
            
            Assert.True(solver.Solve(elem, '-') == "Donald-Ethan-Frank");
        }
    }
}