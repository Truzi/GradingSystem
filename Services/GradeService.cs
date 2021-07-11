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
            try
            {
                var subject = subjectService.GetSubject(subjectId);
                SubjectAccess(subject);
            } catch (SubjectException exNotFound)
            {
                Console.WriteLine(exNotFound.Message);
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

        private void SubjectAccess(Subject subject)
        {
            int option;
            do
            {
                Menu.GradeSubjectMenu();
                option = GradingSystemService.GetInt();
                switch (option)
                {
                    case (int)GradeSubjectOptions.AddGrades:
                        try
                        {
                            gradeSubservices.AddGrades(subject.Id);
                        }
                        catch (GradeException exAddError)
                        {
                            Console.WriteLine(exAddError.Message);
                        }
                        break;
                    case (int)GradeSubjectOptions.PrintGrades:
                        try
                        {
                            gradeSubservices.PrintSubjectGrades(subject.Id);
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

    }
}
