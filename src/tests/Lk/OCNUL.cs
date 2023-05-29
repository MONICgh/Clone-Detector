using Interfaces;
using NUnit.Framework;

namespace Tests.InterfacesTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            var tmp = new ChildClass();
            Assert.True(tmp.Hello() == "Hello from AbstractClass");
            Assert.True(((Interface1)tmp).Hello() == "Hello from Interface1");
            Assert.True(((Interface2)tmp).Hello() == "Hello from Interface2");
        }
    }
}