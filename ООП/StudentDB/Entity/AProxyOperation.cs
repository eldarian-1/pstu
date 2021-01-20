using Model.Entities;
using System.Collections.Generic;

namespace Model
{
    public abstract class AProxyOperation : IOperateable
    {
        public IOperateable Current { get; set; }

        public Student SelectOneStudent(int id) => Current.SelectOneStudent(id);

        public Subject SelectOneSubject(int id) => Current.SelectOneSubject(id);

        public MarkEntry SelectOneMark(int id) => Current.SelectOneMark(id);

        public IEnumerable<Student> SelectStudents() => Current.SelectStudents();

        public IEnumerable<Subject> SelectSubjects() => Current.SelectSubjects();

        public IEnumerable<MarkEntry> SelectMarks() => Current.SelectMarks();

        public void InsertStudent(Student student) => Current.InsertStudent(student);

        public void InsertSubject(Subject subject) => Current.InsertSubject(subject);

        public void InsertMark(Mark mark) => Current.InsertMark(mark);

        public void UpdateStudent(Student student) => Current.UpdateStudent(student);

        public void UpdateSubject(Subject subject) => Current.UpdateSubject(subject);

        public void UpdateMark(Mark mark) => Current.UpdateMark(mark);

        public void DeleteStudent(Student student) => Current.DeleteStudent(student);

        public void DeleteSubject(Subject subject) => Current.DeleteSubject(subject);

        public void DeleteMark(Mark mark) => Current.DeleteMark(mark);
    }
}
