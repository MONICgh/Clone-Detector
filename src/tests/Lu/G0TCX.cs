using System.Runtime.Serialization.Formatters.Binary;
using StudentGroupSerialization;

MemoryStream SerializeGroup(Group group)
{
    var binaryFormatter = new BinaryFormatter();
    var stream = new MemoryStream();
    binaryFormatter.Serialize(stream, group);
    stream.Position = 0;
    return stream;
}

Group DeserializeGroup(Stream stream)
{
    var binaryFormatter = new BinaryFormatter();
    return (Group) binaryFormatter.Deserialize(stream);
}

var group = new Group(decimal.Zero, "Test group");
var firstStudent = new Student(0, "Elizaveta", "Artser", 21, group);
var secondStudent = new Student(1, "Elizaveta", "Zyryanova", 21, group);
var thirdStudent = new Student(2, "Irina", "Zubareva", 21, group);
group.Students = new List<Student> { firstStudent, secondStudent, thirdStudent };

Console.WriteLine("Before serialization:\n" + group);

var deserializedGroup = DeserializeGroup(SerializeGroup(group));

Console.WriteLine("After deserialization:\n" + deserializedGroup);
