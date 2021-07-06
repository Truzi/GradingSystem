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
            return gradeRepository.GetAllGrades().Any();
        }

        /*public bool StudentHasGrades(int studentID, int subjectID)
        {
            // same as above
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

        // add what, donuts?
        // way too overwhelming function, consider splitting it into smaller parts
        // also handlers are something different, I was confused when I first saw something called "AddHandler"
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
                    Console.Write("Provide ID for subject you want to add grade: ");     // look at Program.cs for details
                    subjectID = GradingSystemService.GetInt("msg");    // this is a funny use case :)   
                    studentService.PrintHandler();
                    Console.Write("Provide ID or IDs for student you want to add grade (type 'all' to add for all students or separate with ' '): ");
                    studentsForGrade = Console.ReadLine();
                    Console.Write("Provide the grade: ");
                    value = GradingSystemService.GetInt("msg");
                    Console.Write("Write some comment or leave it blank: ");
                    comment = Console.ReadLine();

                    // While exit too complex, consider adding a variable
                    // shouldExit = subjectID == 0 || studentsForGrade == "" || value == 0
                    // while(shouldExit)
                } while (subjectID == 0 || studentsForGrade == "" || value == 0);

                // magic string
                // consider using either a const or an extension
                if (studentsForGrade.ToLower() == "all")
                {
                    // questionable to call GetStudents from service but can be justified
                    foreach (var student in studentService.GetStudents())
                    {
                        // constructor would have been much cleaner in this case, would also limit me from setting anything more than needed
                        gradeRepository.AddGrade(new Models.Grade { Value = value, StudentId = student.Id, SubjectId = subjectID, Comment = comment });
                    }
                }
                else
                {
                    if (studentsForGrade.Length == 1)
                    {
                        // unhandled exception in case studentsForGrade is not a number, consider TryParse with adequate logic
                        studentID = int.Parse(studentsForGrade);
                        gradeRepository.AddGrade(new Models.Grade { Value = value, StudentId = studentID, SubjectId = subjectID, Comment = comment });
                    }
                    else
                    {
                        // same unhandled exception
                        // ToList isn't needed in that case
                        students = studentsForGrade.Split(" ").Select(Int32.Parse).ToList();
                        foreach (var student in students)
                        {
                            gradeRepository.AddGrade(new Models.Grade { Value = value, StudentId = student, SubjectId = subjectID, Comment = comment });
                        }
                    }
                }
            }
        }

        public void UpdateHandler()
        {
            int value, subjectID, studentID, gradeID;
            // studentService.HasStudents() || subjectService.HasSubjects() 
            // reused another time, consider wrapping it in a function
            if (studentService.HasStudents() || subjectService.HasSubjects())
            {
                do
                {
                    studentService.PrintHandler();
                    Console.Write("Provide ID of student you want to update grade: ");
                    studentID = GradingSystemService.GetInt("msg"); 
                    subjectService.PrintHandler();
                    Console.Write("Provide ID of subject: ");
                    subjectID = GradingSystemService.GetInt("msg");
                } while (studentID == 0 || subjectID == 0);
                
                PrintGrades(studentID, subjectID);
                Console.Write("Pick ID of grade you wish to update: ");
                gradeID = GradingSystemService.GetInt("msg");
                try
                {
                    // so you had some checks before, but this function can easily return null
                    // and the message you would show in that case is "There was a problem with connection to DB"
                    // I call lies
//                    var grade = gradeRepository.GetGrade(gradeID);
                    Console.Write("Provide updated value: ");
                    value = GradingSystemService.GetInt("msg");
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
                    // sorry I just can't get over it :'D
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
                gradeID = GradingSystemService.GetInt("msg");
                // same as above
                //var grade = gradeRepository.GetGrade(gradeID);
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
            subjectID = GradingSystemService.GetInt("msg");
            var grades = gradeRepository.GetSubjectGrades(subjectID);

            // save any into a temporary variable, this will allow you to return it's value 
            // no more magic booleans
            if (grades.Any())
            {
                foreach (var grade in grades)
                {
                    // another possible null exception
                    var student = studentService.GetStudent(grade.StudentId);
                    Console.WriteLine($"{grade.ID} - {student.First} {student.Last} - {grade.Value} for {grade.Comment}");
                }
                return true; // magic bool
            } else
            {
                Console.WriteLine("There are no grades for this subject atm");
                return false; // magic bool
            }
        }

        public void PrintHandlerStudent()
        {
            int studentID;
            studentService.PrintHandler();
            Console.Write("Provide ID of student: ");
            studentID = GradingSystemService.GetInt("msg");
            var grades = gradeRepository.GetStudentGrades(studentID);
            foreach (var grade in grades)
            {
                // same as above
                var subject = subjectService.GetSubject(grade.SubjectId);
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
                studentID = GradingSystemService.GetInt("msg");
                subjectService.PrintHandler();
                Console.Write("Provide subject ID: ");
                subjectID = GradingSystemService.GetInt("msg");
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
                    // :)
                    Console.WriteLine(GradeException.NotFound());
            }
            catch
            {
                // :))))
                Console.WriteLine(GradeException.EmptyTable());
            }
        }*/
    }
}
