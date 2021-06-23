using GradingSystem.Data;
using GradingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingSystem.Repositories
{
    class SubjectRepository
    {
        public Subject GetSubject(int subjectID)
        {
            using var _db = new GradingSystemContext();
            return _db.Subjects.FirstOrDefault(x => x.ID == subjectID);
        }

        public List<Subject> GetSubjects()
        {
            using var _db = new GradingSystemContext();
            return _db.Subjects.ToList();
        }

        public void AddSubject(Subject subject)
        {
            using var _db = new GradingSystemContext();
            _db.Add(subject);
            _db.SaveChanges();
        }

        public void UpdateSubject(Subject subject)
        {
            using var _db = new GradingSystemContext();
            _db.Update(subject);
            _db.SaveChanges();
        }

        public void RemoveSubject(Subject subject)
        {
            using var _db = new GradingSystemContext();
            _db.Remove(subject);
            _db.SaveChanges();
        }
    }
}
