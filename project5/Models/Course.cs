#nullable enable
using System.Collections.Generic;

namespace project4.Models
{
    public class Course
    {
        public string Name { get; set; } = string.Empty;
        public Teacher? AssignedTeacher { get; set; } 
        public List<Student> Students { get; set; } = new List<Student>();

        public override string ToString() => Name;
    }
}
