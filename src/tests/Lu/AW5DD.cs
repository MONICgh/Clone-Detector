using System.Runtime.Serialization.Formatters.Binary;
using NUnit.Framework;

namespace HW_09;

[TestFixture]
public class Test
{
    private Group CreateGroup(string name, int id)
    {
        var group = new Group
        {
            Name = name,
            GroupId = id,
            Students = new List<Student>(),
            StudentsCount = 0
        };
        return group;
    }

    private Student CreateStudentWithGroup(Group group, int age, string name, string lastName, int id)
    {
        var student = new Student
        {
            Age = age,
            Group = group,
            FirstName = name,
            LastName = lastName,
            StudentId = id
        };

        group.Students.Add(student);
        group.StudentsCount++;

        return student;
    }

    MemoryStream Serialize(Group group)
    {
        var formatter = new BinaryFormatter();
        var stream = new MemoryStream();
        formatter.Serialize(stream, group);
        stream.Position = 0;
        return stream;
    }

    Group Deserialize(Stream stream)
    {
        var formatter = new BinaryFormatter();
        return (Group)formatter.Deserialize(stream);
    }

    [Test]
    public void TestSerialize()
    {
        var group = CreateGroup("g", 1);

        var student1 = CreateStudentWithGroup(group, 1, "a", "l", 3);
        var student2 = CreateStudentWithGroup(group, 2, "b", "k", 4);


        Assert.AreEqual(group, Deserialize(Serialize(group)));
    }
}
