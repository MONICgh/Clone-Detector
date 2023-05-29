using System.Runtime.Serialization.Formatters.Binary;
using StudentGroup;

var A = new Student
{
    StudentId = 1,
    FirstName = "John",
    LastName = "Lock",
    Age = 20
};

var B = new Student
{
    StudentId = 2,
    FirstName = "Alex",
    LastName = "Smith",
    Age = 21
};

var G = new Group
{
    GroupId = 1,
    Name = "The Group",
    Students = new List<Student> { A, B },
    StudentsCount = 2
};

A.Group = G;
B.Group = G;

using var stream = new MemoryStream();
var formatter = new BinaryFormatter();
formatter.Serialize(stream, G);
stream.Position = 0;
var nG = (Group)formatter.Deserialize(stream);
if (G.Equals(nG))
{
    Console.WriteLine("Equal");
}
else
{
    throw new Exception();
}