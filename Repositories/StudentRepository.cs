using GradingSystem.Data;
using GradingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingSystem.Repositories
{
    class StudentRepository
    {
        public Student GetStudent(int studentID)
        {
            using var _db = new GradingSystemContext();
            return _db.Students.FirstOrDefault(x => x.ID == studentID);
        }

        public List<Student> GetStudents()
        {
            using var _db = new GradingSystemContext();
            return _db.Students.ToList();
        }

        public void AddStudent(Student student)
        {
            using var _db = new GradingSystemContext();
            _db.Add(student);
            _db.SaveChanges();
        }
        
        public void UpdateStudent(Student student)
        {
            using var _db = new GradingSystemContext();
            _db.Update(student);
            _db.SaveChanges();
        }

        public void RemoveStudent(Student student)
        {
            using var _db = new GradingSystemContext();
            _db.Remove(student);
        }
    }
}
