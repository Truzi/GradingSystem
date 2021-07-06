using GradingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GradingSystem.Exceptions;
using GradingSystem.ExtensionMethods;
using static GradingSystem.Services.Dependencies.OptionsEnum;

namespace GradingSystem.Services
{
    public class GradingSystemService
    {
        private readonly GradingSystemContext _db = new();

        private readonly StudentService studentService = new();
        private readonly SubjectService subjectService = new();
        private readonly GradeService gradeService = new();

        enum MainOptions
        {
            Exit, Students, Subjects, Grades, Incorrect
        }

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
                    //GradeHandler();
                    break;
                case (int)MainOptions.Exit:
                    Environment.Exit(1);
                    break;
                case (int)GeneralOptions.Incorrect:
                    //is this the correct way of handling things if i don't want program to close if the exception is met?
                    Console.WriteLine(GradingSystemException.GetOption());
                    break;
                    //default case should never be accessed -> remove it?
            }
        }
        

        private void StudentHandler()
        {
            int option;
            do
            {
                Menu.StudentMenu();
                option = GetOption();
                switch (option)
                {
                    case (int)StudentOptions.Add:
                        studentService.AddStudent();
                        break;
                    case (int)StudentOptions.Update:
                        studentService.UpdateStudent();
                        break;
                    case (int)StudentOptions.Remove:
                        studentService.RemoveStudent();
                        break;
                    case (int)StudentOptions.Print:
                        studentService.PrintStudents();
                        break;
                    case (int)StudentOptions.Exit:
                        break;
                    case (int)GeneralOptions.Incorrect:
                        //same as above
                        Console.WriteLine(GradingSystemException.GetOption());
                        break;
                }
            } while (option != (int)StudentOptions.Exit);
        }
        
        private void SubjectHandler()
        {
            int option;
            do
            {
                Menu.SubjectMenu();
                option = GetOption();
                switch (option)
                {
                    case 1:
                        subjectService.AddHandler();
                        break;
                    case 2:
                        subjectService.UpdateHandler();
                        break;
                    case 3:
                        subjectService.RemoveHandler();
                        break;
                    case 4:
                        subjectService.PrintHandler();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("You provided wrong option, try again");
                        break;
                }
            } while (option != 0);
        }
        /*
        private void GradeHandler()
        {
            int option;
            do
            {
                Menu.GradeMenu();
                Console.Write("Provide an option (blank == exit): ");
                option = GetInt();
                switch (option)
                {
                    case 1:
                        gradeService.AddHandler();
                        break;
                    case 2:
                        gradeService.UpdateHandler();
                        break;
                    case 3:
                        gradeService.RemoveHandler();
                        break;
                    case 4:
                        gradeService.PrintHandlerSubject();
                        break;
                    case 5:
                        gradeService.PrintHandlerStudent();
                        break;
                    case 6:
                        gradeService.PrintHandler();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("You provided wrong option, try again");
                        break;
                }
            } while (option != 0);
        }*/



        public static int GetOption()
        {
            Console.Write("Provide option: ");
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                return (int)GeneralOptions.Incorrect;
            }
        }

        public static int GetId()
        {
            Console.Write("Provide ID: ");
            return int.Parse(Console.ReadLine());
        }

        public static string GetFirstName()
        {
            Console.Write("Provide first name: ");
            return Console.ReadLine();
        }

        public static string GetLastName()
        {
            Console.Write("Provide last name: ");
            return Console.ReadLine();
        }
    }
}
