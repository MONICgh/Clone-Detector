using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Application
{
    class Group
    {
        public decimal GroupId { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        // no need to serialize this
        public int StudentsCount { get; set; }
        public override string ToString()
        {
            return $"Group(GroupId={GroupId}, Name={Name}, Students={string.Join(", ", Students)}, StudentsCount={StudentsCount})";
        }
    }
    class Student
    {
        public decimal StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Group Group { get; set; }
        public override string ToString()
        {
            return $"Student(StudentId={StudentId}, FirstName={FirstName}, LastName={LastName}, Age={Age}, GroupName={Group.Name})";
        }
    }

    class Task2
    {
        static void SaveGroup(Stream s, Group group)
        {
            var w = new BinaryWriter(s);
            w.Write(group.GroupId);
            w.Write(group.Name);
            w.Write(group.StudentsCount);
            foreach (Student student in group.Students)
            {
                w.Write(student.StudentId);
                w.Write(student.FirstName);
                w.Write(student.LastName);
                w.Write(student.Age);
            }
            w.Flush();
        }

        static Group LoadGroup(Stream s)
        {
            var r = new BinaryReader(s);
            Group group = new Group();
            group.GroupId = r.ReadDecimal();
            group.Name = r.ReadString();
            group.StudentsCount = r.ReadInt32();
            var students = new List<Student>();
            for (int i = 0; i < group.StudentsCount; i++)
            {
                var student = new Student();
                student.StudentId = r.ReadDecimal();
                student.FirstName = r.ReadString();
                student.LastName = r.ReadString();
                student.Age = r.ReadInt32();
                students.Add(student);
            }
            group.Students = students;
            foreach (Student student in group.Students)
            {
                student.Group = group;
            }
            return group;
        }

        static void Main()
        {
            var group = new Group();
            group.GroupId = 1;
            group.Name = "best group";
            var student1 = new Student();
            student1.StudentId = 123;
            student1.FirstName = "Student";
            student1.LastName = "Petrov";
            student1.Age = 20;
            student1.Group = group;
            var student2 = new Student();
            student2.StudentId = 125;
            student2.FirstName = "Student";
            student2.LastName = "Ivanov";
            student2.Age = 21;
            student2.Group = group;
            group.Students = new List<Student>() { student1, student2 };
            group.StudentsCount = group.Students.Count();
            Console.WriteLine(group);

            Stream s = File.Open("/Users/andrew/courses/с#/c_sharp/hw9/task2/task2/stream.txt", FileMode.Create);
            SaveGroup(s, group);
            s.Position = 0;
            var group2 = LoadGroup(s);
            Console.WriteLine(group2);
        }
    }
}
