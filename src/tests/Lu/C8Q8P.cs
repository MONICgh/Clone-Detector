using System.Runtime.Serialization;

namespace HW_09;

[Serializable]
public class Group
{
    protected bool Equals(Group other)
    {
        string StudString(IEnumerable<Student> stud)
        {
            return stud.Aggregate("", (s, student) => s + student + " ");
        }

        return Name == other.Name && GroupId == other.GroupId && StudString(Students) == StudString(other.Students)
            && StudentsCount == other.StudentsCount;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        return obj.GetType() == GetType() && Equals((Group)obj);
    }

    public decimal GroupId { get; set; }
    public string Name { get; set; }
    public List<Student> Students { get; set; }


    [field: NonSerialized] public int StudentsCount { get; set; }

    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
        StudentsCount = Students.Count;
    }

    public override string ToString()
    {
        return Name + " " + GroupId + " " + Students.Aggregate("", (s, student) => s + student + " ") + " " + StudentsCount;
    }
}
