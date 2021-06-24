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
        private readonly StudentService studentService = new();
        private readonly SubjectService subjectService = new();

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

        public bool StudentHasGrades(int studentID, int subjectID)
        {
            try
            {
                return gradeRepository.GetGrades(studentID, subjectID).Any();
            }
            catch
            {
                Console.WriteLine(GradeException.EmptyTable());
                return false;
            }
        }

        public void AddHandler()
        {
            int value, subjectID, studentID;
            string studentsForGrade, comment;
            List<int> students;
            if (studentService.HasStudents() || subjectService.HasSubjects())
            {
                do
                {
                    subjectService.PrintHandler();
                    Console.Write("Provide ID for subject you want to add grade: ");
                    subjectID = GradingSystemService.GetInt();
                    studentService.PrintHandler();
                    Console.Write("Provide ID or IDs for student you want to add grade (type 'all' to add for all students or separate with ' '): ");
                    studentsForGrade = Console.ReadLine();
                    Console.Write("Provide the grade: ");
                    value = GradingSystemService.GetInt();
                    Console.Write("Write some comment or leave it blank: ");
                    comment = Console.ReadLine();
                } while (subjectID == 0 || studentsForGrade == "" || value == 0);

                if (studentsForGrade.ToLower() == "all")
                {
                    foreach (var student in studentService.GetStudents())
                    {
                        gradeRepository.AddGrade(new Models.Grade { Value = value, StudentID = student.ID, SubjectID = subjectID, Comment = comment });
                    }
                }
                else
                {
                    if (studentsForGrade.Length == 1)
                    {
                        studentID = int.Parse(studentsForGrade);
                        gradeRepository.AddGrade(new Models.Grade { Value = value, StudentID = studentID, SubjectID = subjectID, Comment = comment });
                    }
                    else
                    {
                        students = studentsForGrade.Split(" ").Select(Int32.Parse).ToList();
                        foreach (var student in students)
                        {
                            gradeRepository.AddGrade(new Models.Grade { Value = value, StudentID = student, SubjectID = subjectID, Comment = comment });
                        }
                    }
                }
            }
        }

        public void UpdateHandler()
        {
            int value, subjectID, studentID, gradeID;
            if (studentService.HasStudents() || subjectService.HasSubjects())
            {
                do
                {
                    studentService.PrintHandler();
                    Console.Write("Provide ID of student you want to update grade: ");
                    studentID = GradingSystemService.GetInt();
                    subjectService.PrintHandler();
                    Console.Write("Provide ID of subject: ");
                    subjectID = GradingSystemService.GetInt();
                } while (studentID == 0 || subjectID == 0);
                
                PrintGrades(studentID, subjectID);
                Console.Write("Pick ID of grade you wish to update: ");
                gradeID = GradingSystemService.GetInt();
                try
                {
                    var grade = gradeRepository.GetGrade(gradeID);
                    Console.Write("Provide updated value: ");
                    value = GradingSystemService.GetInt();
                    if (value == 0)
                        gradeRepository.UpdateGrade(grade);
                    else
                    {
                        grade.Value = value;
                        gradeRepository.UpdateGrade(grade);
                    }
                }
                catch
                {
                    Console.WriteLine(GradeException.DbError());
                }
            }
        }

        public void RemoveHandler()
        {
            int gradeID;
            if (PrintHandlerSubject())
            {
                Console.Write("Provide ID of grade to remove: ");
                gradeID = GradingSystemService.GetInt();
                var grade = gradeRepository.GetGrade(gradeID);
                try
                {
                    gradeRepository.RemoveGrade(grade);
                }
                catch
                {
                    Console.WriteLine(GradeException.DbError());
                }
            }
        }

        public bool PrintHandlerSubject()
        {
            int subjectID;
            subjectService.PrintHandler();
            Console.Write("Provide ID of subject: ");
            subjectID = GradingSystemService.GetInt();
            var grades = gradeRepository.GetSubjectGrades(subjectID);
            if (grades.Any())
            {
                foreach (var grade in grades)
                {
                    var student = studentService.GetStudent(grade.StudentID);
                    Console.WriteLine($"{grade.ID} - {student.First} {student.Last} - {grade.Value} for {grade.Comment}");
                }
                return true;
            } else
            {
                Console.WriteLine("There are no grades for this subject atm");
                return false;
            }
        }

        public void PrintHandlerStudent()
        {
            int studentID;
            studentService.PrintHandler();
            Console.Write("Provide ID of student: ");
            studentID = GradingSystemService.GetInt();
            var grades = gradeRepository.GetStudentGrades(studentID);
            foreach (var grade in grades)
            {
                var subject = subjectService.GetSubject(grade.SubjectID);
                Console.WriteLine($"{grade.ID} - {subject.Name} - {grade.Value} for {grade.Comment}");
            }
        }

        public void PrintHandler()
        {
            int studentID, subjectID;
            do
            {
                studentService.PrintHandler();
                Console.Write("Provide student ID: ");
                studentID = GradingSystemService.GetInt();
                subjectService.PrintHandler();
                Console.Write("Provide subject ID: ");
                subjectID = GradingSystemService.GetInt();
            } while (studentID == 0 || subjectID == 0);

            PrintGrades(studentID, subjectID);
        }

        public void PrintGrades(int studentID, int subjectID)
        {
            try
            {
                if (StudentHasGrades(studentID, subjectID))
                {
                    var grades = gradeRepository.GetGrades(studentID, subjectID);
                    grades.ForEach(grade => Console.WriteLine($"{grade.ID}. {grade.Value} - {grade.Comment}"));
                }
                else
                    Console.WriteLine(GradeException.NotFound());
            }
            catch
            {
                Console.WriteLine(GradeException.EmptyTable());
            }
        }
    }
}
