using Model.Entities;
using System.Collections.Generic;

namespace Model
{
    public abstract class AProxyOperation : IOperateable
    {
        private IOperateable _Current;

        public AProxyOperation(IOperateable operation)
        {
            _Current = operation;
        }

        public Student SelectOneStudent(int id) => _Current.SelectOneStudent(id);

        public Subject SelectOneSubject(int id) => _Current.SelectOneSubject(id);

        public Mark SelectOneMark(int id) => _Current.SelectOneMark(id);

        public IEnumerable<Student> SelectStudents() => _Current.SelectStudents();

        public IEnumerable<Subject> SelectSubjects() => _Current.SelectSubjects();

        public IEnumerable<Mark> SelectMarks() => _Current.SelectMarks();

        public void InsertStudent(Student student) => _Current.InsertStudent(student);

        public void InsertSubject(Subject subject) => _Current.InsertSubject(subject);

        public void InsertMark(Mark mark) => _Current.InsertMark(mark);

        public void UpdateStudent(Student student) => _Current.UpdateStudent(student);

        public void UpdateSubject(Subject subject) => _Current.UpdateSubject(subject);

        public void UpdateMark(Mark mark) => _Current.UpdateMark(mark);

        public void DeleteStudent(Student student) => _Current.DeleteStudent(student);

        public void DeleteSubject(Subject subject) => _Current.DeleteSubject(subject);

        public void DeleteMark(Mark mark) => _Current.DeleteMark(mark);
    }
}
