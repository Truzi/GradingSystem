using System.Collections.Generic;

namespace GradingSystem.Models
{
    class Student
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public ICollection<Grade> Grades { get; set; }

        public Student(string first, string last)
        {
            First = first;
            Last = last;
        }
    }
}
