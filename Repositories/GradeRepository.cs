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
        public List<Grade> GetGradesForStudent(int studentID)
        {
            using var _db = new GradingSystemContext();
            return _db.Grades.Where(x => x.StudentId == studentID).ToList();
        }

        public List<Grade> GetGradesForSubject(int subjectID)
        {
            using var _db = new GradingSystemContext();
            return _db.Grades.Where(x => x.SubjectId == subjectID).ToList();
        }

        public List<Grade> GetGrades(int studentID, int subjectID)
        {
            using var _db = new GradingSystemContext();
            return _db.Grades.Where(x => (x.StudentId == studentID) && (x.SubjectId == subjectID)).ToList();
        }

        public List<Grade> GetAllGrades()
        {
            using var _db = new GradingSystemContext();
            return _db.Grades.ToList();
        }

        public void AddGrade(Grade grade)
        {
            using (var _db = new GradingSystemContext())
            {
                _db.Add(grade);
                _db.SaveChanges();
            }
        }

        public void UpdateGrade(Grade grade)
        {
            using (var _db = new GradingSystemContext())
            {
                _db.Update(grade);
                _db.SaveChanges();
            }
        }

        public void RemoveGrade(Grade grade)
        {
            using (var _db = new GradingSystemContext())
            {
                _db.Remove(grade);
                _db.SaveChanges();
            }
        }
    }
}
