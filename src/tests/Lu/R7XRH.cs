using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab9
{
    [Serializable]
    class Group
    {
        public decimal GroupId { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        // no need to serialize this
        [field: NonSerialized]
        public int StudentsCount { get; set; }

        [OnDeserialized]
        public void onDeserialized(StreamingContext context)
        {
            StudentsCount = Students.Count;
        }
    }
    [Serializable]
    class Student
    {
        public decimal StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Group Group { get; set; }
    }

    static class Serializer
    {
        public static void Serialize(Group group, string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, group);
            }
        }
        public static Group Deserialize(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                Group newGroup = (Group)formatter.Deserialize(fs);
                return newGroup;
            }
        }
    }
}
