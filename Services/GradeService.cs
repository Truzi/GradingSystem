using GradingSystem.Exceptions;
using GradingSystem.Models;
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
        private readonly StudentService studentService = new();
        private readonly SubjectService subjectService = new();

        public void AccessStudent(int studentId)
        {
            try
            {
                var student = studentService.GetStudent(studentId);
                if(student == null) Console.WriteLine(SubjectException.NotFound());
                
                else
                {
                    Menu.GradeStudentMenu();
                }
            }
            catch
            {
                Console.WriteLine(SubjectException.DbError());
            }
        }

        public void AccessSubject(int subjectId)
        {
            var subject = subjectService.GetSubject(subjectId);
            if (subject == null) Console.WriteLine(SubjectException.NotFound());

            else
            {
                Menu.GradeSubjectMenu();
            }

            try
            {

            }
            catch(SubjectException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
