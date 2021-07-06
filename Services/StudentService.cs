using GradingSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using GradingSystem.Models;
using GradingSystem.Exceptions;
using GradingSystem.ExtensionMethods;

namespace GradingSystem.Services
{
    class StudentService
    {
        private readonly StudentRepository studentRepository = new();

        public bool HasStudents()
        {
            return studentRepository.GetStudents().Any();
        }

        public void AddStudent()
        {
            string first = "", last = "";
            bool isEmpty;
            do
            {
                first = GradingSystemService.GetFirstName();
                last = GradingSystemService.GetLastName();
                isEmpty = string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(last);
            } while (isEmpty);
            try
            {
                studentRepository.AddStudent(new Models.Student(first, last));
            } catch
            {
                Console.WriteLine(StudentException.AddError());
            }
        }

        public void UpdateStudent()
        {
            if (HasStudents())
            {
                PrintStudents();
                int studentID = GradingSystemService.GetId();
                try
                {
                    var student = studentRepository.GetStudent(studentID);
                    if(student != null)
                    {
                        string first = "", last = "";
                        first = GradingSystemService.GetFirstName();
                        last = GradingSystemService.GetLastName();
                        student.First = string.IsNullOrWhiteSpace(first) ? student.First : first;
                        student.Last = string.IsNullOrWhiteSpace(last) ? student.Last : last;

                        try
                        {
                            studentRepository.UpdateStudent(student);
                        }
                        catch
                        {
                            Console.WriteLine(StudentException.UpdateError());
                        }
                    } else
                    {
                        Console.WriteLine(StudentException.NotFound());
                    }

                }catch
                {
                    Console.WriteLine(StudentException.DbError());
                }
            }
            else
            {
                Console.WriteLine(StudentException.EmptyTable());
            }
        }

        public void RemoveStudent()
        {
            if (HasStudents())
            {
                PrintStudents();
                int studentID = GradingSystemService.GetId();
                try
                {
                    var student = studentRepository.GetStudent(studentID);
                    if (student != null)
                    {
                        try
                        {
                            studentRepository.RemoveStudent(student);
                        }
                        catch
                        {
                            Console.WriteLine(StudentException.RemoveError());
                        }
                    }
                    else
                    {
                        Console.WriteLine(StudentException.NotFound());
                    }
                }
                catch
                {
                    Console.WriteLine(StudentException.DbError());
                }
            }
            else
            {
                Console.WriteLine(StudentException.EmptyTable());
            }
        }

        public void PrintStudents()
        {
            if (HasStudents())
            {
                studentRepository.GetStudents().ForEach(x => Console.WriteLine($"{x.Id}. {x.First} {x.Last}"));
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
