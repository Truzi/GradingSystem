using GradingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GradingSystem.Exceptions;
using GradingSystem.ExtensionMethods;
using GradingSystem.Services.Utilities;

namespace GradingSystem.Services
{
    public class GradingSystemService
    {
        private readonly GradingSystemContext _db = new();

        private readonly StudentService studentService = new();
        private readonly SubjectService subjectService = new();
        private readonly GradeService gradeService = new();

        public void IsDbCreated()
        {
            _db.Database.EnsureCreated();
        }

        public void MainMenuHandler(int option)
        {
            IsDbCreated();

            switch (option)
            {
                case (int)MainOptions.Students:
                    StudentHandler();
                    break;
                case (int)MainOptions.Subjects:
                    SubjectHandler();
                    break;
                case (int)MainOptions.Grades:
                    GradeHandler();
                    break;
                case (int)MainOptions.Exit:
                    Environment.Exit(1);
                    break;
                default:
                    IncorrectOption();
                    break;
            }
        }
        

        private void StudentHandler()
        {
            int option;
            do
            {
                Menu.StudentMenu();
                option = GetInt();
                switch (option)
                {
                    case (int)StudentOptions.Add:
                        try
                        {
                            studentService.AddStudent();
                        } catch(SubjectException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case (int)StudentOptions.Update:
                        try
                        {
                            studentService.UpdateStudent();
                        } catch(SubjectException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case (int)StudentOptions.Remove:
                        try
                        {
                            studentService.RemoveStudent();
                        } catch (SubjectException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case (int)StudentOptions.Print:
                        try
                        {
                            studentService.PrintStudents();
                        } catch (SubjectException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case (int)MainOptions.Exit:
                        break;
                    default:
                        IncorrectOption();
                        break;
                }
            } while (!option.IsExit());
        }

        private void SubjectHandler()
        {
            int option;
            do
            {
                Menu.SubjectMenu();
                option = GetInt();
                switch (option)
                {
                    case (int)SubjectOptions.Add:
                        try
                        {
                            subjectService.AddSubject();
                        } catch (SubjectException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case (int)SubjectOptions.Update:
                        subjectService.UpdateSubject();
                        break;
                    case (int)SubjectOptions.Remove:
                        subjectService.RemoveSubject();
                        break;
                    case (int)SubjectOptions.Print:
                        subjectService.PrintSubjects();
                        break;
                    case (int)MainOptions.Exit:
                        break;
                    default:
                        IncorrectOption();
                        break;
                }
            } while (!option.IsExit());
        }

        private void GradeHandler()
        {
            int option;
            do
            {
                Menu.GradeMenu();
                option = GetInt();
                switch (option)
                {
                    case (int)GradeOptions.AccessStudent:
                        studentService.PrintStudents();
                        //program will ask for Id even if 'PrintStudents()' will show that table is empty
                        //that is because i only Write Exception to the console, how can I overcome that (simple solution please)
                        gradeService.AccessStudent(GetInt());
                        break;
                    case (int)GradeOptions.AccessSubject:
                        subjectService.PrintSubjects();
                        //same as above
                        gradeService.AccessSubject(GetInt());
                        break;
                    case (int)MainOptions.Exit:
                        break;
                    default:
                        IncorrectOption();
                        break;
                }
            } while (option != 0);
        }



        public static int GetInt()
        {
            Console.Write("Provide number (blank = 0): ");
            if (!int.TryParse(Console.ReadLine(), out int i))
                return 0;
            
            return i;
        }

        public static string GetString(string msg)
        {
            Console.Write(msg);
            return Console.ReadLine();
        }

        public static void IncorrectOption()
        {
            Console.WriteLine("Incorrect option");
        }
    }
}
