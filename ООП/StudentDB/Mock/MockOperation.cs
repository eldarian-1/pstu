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
        private IList<Mark> _Marks;

        public MockOperation()
        {
            _Students = new ObservableCollection<Student>();
            _Subjects = new ObservableCollection<Subject>();
            _Marks = new ObservableCollection<Mark>();
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

        public Mark SelectOneMark(int id)
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

        public IEnumerable<Mark> SelectMarks()
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
            _Marks.Add(mark);
        }

        private long FindById(object obj)
        {
            long index = 0;
            if (obj is Student)
                foreach (var item in _Students)
                {
                    if (item.StudentId == (obj as Student).StudentId)
                        break;
                    ++index;
                }
            else if (obj is Subject)
                foreach (var item in _Subjects)
                {
                    if (item.SubjectId == (obj as Subject).SubjectId)
                        break;
                    ++index;
                }
            else if (obj is Mark)
                foreach (var item in _Marks)
                {
                    if (item.MarkId == (obj as Mark).MarkId)
                        break;
                    ++index;
                }
            return index;
        }

        public void UpdateStudent(Student student)
        {
            _Students[(int)FindById(student)] = student;
        }

        public void UpdateSubject(Subject subject)
        {
            _Subjects[(int)FindById(subject)] = subject;
        }

        public void UpdateMark(Mark mark)
        {
            _Marks[(int)FindById(mark)] = mark;
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
            _Marks.Remove(mark);
        }
    }
}
