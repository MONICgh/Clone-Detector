using NUnit.Framework;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializeStudentGroup
{
    public class SerializeStudentGroupTest
    {
        [Test]
        public void Test1()
        {
            Student Maxim = new()
            {
                StudentId = 1,
                FirstName = "Maxim",
                LastName = "Ivanov",
                Age = 20,
            };
            Student Oleg = new()
            {
                StudentId = 24567832,
                FirstName = "Oleg",
                LastName = "Tinkov",
                Age = 30,
            };
            Student Igor = new()
            {
                StudentId = 5719,
                FirstName = "Igor",
                LastName = "Smirnov",
                Age = 14,
            };
            Group b09 = new()
            {
                GroupId = 9,
                Name = "SP2019_B09",
                Students = new List<Student> { Maxim, Oleg, Igor },
            };
            Maxim.Group = b09;
            Oleg.Group = b09;
            Igor.Group = b09;

            FileStream fs_write = new FileStream("test", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new();
            bf.Serialize(fs_write, b09);
            fs_write.Close();

            FileStream fs_read = new FileStream("test", FileMode.Open, FileAccess.Read);
            Group b09_from_file = (Group)bf.Deserialize(fs_read);
            fs_read.Close();

            Assert.IsTrue(b09_from_file.GroupId == b09.GroupId);
            Assert.IsTrue(b09_from_file.Name == b09.Name);
            Assert.IsTrue(b09_from_file.StudentsCount() == b09.StudentsCount());
            {
                Assert.IsTrue(b09_from_file.Students[0].StudentId == Maxim.StudentId);
                Assert.IsTrue(b09_from_file.Students[0].FirstName == Maxim.FirstName);
                Assert.IsTrue(b09_from_file.Students[0].LastName == Maxim.LastName);
                Assert.IsTrue(b09_from_file.Students[0].Age == Maxim.Age);
                Assert.IsTrue(b09_from_file.Students[0].Group == b09_from_file);
            }
            {
                Assert.IsTrue(b09_from_file.Students[1].StudentId == Oleg.StudentId);
                Assert.IsTrue(b09_from_file.Students[1].FirstName == Oleg.FirstName);
                Assert.IsTrue(b09_from_file.Students[1].LastName == Oleg.LastName);
                Assert.IsTrue(b09_from_file.Students[1].Age == Oleg.Age);
                Assert.IsTrue(b09_from_file.Students[1].Group == b09_from_file);
            }
            {
                Assert.IsTrue(b09_from_file.Students[2].StudentId == Igor.StudentId);
                Assert.IsTrue(b09_from_file.Students[2].FirstName == Igor.FirstName);
                Assert.IsTrue(b09_from_file.Students[2].LastName == Igor.LastName);
                Assert.IsTrue(b09_from_file.Students[2].Age == Igor.Age);
                Assert.IsTrue(b09_from_file.Students[2].Group == b09_from_file);
            }
        }
    }
}