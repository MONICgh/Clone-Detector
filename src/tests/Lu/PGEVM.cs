namespace HW_09;

[Serializable]
public class Student
{
    protected bool Equals(Student other)
    {
        return StudentId == other.StudentId && FirstName == other.FirstName && LastName == other.LastName && Age == other.Age;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        return obj.GetType() == GetType() && Equals((Student)obj);
    }

    public decimal StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public Group Group { get; set; }
    
    public override string ToString()
    {
        return FirstName + " " + LastName + " " + Age + " " + StudentId;
    }
}
