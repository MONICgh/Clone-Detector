namespace StudentGroup;

[Serializable]
public class Student
{
    public decimal StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age{ get; set; }
    public Group Group { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is Student st)
        {
            return StudentId == st.StudentId &&
                   FirstName == st.FirstName &&
                   LastName == st.LastName &&
                   Age == st.Age;
        }

        return false;
    }
}
