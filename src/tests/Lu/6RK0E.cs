using System.Runtime.Serialization;

namespace StudentGroupSerialization;

[Serializable]
public class Group
{
    private List<Student> _students;

    [NonSerialized] private int _studentsCount;

    public Group(decimal groupId, string name)
    {
        GroupId = groupId;
        Name = name;
    }

    public decimal GroupId { get; set; }
    public string Name { get; set; }

    public List<Student> Students
    {
        get => _students;
        set
        {
            _students = value;
            _studentsCount = value.Count;
        }
    }

    // no need to serialize this
    public int StudentsCount
    {
        get => _studentsCount;
        set => _studentsCount = value;
    }

    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
        _studentsCount = _students.Count;
    }

    public override string ToString()
    {
        var groupString = "Group(id: " + GroupId + ", name: " + Name + ", students:\n";
        groupString += string.Join(",\n", Students.Select(student => "    " + student));
        groupString += "\n)";
        return groupString;
    }
}
