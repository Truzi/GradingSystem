using GradingSystem.Data;
using GradingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingSystem.Repositories
{
    class GradeRepository
    {
        public List<Grade> GetStudentGrades(Student student)
        {
            using var _db = new GradingSystemContext();
            return _db.Grades.Where(x => x.StudentID == student.ID).ToList();
        }

        public List<Grade> GetSubjectGrades(Subject subject)
        {
            using var _db = new GradingSystemContext();
            return _db.Grades.Where(x => x.SubjectID == subject.ID).ToList();
        }

        public List<Grade> GetGrades(Student student, Subject subject)
        {
            using var _db = new GradingSystemContext();
            return _db.Grades.Where(x => (x.StudentID == student.ID) && (x.SubjectID == subject.ID)).ToList();
        }

        public List<Grade> GetAllGrades()
        {
            using var _db = new GradingSystemContext();
            return _db.Grades.ToList();
        }

        public void AddGrade(Grade grade)
        {
            using var _db = new GradingSystemContext();
            _db.Add(grade);
            _db.SaveChanges();
        }

        public void UpdateGrade(Grade grade)
        {
            using var _db = new GradingSystemContext();
            _db.Update(grade);
            _db.SaveChanges();
        }

        public void DeleteGrade(Grade grade)
        {
            using var _db = new GradingSystemContext();
            _db.Remove(grade);
            _db.SaveChanges();
        }
    }
}
