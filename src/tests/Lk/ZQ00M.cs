using NUnit.Framework;

namespace Interface
{
    internal class InterfaceTest
    {
        [Test]
        public void Test1()
        {
            D d = new D();
            Assert.IsTrue(d.HelloWorld(5) == "Hello world! 5");
            Assert.IsTrue(((IA)d).HelloWorld(5) == "HeLlO WoRlD! 6");
            Assert.IsTrue(((IB)d).HelloWorld(5) == "World hello! 7");
        }
    }
}
