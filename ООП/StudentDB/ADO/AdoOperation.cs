using Model;
using ADO.Requesters;
using Model.Entities;
using System.Collections.Generic;

namespace ADO
{
    public class AdoOperation : IOperateable
    {
        public Student SelectOneStudent(long id)
        {
            return new StudentRequester(id).SelectOne();
        }

        public Subject SelectOneSubject(long id)
        {
            return new SubjectRequester(id).SelectOne();
        }

        public Mark SelectOneMark(long id)
        {
            return new MarkRequester(id).SelectOne();
        }

        public IEnumerable<Student> SelectStudents()
        {
            return new StudentRequester().SelectAll();
        }

        public IEnumerable<Subject> SelectSubjects()
        {
            return new SubjectRequester().SelectAll();
        }

        public IEnumerable<Mark> SelectMarks()
        {
            return new MarkRequester().SelectAll();
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
