using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace StudentGroup;

[Serializable]
public class Group
{
    public decimal GroupId { get; set; }
    public string Name { get; set; }

    public List<Student> Students { get; set; }

    // no need to serialize this
    [field: NonSerialized] public int StudentsCount { get; set; }

    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
        StudentsCount = Students.Count;
    }
    public override bool Equals(object? obj)
    {
        if (obj is Group group)
        {
            return group.GroupId == GroupId
                   && group.Name == Name
                   && Students.Zip(group.Students).All((students => Equals(students.First, students.Second)));
        }

        return false;
    }
}

[Serializable]
public class Student
{
    public decimal StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public Group Group { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is Student student)
        {
            return student.StudentId == StudentId
                   && student.Age == Age
                   && student.LastName == LastName
                   && student.FirstName == FirstName
                   && student.Group.GroupId == Group.GroupId;
        }

        return false;
    }
}