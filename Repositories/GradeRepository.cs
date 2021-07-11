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
            return _db.Grades.Where(x => x.StudentId == studentID).OrderBy(x => x.Subject.Name).ToList();
        }

        public List<Grade> GetSubjectGrades(int subjectID)
        {
            using var _db = new GradingSystemContext();
            return _db.Grades.Where(x => x.SubjectId == subjectID).OrderBy(x => x.StudentId).ToList();
        }

        public List<Grade> GetGrades(int studentID, int subjectID)
        {
            using var _db = new GradingSystemContext();
            return _db.Grades.Where(x => (x.StudentId == studentID) && (x.SubjectId == subjectID)).ToList();
        }
        
        public Grade GetGrade(int gradeId)
        {
            using var _db = new GradingSystemContext();
            return _db.Grades.FirstOrDefault(g => g.Id == gradeId);
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
