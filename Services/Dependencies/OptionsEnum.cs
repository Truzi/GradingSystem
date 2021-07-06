using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingSystem.Services.Dependencies
{
    class OptionsEnum
    {
        public enum GeneralOptions
        {
            Incorrect = 404
        }

        public enum MainOptions
        {
            Exit, Students, Subjects, Grades
        }

        public enum StudentOptions
        {
            Exit, Add, Update, Remove, Print
        }
    }
}
