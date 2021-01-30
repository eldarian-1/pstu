using ADO.Writers;
using Model;
using Model.Entities;
using System.Collections.Generic;

namespace ADO
{
    public class AdoOperation : IOperateable
    {
        public Student SelectOneStudent(int id)
        {
            return new StudentRequester(null).SelectOne(id);
        }

        public Subject SelectOneSubject(int id)
        {
            return new SubjectRequester(null).SelectOne(id);
        }

        public Mark SelectOneMark(int id)
        {
            return new MarkRequester(null).SelectOne(id);
        }

        public IEnumerable<Student> SelectStudents()
        {
            return new StudentRequester(null).SelectAll();
        }

        public IEnumerable<Subject> SelectSubjects()
        {
            return new SubjectRequester(null).SelectAll();
        }

        public IEnumerable<Mark> SelectMarks()
        {
            return new MarkRequester(null).SelectAll();
        }

        public void InsertStudent(Student student)
        {
            new StudentRequester(student).Insert();
        }

        public void InsertSubject(Subject subject)
        {
            new SubjectRequester(subject).Insert();
        }

        public void InsertMark(Mark mark)
        {
            new MarkRequester(mark).Insert();
        }

        public void UpdateStudent(Student student)
        {
            new StudentRequester(student).Update();
        }

        public void UpdateSubject(Subject subject)
        {
            new SubjectRequester(subject).Update();
        }

        public void UpdateMark(Mark mark)
        {
            new MarkRequester(mark).Update();
        }

        public void DeleteStudent(Student student)
        {
            new StudentRequester(student).Delete();
        }

        public void DeleteSubject(Subject subject)
        {
            new SubjectRequester(subject).Delete();
        }

        public void DeleteMark(Mark mark)
        {
            new MarkRequester(mark).Delete();
        }
    }
}
