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

        public bool HasSubjects()
        {
            try
            {
                var subjects = subjectRepository.GetSubjects();
                return subjects.Any();
            }
            catch
            {
                throw SubjectException.DbError();
            }
        }

        public void AddHandler()
        {
            string name = "";
            do
            {
                name = GradingSystemService.GetString("Provide subject name: ");
            } while (string.IsNullOrWhiteSpace(name));
            try
            {
                subjectRepository.AddSubject(new Subject(name));
            }
            catch
            {
                Console.WriteLine(SubjectException.AddError());
            }
        }

        public void UpdateHandler()
        {
            if (HasSubjects())
            {
                PrintSubjects();
                int subjectID = GradingSystemService.GetId();
                try
                {
                    var subject = subjectRepository.GetSubject(subjectID);
                    if(subject != null)
                    {
                        string name = "";
                        name = GradingSystemService.GetString("Provide subject name: ");
                        subject.Name = string.IsNullOrWhiteSpace(name) ? subject.Name : name;

                        try
                        {
                            subjectRepository.UpdateSubject(subject);
                        }
                        catch
                        {
                            Console.WriteLine(SubjectException.UpdateError());
                        }
                    }
                    else
                    {
                        Console.WriteLine(SubjectException.NotFound());
                    }
                }
                catch
                {
                    Console.WriteLine(SubjectException.DbError());
                }
            } else
            {
                Console.WriteLine(SubjectException.EmptyTable());
            }
        }

        public void RemoveHandler()
        {
            if (HasSubjects())
            {
                PrintSubjects();
                int subjectID = GradingSystemService.GetId();
                try
                {
                    var subject = subjectRepository.GetSubject(subjectID);
                    if (subject != null)
                    {
                        try
                        {
                            subjectRepository.RemoveSubject(subject);
                        }
                        catch
                        {
                            Console.WriteLine(SubjectException.RemoveError());
                        }
                    }
                    else
                    {
                        Console.WriteLine(SubjectException.NotFound());
                    }
                }
                catch
                {
                    Console.WriteLine(SubjectException.DbError());
                }
            } else
            {
                Console.WriteLine(SubjectException.EmptyTable());
            }
        }

        public void PrintSubjects()
        {
            if (HasSubjects())
            {
                subjectRepository.GetSubjects().ForEach(x => Console.WriteLine($"{x.Id}. {x.Name}"));
                Console.WriteLine(new string('-', Menu.repeat));
            }
            else
            {
                Console.WriteLine(SubjectException.EmptyTable());
            }
        }

        public List<Subject> GetSubjects()
        {
            return subjectRepository.GetSubjects();
        }

        public Subject GetSubject(int subjectID)
        {
            return subjectRepository.GetSubject(subjectID);
        }
    }
}
