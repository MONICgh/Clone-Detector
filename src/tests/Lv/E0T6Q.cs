using NUnit.Framework;

namespace Concat
{
    class MyInt : IName
    {
        private int value;
        public MyInt(int x)
        {
            value = x;
        }
        public string Name()
        {
            return value.ToString();
        }
    }
    internal class ConcatTest
    {
        [Test]
        public void Test1()
        {
            List<MyInt> list = new() { new MyInt(1), new MyInt(2), new MyInt(5), new MyInt(4), new MyInt(7) };
            Assert.IsTrue(Concat.Concatenate(list, '+') == "4+7");
        }

        [Test]
        public void Test2()
        {
            List<MyInt> list = new() { new MyInt(-1), new MyInt(0), new MyInt(1), new MyInt(5) };
            Assert.IsTrue(Concat.Concatenate(list, '|') == "5");
        }

        [Test]
        public void Test3()
        {
            List<MyInt> list = new() { new MyInt(-1), new MyInt(0), new MyInt(1), new MyInt(-2), new MyInt(0), new MyInt(2) };
            Assert.IsTrue(Concat.Concatenate(list, '|') == "-2|0|2");
        }
    }
}
