using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingSystem.Models
{
    class Student
    {
        public int ID { get; set; }
        public string First { get; set; }
        public string Last { get; set; }

        //Relations
        public ICollection<Grade> Grades { get; set; }
    }
}
