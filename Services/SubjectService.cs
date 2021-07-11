using GradingSystem.Exceptions;
using GradingSystem.Models;
using GradingSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GradingSystem.Services
{
    class SubjectService
    {
        private readonly SubjectRepository subjectRepository = new();

        public bool HasSubjects()
        {
            var subjects = subjectRepository.GetSubjects();
            if (!subjects.Any())
                throw SubjectException.EmptyTable();

            return true;
        }

        public void AddSubject()
        {
            string name;
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
                throw SubjectException.AddError();
            }
        }

        public void UpdateSubject()
        {
            try
            {
                PrintSubjects();
                try
                {
                    var subject = GetSubject(GradingSystemService.GetInt());
                    string name = GradingSystemService.GetString("Provide subject name: ");
                    subject.Name = string.IsNullOrWhiteSpace(name) ? subject.Name : name;

                    try
                    {
                        subjectRepository.UpdateSubject(subject);
                    } catch
                    {
                        throw SubjectException.UpdateError();
                    }
                } catch (SubjectException exNotFound)
                {
                    Console.WriteLine(exNotFound.Message);
                }
            } catch (SubjectException exEmptyTable)
            {
                Console.WriteLine(exEmptyTable.Message);
            }
        }

        public void RemoveSubject()
        {
            try
            {
                PrintSubjects();
                try
                {
                    var subject = GetSubject(GradingSystemService.GetInt());
                    try
                    {
                        subjectRepository.RemoveSubject(subject);
                    }
                    catch
                    {
                        throw SubjectException.RemoveError();
                    }
                }
                catch (SubjectException exNotFound)
                {
                    Console.WriteLine(exNotFound.Message);
                }

            }
            catch (SubjectException exEmptyTable)
            {
                Console.WriteLine(exEmptyTable.Message);
            }
        }

        public void PrintSubjects()
        {
            HasSubjects();
            subjectRepository.GetSubjects().ForEach(x => Console.WriteLine($"{x.Id}. {x.Name}"));
            Console.WriteLine(new string('-', Menu.repeat));
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
