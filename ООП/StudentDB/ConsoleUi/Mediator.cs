using Controller;
using System.Linq;
using Model.Entities;
using System.Collections.Generic;

namespace ConsoleUi
{
    public class Mediator
    {
        private Facade _Facade;

        private IEnumerable<Subject> _Subjects;
        private IEnumerable<Student> _Students;
        private IEnumerable<Mark> _Marks;

        private void Initialize()
        {
            _Facade = new Facade();
        }

        private void UpdateCollections()
        {
            _Subjects = _Facade.Subjects.SelectAll();
            _Students = _Facade.Students.SelectAll();
            _Marks = new MarkJournal(_Facade.Marks.SelectAll(), this);
        }

        public Mediator()
        {
            Initialize();
            UpdateCollections();
        }

        public IEnumerable<Subject> Subjects => _Subjects;

        public IEnumerable<Student> Students => _Students;

        public IEnumerable<Mark> Marks => _Marks;

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

        public void RemoveSubject(Subject subject)
        {
            _Facade.Subjects.Delete(subject);
            Marks.Where(mark => mark.SubjectId == subject.SubjectId)
                .ToList().ForEach(mark => RemoveMark(mark));
            UpdateCollections();
        }

        public void RemoveStudent(Student student)
        {
            _Facade.Students.Delete(student);
            Marks.Where(mark => mark.StudentId == student.StudentId)
                .ToList().ForEach(mark => RemoveMark(mark));
            UpdateCollections();
        }

        public void RemoveMark(Mark mark)
        {
            _Facade.Marks.Delete(mark);
            UpdateCollections();
        }

        public void SetUseCase(string key)
        {
            _Facade.SetOperation(key);
            UpdateCollections();
        }
    }
}
