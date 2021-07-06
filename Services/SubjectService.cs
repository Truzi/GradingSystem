using GradingSystem.Exceptions;
using GradingSystem.Models;
using GradingSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingSystem.Services
{
    class SubjectService
    {
        private readonly SubjectRepository subjectRepository = new();

        /*public bool HasSubjects()
        {
            try
            {
                // same as GradeService
                return subjectRepository.GetSubjects().Any();
            }
            catch
            {
                Console.WriteLine(SubjectException.DbError());
                return false;
            }
        }

        public void AddHandler()
        {
            string name;
            do
            {
                Console.Write("Provide name: ");
                name = Console.ReadLine();
                // use string.IsNullOrWhiteSpace(name) instead
            } while (name == "");
            try
            {
                // I tried to add a subject with the same name and I got "There was a problem with connection to DB", quite descriptive ngl
                subjectRepository.AddSubject(new Models.Subject { Name = name });
            }
            catch
            {
                Console.WriteLine(StudentException.DbError());
            }
        }

        public void UpdateHandler()
        {
            if (HasSubjects())
            {
                PrintHandler();
                Console.Write("Provide ID of subject you wish to update: ");
                var subjectID = GradingSystemService.GetInt();
                var subject = subjectRepository.GetSubject(subjectID);
                if (subject == null)
                    Console.WriteLine(StudentException.NotFound());
                else
                {
                    Console.Write("Provide new name or leave empty: ");
                    var name = Console.ReadLine();
                    // use string.IsNullOrWhiteSpace(name) instead
                    subject.Name = name == "" ? subject.Name : name;
                    subjectRepository.UpdateSubject(subject);
                }
            }
        }

        public void RemoveHandler()
        {
            if (HasSubjects())
            {
                PrintHandler();
                Console.Write("Provide ID of subject you wish to remove: ");
                var subjectID = GradingSystemService.GetInt();
                var subject = subjectRepository.GetSubject(subjectID);
                if (subject == null)
                    Console.WriteLine(StudentException.NotFound());
                else
                    subjectRepository.RemoveSubject(subject);
            }
        }

        public void PrintHandler()
        {
            if (HasSubjects())
            {
                subjectRepository.GetSubjects().ForEach(x => Console.WriteLine($"{x.Id}. {x.Name}"));
                Console.WriteLine(new string('-', Menu.repeat));
            }
            else
            {
                Console.WriteLine(StudentException.EmptyTable());
            }
        }

        public List<Subject> GetSubjects()
        {
            return subjectRepository.GetSubjects();
        }

        public Subject GetSubject(int subjectID)
        {
            return subjectRepository.GetSubject(subjectID);
        }*/
    }
}
