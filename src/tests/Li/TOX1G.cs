using NUnit.Framework;

namespace MergeStrings
{
    internal class MergeStringsTest
    {
        [Test]
        public void Test1()
        {
            Assert.IsTrue(MergeStrings.mergeStrings("Шла Маша по шоссе пешком", "Шла Саша по горе") == "Шла Маша Саша по шоссе пешком горе");
        }

        [Test]
        public void Test2()
        {
            Assert.IsTrue(MergeStrings.mergeStrings("AAAA bbbb ccc dddd eeee ffff", "ccc eeee AAAA bbbb ffff dddd") ==
                "AAAA bbbb ccc dddd eeee AAAA bbbb ffff dddd");
        }

        [Test]
        public void Test3()
        {
            Assert.IsTrue(MergeStrings.mergeStrings("по пути домой нашёл монетку", "нашёл по пути домой монетку") ==
                "нашёл по пути домой нашёл монетку");
        }
    }
}
