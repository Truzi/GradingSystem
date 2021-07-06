using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingSystem.Models
{
    class Student
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }

        //Relations
        public ICollection<Grade> Grades { get; set; }

        public Student(string first, string last)
        {
            First = first;
            Last = last;
        }
    }
}
