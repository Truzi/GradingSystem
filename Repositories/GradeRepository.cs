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
        public List<Grade> GetStudentGrades(int studentID)
        {
            using var _db = new GradingSystemContext();
            return _db.Grades.Where(x => x.StudentID == studentID).ToList();
        }

        public List<Grade> GetSubjectGrades(int subjectID)
        {
            using var _db = new GradingSystemContext();
            return _db.Grades.Where(x => x.SubjectID == subjectID).ToList();
        }

        public Grade GetGrade(int gradeID)
        {
            using var _db = new GradingSystemContext();
            return _db.Grades.FirstOrDefault(x => x.ID == gradeID);
        }

        public List<Grade> GetGrades(int studentID, int subjectID)
        {
            using var _db = new GradingSystemContext();
            return _db.Grades.Where(x => (x.StudentID == studentID) && (x.SubjectID == subjectID)).ToList();
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

        public void RemoveGrade(Grade grade)
        {
            using var _db = new GradingSystemContext();
            _db.Remove(grade);
            _db.SaveChanges();
        }
    }
}
