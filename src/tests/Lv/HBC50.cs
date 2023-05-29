using NUnit.Framework;

namespace FindElem
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

    internal class FindElemTest
    {
        [Test]
        public void Test1()
        {
            List<MyInt> list = new() { new MyInt(1), new MyInt(2), new MyInt(55), new MyInt(4444), new MyInt(77777) };
            List<MyInt> answer = new() { new MyInt(1), new MyInt(4444), new MyInt(77777) };
            IEnumerable<MyInt> output = FindElem.Find(list);
            Assert.IsTrue(output.Count() == answer.Count);

            int index = 0;
            foreach (MyInt x in output)
            {
                Assert.IsTrue(x.Name() == answer[index].Name());
                index++;
            }
        }
    }
}
