using Model.Entities;
using System.Collections.Generic;

namespace Controller
{
    public class Mediator : IMediator
    {
        private Facade _Facade;

        private IEnumerable<Subject> _Subjects;
        private IEnumerable<Student> _Students;
        private IEnumerable<MarkEntry> _Marks;

        protected virtual void UpdateCollections()
        {
            _Subjects = _Facade.Subjects.SelectAll();
            _Students = _Facade.Students.SelectAll();
            _Marks = new MarkJournal(_Facade.Marks.SelectAll(), this);
        }

        public Mediator()
        {
            _Facade = new Facade();
        }

        public string Key
        {
            get => _Facade.Key;
        }

        public IEnumerable<Subject> Subjects
        {
            get => _Subjects;
        }

        public IEnumerable<Student> Students
        {
            get => _Students;
        }

        public IEnumerable<MarkEntry> Marks
        {
            get => _Marks;
        }

        public void AddSubject(string name)
        {
            _Facade.Subjects.Insert(new Subject { SubjectName = name });
            UpdateCollections();
        }

        public void AddStudent(string firstName, string lastName)
        {
            _Facade.Students.Insert(new Student
            {
                FirstName = firstName,
                LastName = lastName
            });
            UpdateCollections();
        }

        public void AddMark(long studentId, long subjectId, byte value)
        {
            _Facade.Marks.Insert(new Mark
            {
                StudentId = studentId,
                SubjectId = subjectId,
                MarkValue = value
            });
            UpdateCollections();
        }

        public void UpdateSubject(Subject subject)
        {
            _Facade.Subjects.Update(subject);
            UpdateCollections();
        }

        public void UpdateStudent(Student student)
        {
            _Facade.Students.Update(student);
            UpdateCollections();
        }

        public void UpdateMark(Mark mark)
        {
            _Facade.Marks.Update(mark);
            UpdateCollections();
        }

        public virtual void RemoveSubject(Subject subject)
        {
            _Facade.Subjects.Delete(subject);
            UpdateCollections();
        }

        public virtual void RemoveStudent(Student student)
        {
            _Facade.Students.Delete(student);
            UpdateCollections();
        }

        public virtual void RemoveMark(Mark mark)
        {
            _Facade.Marks.Delete(mark);
            UpdateCollections();
        }

        public IEnumerable<string> GetUseCases()
        {
            return _Facade.GetOperations();
        }

        public void SetUseCase(string key)
        {
            _Facade.SetOperation(key);
            UpdateCollections();
        }
    }
}
