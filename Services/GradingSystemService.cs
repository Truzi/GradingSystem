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
                        } catch(StudentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case (int)StudentOptions.Update:
                        try
                        {
                            studentService.UpdateStudent();
                        } catch(StudentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case (int)StudentOptions.Remove:
                        try
                        {
                            studentService.RemoveStudent();
                        } catch (StudentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case (int)StudentOptions.Print:
                        try
                        {
                            studentService.PrintStudents();
                        } catch (StudentException ex)
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
            } while (option.IsExit());
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
                        try
                        {
                            subjectService.UpdateSubject();
                        }
                        catch (SubjectException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case (int)SubjectOptions.Remove:
                        try
                        {
                            subjectService.RemoveSubject();
                        }
                        catch (SubjectException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case (int)SubjectOptions.Print:
                        try
                        {
                            subjectService.PrintSubjects();
                        }
                        catch (SubjectException ex)
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
            } while (option.IsExit());
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
                        try
                        {
                            studentService.PrintStudents();
                            gradeService.AccessStudent(GetInt());
                        } catch (StudentException exEmptyTable)
                        {
                            Console.WriteLine(exEmptyTable.Message);
                        }
                        break;
                    case (int)GradeOptions.AccessSubject:
                        try
                        {
                            subjectService.PrintSubjects();
                        }
                        catch (SubjectException ex) { Console.WriteLine(ex.Message); }
                        gradeService.AccessSubject(GetInt());
                        break;
                    case (int)MainOptions.Exit:
                        break;
                    default:
                        IncorrectOption();
                        break;
                }
            } while (option.IsExit());
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
