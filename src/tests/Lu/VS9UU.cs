using NUnit.Framework;

namespace SerializeTree
{
    internal class VertexTest
    {
        [Test]
        public void Test1()
        {
            Assert.IsTrue(Vertex.Serialize(null) == "");
        }

        [Test]
        public void Test2()
        {
            Assert.IsTrue(Vertex.Serialize(new Vertex(null, null, 5)) == "()[5]");
        }

        [Test]
        public void Test3()
        {
            Vertex v5 = new(null, null, 5);
            Vertex v4 = new(null, null, 4);
            Vertex v3 = new(v4, v5, 3);
            Vertex v2 = new(null, null, 2);
            Vertex v1 = new(v2, v3, 1);
            Assert.IsTrue(Vertex.Serialize(v1) == "(()[2])[1](()[4])[3]()[5]");
        }

        [Test]
        public void Test4()
        {
            Assert.IsTrue(Vertex.Deserialize("") == null);
        }

        [Test]
        public void Test5()
        {
            Vertex v = Vertex.Deserialize("()[5]");
            Assert.IsNull(v.LeftSon);
            Assert.IsNull(v.RightSon);
            Assert.AreEqual(v.Number, 5);
        }

        [Test]
        public void Test6()
        {
            Vertex v = Vertex.Deserialize("(()[2])[1](()[4])[3]()[5]");
            Assert.AreEqual(v.Number, 1);
            Assert.AreEqual(v.LeftSon.Number, 2);
            Assert.IsNull(v.LeftSon.LeftSon);
            Assert.IsNull(v.LeftSon.RightSon);
            Assert.AreEqual(v.RightSon.Number, 3);
            Assert.AreEqual(v.RightSon.LeftSon.Number, 4);
            Assert.AreEqual(v.RightSon.RightSon.Number, 5);
            Assert.IsNull(v.RightSon.LeftSon.LeftSon);
            Assert.IsNull(v.RightSon.LeftSon.RightSon);
            Assert.IsNull(v.RightSon.RightSon.LeftSon);
            Assert.IsNull(v.RightSon.RightSon.RightSon);
        }
    }
}
