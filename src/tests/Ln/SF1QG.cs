using NUnit.Framework;

namespace StructInheritance
{
    internal class StructInheritanceTest
    {
        [Test]
        public void Test1()
        {
            Parent parent = new Parent();
            Assert.IsTrue(parent.CreateInt(5) == 25);
            Assert.IsTrue(parent.CreateString("aboba") == "(Parent)_aboba_(Parent)");

            Child child = new Child();
            Assert.IsTrue(child.CreateInt(5) == 25);
            Assert.IsTrue(child.CreateString("aboba") == 
                "(Parent)_(Child)_aboba_(Child)_(Parent)");
        }
    }
}
