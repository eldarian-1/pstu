using Model.Entities;
using System.Collections.Generic;

namespace Controller
{
    public interface IMediator
    {
        string Key { get; }

        IEnumerable<Subject> Subjects { get; }

        IEnumerable<Student> Students { get; }

        IEnumerable<MarkEntry> Marks { get; }

        void AddSubject(string name);

        void AddStudent(string firstName, string lastName);

        void AddMark(long studentId, long subjectId, byte value);

        void UpdateSubject(Subject subject);

        void UpdateStudent(Student student);

        void UpdateMark(Mark mark);

        void RemoveSubject(Subject subject);

        void RemoveStudent(Student student);

        void RemoveMark(Mark mark);

        IEnumerable<string> GetUseCases();

        void SetUseCase(string key);
    }
}
