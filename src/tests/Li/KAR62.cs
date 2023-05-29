using NUnit.Framework;

namespace Serializer
{
    internal class SerializerTest
    {
        [Test]
        public void Test1()
        {
            string s = "Проверка, проверка!";
            string t = Serializer.Deserialize(Serializer.Serialize(s));
            Assert.IsTrue(string.Compare(s, t) == 0);
        }

        [Test]
        public void Test2()
        {
            string s = "Vielen Dank für einen schönen Tag!";
            string t = Serializer.Deserialize(Serializer.Serialize(s));
            Assert.IsTrue(string.Compare(s, t) == 0);
        }

        [Test]
        public void Test3()
        {
            string s = "初めまして。よろしくお願いします";
            string t = Serializer.Deserialize(Serializer.Serialize(s));
            Assert.IsTrue(string.Compare(s, t) == 0);
        }
    }
}
