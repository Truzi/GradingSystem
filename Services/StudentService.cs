using GradingSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradingSystem.Models;
using GradingSystem.Exceptions;
using System.Text.RegularExpressions;

namespace GradingSystem.Services
{
    class StudentService
    {
        private readonly StudentRepository studentRepository = new();

        public bool HasStudents()
        {
            try
            {
                return studentRepository.GetStudents().Any();
            } catch
            {
                Console.WriteLine(StudentException.DbError());
                return false;
            }
        }

        public void AddHandler()
        {
            string first, last;
            do
            {
                Console.Write("Provide first name: ");
                first = Console.ReadLine();
                Console.Write("Provide last name: ");
                last = Console.ReadLine();
            } while (first == "" || last == "");
                try
                {
                studentRepository.AddStudent(new Models.Student { First = first, Last = last });
            } catch
            {
                Console.WriteLine(StudentException.DbError());
            }
        }

        public void UpdateHandler()
        {
            if (HasStudents())
            {
                PrintHandler();
                Console.Write("Provide ID of student you wish to update: ");
                var studentID = GradingSystemService.GetInt();
                var student = studentRepository.GetStudent(studentID);
                if (student == null)
                    Console.WriteLine(StudentException.NotFound());
                else
                {
                    Console.Write("Provide new first name or leave empty: ");
                    var first = Console.ReadLine();
                    Console.Write("Provide new last name or leave empty: ");
                    var last = Console.ReadLine();
                    student.First = first == "" ? student.First : first;
                    student.Last = last == "" ? student.Last : last;
                    studentRepository.UpdateStudent(student);
                }
            }
        }

        public void RemoveHandler()
        {
            if (HasStudents())
            {
                PrintHandler();
                Console.Write("Provide ID of student you wish to remove: ");
                var studentID = GradingSystemService.GetInt();
                var student = studentRepository.GetStudent(studentID);
                if (student == null)
                    Console.WriteLine(StudentException.NotFound());
                else
                    studentRepository.RemoveStudent(student);
            }
        }

        public void PrintHandler()
        {
            if (HasStudents())
            {
                studentRepository.GetStudents().ForEach(x => Console.WriteLine($"{x.ID}. {x.First} {x.Last}"));
                Console.WriteLine(new string('-', Menu.repeat));
            } else
            {
                Console.WriteLine(StudentException.EmptyTable());
            }
        }

        public List<Student> GetStudents()
        {
            return studentRepository.GetStudents();
        }

        public Student GetStudent(int studentID)
        {
            return studentRepository.GetStudent(studentID);
        }
    }
}
