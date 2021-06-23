using GradingSystem.Exceptions;
using GradingSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingSystem.Services
{
    class GradeService
    {
        private readonly GradeRepository gradeRepository = new();

        public bool HasGrades()
        {
            try
            {
                return gradeRepository.GetAllGrades().Any();
            }
            catch
            {
                Console.WriteLine(GradeException.EmptyTable());
                return false;
            }
        }
    }
}
