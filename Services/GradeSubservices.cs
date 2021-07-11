using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingSystem.Services
{
    class GradeSubservices
    {
        public void AddGrade(int studentId)
        {
            try
            {
                subjectService.PrintSubjects();
                int subjectId = GradingSystemService.GetInt();
                try
                {
                    int value = GetValue();
                    string comment = GradingSystemService.GetString("Provide comment or leave blank: ");
                    var grade = new Grade(value, comment, studentId, subjectId);
                    try
                    {
                        gradeRepository.AddGrade(grade);
                    }
                    catch
                    {
                        throw GradeException.AddError();
                    }
                }
                catch (GradeException exValueError)
                {
                    Console.WriteLine(exValueError.Message);
                }
            }
            catch (SubjectException exEmptyTable)
            {
                Console.WriteLine(exEmptyTable.Message);
            }
        }

        public void UpdateGrade(int studentId)
        {
            try
            {
                PrintStudentGrades(studentId);
                int gradeId = GradingSystemService.GetInt();
                try
                {
                    var grade = GetGrade(gradeId);
                    try
                    {
                        int value = GetValue();
                        string comment = GradingSystemService.GetString("Updated comment: ");
                        grade.Value = value;
                        grade.Comment = string.IsNullOrWhiteSpace(comment) ? grade.Comment : comment;
                    }
                    catch (GradeException exValueError)
                    {
                        Console.WriteLine(exValueError.Message);
                        throw GradeException.UpdateError();
                    }
                }
                catch (GradeException exNotFound)
                {
                    Console.WriteLine(exNotFound.Message);
                }

            }
            catch (GradeException exSearchError)
            {
                Console.WriteLine(exSearchError.Message);
            }
        }

        public void RemoveGrade(int studentId)
        {
            try
            {
                PrintStudentGrades(studentId);
                int gradeId = GradingSystemService.GetInt();
                try
                {
                    var grade = GetGrade(gradeId);
                    try
                    {
                        gradeRepository.RemoveGrade(grade);
                    }
                    catch
                    {
                        throw GradeException.RemoveError();
                    }
                }
                catch (GradeException exNotFound)
                {
                    Console.WriteLine(exNotFound.Message);
                }
            }
            catch (GradeException exSearchError)
            {
                Console.WriteLine(exSearchError.Message);
            }
        }

        public void PrintStudentGrades(int studentId)
        {
            var grades = GetStudentGrades(studentId);
            var subjects = subjectService.GetSubjects();
            foreach (var grade in grades)
            {
                var subject = subjects.First(s => s.Id == grade.SubjectId);
                Console.WriteLine($"{grade.Id}. {grade.Value} {subject.Name} - {grade.Comment}");
            }
            Console.WriteLine(new string('-', Menu.repeat));
        }

        public void PrintGrades(int studentId)
        {
            int subjectId;
            try
            {
                subjectService.PrintSubjects();
                subjectId = GradingSystemService.GetInt();
                var grades = GetGrades(studentId, subjectId);
                var subject = subjectService.GetSubject(subjectId);
                Console.WriteLine($"Grades for {subject.Name}");
                foreach (var grade in grades)
                {
                    Console.WriteLine($"{grade.Id}. {grade.Value} {subject.Name} - {grade.Comment}");
                }
                Console.WriteLine(new string('-', Menu.repeat));
            }
            catch (SubjectException exEmptyTable)
            {
                Console.WriteLine(exEmptyTable.Message);
            }

        }
    }
}
