using System.Collections.Generic;

namespace GradingSystem.Models
{
    class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Grade> Grades { get; set; }

        public Subject(string name)
        {
            Name = name;
        }
    }
}
