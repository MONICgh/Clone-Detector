using System.Runtime.Serialization;

namespace SerializeStudentGroup
{
    [Serializable]
    public class Group
    {
        public decimal GroupId { get; set; }

        public string Name { get; set; }

        // no need to serialize this
        [NonSerialized]
        private int studentsCount;
        private List<Student> students;

        public List<Student> Students
        {
            get
            {
                return students;
            }
            set
            {
                students = value;
                studentsCount = students.Count;
            }
        }

        public int StudentsCount()
        {
            return studentsCount;
        }

        [OnDeserialized]
        private void calculateStudentsCount(StreamingContext context)
        {
            studentsCount = students.Count;
        }
    }
}
