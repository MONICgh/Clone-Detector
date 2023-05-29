using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using Task2;


var group = new Group(1L, "group");

var students = new List<Student>();
students.Add(new Student(
    1L,
    "A",
    "a",
    18,
    group
));
students.Add(
new Student(
        2L,
        "B",
        "b",
        20,
        group
    ));

group.Students = students;

var binaryFormatter = new BinaryFormatter();
using (FileStream file = new FileStream("D:\\file.bin", FileMode.Create, FileAccess.Write))
{
    binaryFormatter.Serialize(file, group);
    file.Flush();
}

//Thread.Sleep(1000);

Group deserializedGroup;


using (var file = new FileStream("D:\\file.bin", FileMode.Open, FileAccess.Read))
{
    deserializedGroup = (Group) binaryFormatter.Deserialize(file);
}

Debug.Assert(deserializedGroup.Equals(group));

Console.WriteLine("All is Okay!");