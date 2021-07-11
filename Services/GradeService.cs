using GradingSystem.Exceptions;
using GradingSystem.Models;
using GradingSystem.Repositories;
using System;
using GradingSystem.ExtensionMethods;
using GradingSystem.Services.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace GradingSystem.Services
{
    class GradeService
    {
        private readonly GradeRepository gradeRepository = new();
        private readonly StudentService studentService = new();
        private readonly SubjectService subjectService = new();
        private readonly GradeSubservices gradeSubservices = new();

        public void AccessStudent(int studentId)
        {
            try
            {
                var student = studentService.GetStudent(studentId);
                StudentAccess(student);
            } catch (StudentException exNotFound)
            {
                Console.WriteLine(exNotFound.Message);
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

            
        }

        private void StudentAccess(Student student)
        {
            int option;
            do
            {
                Menu.GradeStudentMenu();
                option = GradingSystemService.GetInt();
                switch (option)
                {
                    case (int)GradeStudentOptions.AddGrade:
                        try
                        {
                            gradeSubservices.AddGrade(student.Id);
                        }
                        catch (GradeException exAddError)
                        {
                            Console.WriteLine(exAddError.Message);
                        }
                        break;
                    case (int)GradeStudentOptions.UpdateGrade:
                        try
                        {
                            gradeSubservices.UpdateGrade(student.Id);
                        }
                        catch (GradeException exUpdateError)
                        {
                            Console.WriteLine(exUpdateError.Message);
                        }
                        break;
                    case (int)GradeStudentOptions.RemoveGrade:
                        try
                        {
                            gradeSubservices.RemoveGrade(student.Id);
                        }
                        catch (GradeException exRemoveError)
                        {
                            Console.WriteLine(exRemoveError.Message);
                        }
                        break;
                    case (int)GradeStudentOptions.PrintAllGrades:
                        try
                        {
                            gradeSubservices.PrintStudentGrades(student.Id);
                        }
                        catch (GradeException exSearchError)
                        {
                            Console.WriteLine(exSearchError.Message);
                        }
                        break;
                    case (int)GradeStudentOptions.PrintGrades:
                        try
                        {
                            gradeSubservices.PrintGrades(student.Id);
                        }
                        catch (GradeException exSearchError)
                        {
                            Console.WriteLine(exSearchError.Message);
                        }
                        break;
                    case (int)MainOptions.Exit:
                        break;
                    default:
                        GradingSystemService.IncorrectOption();
                        break;
                }
            } while (option.IsExit());
        }

        public int GetValue()
        {
            Console.Write("Provide grade's value: ");
            if (!int.TryParse(Console.ReadLine(), out int i))
                throw GradeException.ValueError();

            if (i < 1 || i > 6)
                throw GradeException.ValueError();

            return i;
        }

        public List<Grade> GetStudentGrades(int studentId)
        {
            var grades = gradeRepository.GetStudentGrades(studentId);
            if (!grades.Any())
                throw GradeException.SearchError();

            return grades;
        }

        public List<Grade> GetGrades(int studentId, int subjectId)
        {
            var grades = gradeRepository.GetGrades(studentId, subjectId);
            if (!grades.Any())
                throw GradeException.SearchError();

            return grades;
        }

        public Grade GetGrade(int gradeId)
        {
            var grade = gradeRepository.GetGrade(gradeId);
            if (grade == null)
                throw GradeException.NotFound();

            return grade;
        }
    }
}
