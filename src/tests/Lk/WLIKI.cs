using System;
using System.Linq;
using Hamsters;
using NUnit.Framework;

namespace Tests.HamsterTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            var rng = new Random();
            var len = rng.Next() % 100 + 1;
            var hamsters = Enumerable.Range(1, len).Select(x => new Hamster()).ToList();
            hamsters.Sort();
            for (var i = 1; i < len; ++i)
            {
                Assert.True(hamsters[i - 1].CompareTo(hamsters[i]) <= 0);
            }
        }
    }
}