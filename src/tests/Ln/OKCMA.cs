using NUnit.Framework;
using ImmutablePair;

namespace Tests.ImmutableTypeTests
{   
    [TestFixture]
    public class ImmutableTypeTests
    {
        [Test]
        public void ConstructorTest()
        {
            var pair = new ImmutablePair<int, string>(42, "abcabca");
            Assert.True(pair.GetFirst() == 42);
            Assert.True(pair.GetSecond() == "abcabca");
        }

        [Test]
        public void ChangeTest()
        {
            var pair = new ImmutablePair<int, string>(42, "abcabca");
            pair = pair.ChangeFirst(43);
            Assert.True(pair.GetFirst() == 43);
            pair = pair.ChangeSecond("abc");
            Assert.True(pair.GetSecond() == "abc");
        }

        [Test]
        public void ImmutabilityTest()
        {
            var pair = new ImmutablePair<int, string>(42, "abcabca");
            pair.ChangeFirst(43);
            Assert.True(pair.GetFirst() == 42);
            pair.ChangeSecond("abc");
            Assert.True(pair.GetSecond() == "abcabca");
        }
    }
}