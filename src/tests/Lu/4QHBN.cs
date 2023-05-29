using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lab9
{
    [TestClass]
    public class HundredMillionStringsTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            HundredMillionStrings.Generate(4);
            // HundredMillionStrings.Generate(8); //big mistake! (as big as ~1 GB) Let's just believe it works.
        }
    }
    [TestClass]
    public class SerializerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var group = new Group();
            group.GroupId = 32;
            group.Name = "Дошколята";
            group.Students = new System.Collections.Generic.List<Student>();
            group.Students.Add(new Student { StudentId = 1, FirstName = "Tom", LastName = "Anderson", Age = 5, Group = group });
            group.Students.Add(new Student { StudentId = 2, FirstName = "Vlad", LastName = "Dyakov", Age = 4, Group = group });
            group.Students.Add(new Student { StudentId = 3, FirstName = "Kate", LastName = "Atkins", Age = 6, Group = group });
            group.Students.Add(new Student { StudentId = 4, FirstName = "Jim", LastName = "Jim", Age = 5, Group = group });
            Serializer.Serialize(group, "ser.txt");
            Group result = Serializer.Deserialize("ser.txt");

            // lazy asserts
            Assert.AreEqual(result.GroupId, group.GroupId);
            Assert.AreEqual(result.Name, group.Name);
            Assert.AreEqual(result.StudentsCount, 4);
            Assert.IsTrue(result.Students[2].LastName.Equals("Atkins"));
        }
    }
    [TestClass]
    public class RationalTest
    {
        [TestMethod]
        public void TestMethod1()
        { Assert.IsTrue(RepeatingDecimal.Rational(2, 5).Equals("0.4")); }
        [TestMethod]
        public void TestMethod2() 
        { Assert.IsTrue(RepeatingDecimal.Rational(1, 6).Equals("0.1(6)")); }
        [TestMethod]
        public void TestMethod3() 
        { Assert.IsTrue(RepeatingDecimal.Rational(1, 3).Equals("0.(3)")); }
        [TestMethod]
        public void TestMethod4() 
        { Assert.IsTrue(RepeatingDecimal.Rational(1, 7).Equals("0.(142857)")); }
        [TestMethod]
        public void TestMethod5() 
        { Assert.IsTrue(RepeatingDecimal.Rational(1, 77).Equals("0.(012987)")); }
    }
}
