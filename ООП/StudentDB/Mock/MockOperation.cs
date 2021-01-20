using Model;
using Model.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Mock
{
    public class MockOperation : IOperateable
    {
        private IList<Student> _Students;
        private IList<Subject> _Subjects;
        private IList<MarkEntry> _Marks;

        public MockOperation()
        {
            _Students = new ObservableCollection<Student>();
            _Subjects = new ObservableCollection<Subject>();
            _Marks = new ObservableCollection<MarkEntry>();
        }

        public Student SelectOneStudent(int id)
        {
            return _Students[id];
        }

        public Subject SelectOneSubject(int id)
        {
            return _Subjects[id];
        }

        public MarkEntry SelectOneMark(int id)
        {
            return _Marks[id];
        }

        public IEnumerable<Student> SelectStudents()
        {
            return _Students;
        }

        public IEnumerable<Subject> SelectSubjects()
        {
            return _Subjects;
        }

        public IEnumerable<MarkEntry> SelectMarks()
        {
            return _Marks;
        }

        public void InsertStudent(Student student)
        {
            student.StudentId = _Students.Count;
            _Students.Add(student);
        }

        public void InsertSubject(Subject subject)
        {
            subject.SubjectId = _Subjects.Count;
            _Subjects.Add(subject);
        }

        public void InsertMark(Mark mark)
        {
            mark.MarkId = _Marks.Count;
            //_Marks.Add(mark);
        }

        public void UpdateStudent(Student student)
        {
            _Students[(int)student.StudentId] = student;
        }

        public void UpdateSubject(Subject subject)
        {
            _Subjects[(int)subject.SubjectId] = subject;
        }

        public void UpdateMark(Mark mark)
        {
            //_Marks[(int)mark.MarkId] = mark;
        }

        public void DeleteStudent(Student student)
        {
            _Students.Remove(student);
        }

        public void DeleteSubject(Subject subject)
        {
            _Subjects.Remove(subject);
        }

        public void DeleteMark(Mark mark)
        {
            //_Marks.Remove(mark);
        }
    }
}
