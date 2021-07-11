using GradingSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using GradingSystem.Models;
using GradingSystem.Exceptions;

namespace GradingSystem.Services
{
    class StudentService
    {
        private readonly StudentRepository studentRepository = new();

        public bool HasStudents()
        {
            var students = studentRepository.GetStudents();
            if(!students.Any())
                throw StudentException.EmptyTable();

            return true;
        }

        public void AddStudent()
        {
            string first, last;
            bool shouldExit;
            do
            {
                first = GradingSystemService.GetString("Provide first name: ");
                last = GradingSystemService.GetString("Provide last name: ");
                shouldExit = string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(last);
            } while (shouldExit);
            try
            {
                studentRepository.AddStudent(new Student(first, last));
            } catch
            {
                throw StudentException.AddError();
            }
        }

        public void UpdateStudent()
        {
            try
            {
                PrintStudents();
                try
                {
                    var student = GetStudent(GradingSystemService.GetInt());
                    string first = GradingSystemService.GetString("Provide first name: ");
                    string last = GradingSystemService.GetString("Provide last name: ");
                    student.First = string.IsNullOrWhiteSpace(first) ? student.First : first;
                    student.Last = string.IsNullOrWhiteSpace(last) ? student.Last : last;

                    try
                    {
                        studentRepository.UpdateStudent(student);
                    }
                    catch
                    {
                        throw StudentException.UpdateError();
                    }
                } catch (StudentException exNotFound)
                {
                    Console.WriteLine(exNotFound.Message);
                }
            }
            catch(StudentException exEmptyTable)
            {
                Console.WriteLine(exEmptyTable.Message);
            }
        }

        public void RemoveStudent()
        {
            try
            {
                PrintStudents();
                try
                {
                    var student = GetStudent(GradingSystemService.GetInt());
                    try
                    {
                        studentRepository.RemoveStudent(student);
                    }
                    catch
                    {
                        throw StudentException.RemoveError();
                    }
                } catch(StudentException exNotFound)
                {
                    Console.WriteLine(exNotFound.Message);
                }
                
            } catch(StudentException exEmptyTable)
            {
                Console.WriteLine(exEmptyTable.Message);
            }
        }

        public void PrintStudents()
        {
            HasStudents();
            studentRepository.GetStudents().ForEach(x => Console.WriteLine($"{x.Id}. {x.First} {x.Last}"));
            Console.WriteLine(new string('-', Menu.repeat));
        }

        public List<Student> GetStudents()
        {
            return studentRepository.GetStudents();
        }

        public Student GetStudent(int studentID)
        {
            var student = studentRepository.GetStudent(studentID);
            if (student == null)
                throw StudentException.NotFound();

            return student;
        }
    }
}
