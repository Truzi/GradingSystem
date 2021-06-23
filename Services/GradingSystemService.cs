using GradingSystem.Data;
using GradingSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GradingSystem.Services
{
    public class GradingSystemService
    {
        private readonly GradingSystemContext _db = new();

        private readonly StudentService studentService = new();
        private readonly SubjectService subjectService = new();
        private readonly GradeRepository gradeRepository = new ();

        public void Check()
        {
            _db.Database.EnsureCreated();
        }

        public void MainMenuHandler(int option)
        {
            Check();
            switch (option)
            {
                case 1:
                    StudentHandler();
                    break;
                case 2:
                    SubjectHandler();
                    break;
                case 3:
                    GradeHandler();
                    break;
                case 0:
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("You provided wrong option, try again");
                    break;
            }
        }

        //StudentHandler & dependencies
        private void StudentHandler()
        {
            int option;
            do
            {
                Menu.StudentMenu();
                Console.Write("Provide an option (blank == exit): ");
                option = GetOptionOrID();
                switch (option)
                {
                    case 1:
                        studentService.AddHandler();
                        break;
                    case 2:
                        studentService.UpdateHandler();
                        break;
                    case 3:
                        break;
                    case 4:
                        studentService.PrintStudents();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("You provided wrong option, try again");
                        break;
                }
            } while (option != 0);
        }

        private void SubjectHandler()
        {
            int option;
            do
            {
                Menu.SubjectMenu();
                Console.Write("Provide an option (blank == exit): ");
                option = GetOptionOrID();
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
                        subjectService.PrintSubjects();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("You provided wrong option, try again");
                        break;
                }
            } while (option != 0);
        }

        private void GradeHandler()
        {
            int option;
            do
            {
                Menu.GradeMenu();
                Console.Write("Provide an option (blank == exit): ");
                option = GetOptionOrID();
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
                        subjectService.PrintSubjects();
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("You provided wrong option, try again");
                        break;
                }
            } while (option != 0);
        }

        public static int GetOptionOrID()
        {
            int option;
            try
            {
                option = Console.ReadLine()[0] - '0';
            }
            catch
            {
                option = 0;
            }
            return option;
        }
    }
}
