using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using NUnit.Framework;

namespace StudentGroup;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var group = new Group
        {
            Name = "SP",
            GroupId = 1,
            Students = new List<Student>()
        };
        var student = new Student
        {
            Age = 18,
            FirstName = "Vasya",
            LastName = "Petrov",
            StudentId = 1
        };
        student.Group = group;
        group.Students.Add(student);
        group.StudentsCount = 1;
        
        using (var stream = new MemoryStream())
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, group);
            stream.Position = 0;
            Group deserializedGroup = (Group)formatter.Deserialize(stream);
            Assert.AreEqual(true, Equals(group, deserializedGroup));
        }
    }
}