using System.Runtime.Serialization;

namespace Task2;

[Serializable]
public class Group
{
    public Group(decimal groupId, string name)
    {
        GroupId = groupId;
        Name = name;
        Students = new List<Student>();
    }
    
    public decimal GroupId { get; set; }
    public string Name { get; set; }
    
    public List<Student> Students
    {
        get => _students;
        set
        {
            _students = value;
            StudentsCount = _students.Count;
        }
    }
    
    private List<Student> _students;

    // no need to serialize this
    //[field: NonSerialized]
    [field: NonSerialized]
    public int StudentsCount { get; set; }

    [OnDeserialized]
    private void CountStudents(StreamingContext context)
    {
        StudentsCount = _students.Count;
    }

    public override bool Equals(object? o)
    {
        if (o is not Group other)
        {
            return false;
        }

        if (!GroupId.Equals(other.GroupId) || !Name.Equals(other.Name) || !StudentsCount.Equals(other.StudentsCount))
        {
            return false;
        }

        if (Students.Count != other.Students.Count)
        {
            return false;
        }

        for (int i = 0; i < Students.Count; i++)
        {
            if (Students[i].Age != other.Students[i].Age || Students[i].FirstName != other.Students[i].FirstName ||
                Students[i].LastName != other.Students[i].LastName ||
                Students[i].StudentId != other.Students[i].StudentId)
                return false;
        }

        return true;
    }
} 
