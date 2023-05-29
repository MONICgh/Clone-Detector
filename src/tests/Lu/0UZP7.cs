using System.Runtime.Serialization;

namespace StudentGroup;

[Serializable]
public class Group
{
    public decimal GroupId { get; set; }
    public string Name { get; set; }
    public List<Student> Students { get; set; }
    // no need to serialize this
    [field: NonSerialized]
    public int StudentsCount { get; set; }
    
    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
        StudentsCount = Students.Count;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Group gr)
        {
            return GroupId == gr.GroupId &&
                   Name == gr.Name &&
                   Students.Zip(gr.Students).All((st => st.First.Equals(st.Second)));
        }

        return false;
    }
} 
