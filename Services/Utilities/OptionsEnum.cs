using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingSystem.Services.Utilities
{

        public enum MainOptions
        {
            Exit, Students, Subjects, Grades
        }

        public enum StudentOptions
        {
            Add = 1, Update, Remove, Print
        }

        public enum SubjectOptions
        {
            Add = 1, Update, Remove, Print
        }

        public enum GradeOptions
        {
            AccessStudent = 1, AccessSubject
        }

}
