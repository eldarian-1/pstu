using Model;
using Model.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Mock
{
    public class MockOperation : IOperateable
    {
        private int _StudentIndex;
        private int _SubjectIndex;
        private int _MarkIndex;

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
            foreach(var item in _Students)
                if(item.StudentId == id)
                    return item;
            return null;
        }

        public Subject SelectOneSubject(int id)
        {
            foreach (var item in _Subjects)
                if (item.SubjectId == id)
                    return item;
            return null;
        }

        public MarkEntry SelectOneMark(int id)
        {
            foreach (var item in _Marks)
                if (item.MarkId == id)
                    return item;
            return null;
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
            student.StudentId = ++_StudentIndex;
            _Students.Add(student);
        }

        public void InsertSubject(Subject subject)
        {
            subject.SubjectId = ++_SubjectIndex;
            _Subjects.Add(subject);
        }

        public void InsertMark(Mark mark)
        {
            mark.MarkId = ++_MarkIndex;
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
            _Marks.RemoveAt((int)mark.MarkId);
        }
    }
}
