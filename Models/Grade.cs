using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingSystem.Models
{
    class Grade
    {
        public int Value { get; set; }
        public string Comment { get; set; }

        //Relations
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public Grade(int value, string comment, int studentId, int subjectId)
        {
            Value = value;
            Comment = comment;
            StudentId = studentId;
            SubjectId = subjectId;
        }
    }
}
