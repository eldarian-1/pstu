using Model;
using System;
using EF.Entities;
using System.Linq;
using Model.Entities;
using System.Data.Entity;
using System.Collections.Generic;

namespace EF
{
    internal class EfOperation : IOperateable
    {
        private T Execute<T>(Func<EfContext, T> func)
        {
            T result;
            using (EfContext context = new EfContext())
            using (DbContextTransaction transaction = context.Database.BeginTransaction())
            {
                context.Students.Load();
                context.Subjects.Load();
                context.Marks.Load();
                result = func(context);
                context.SaveChanges();
                transaction.Commit();
            }
            return result;
        }

        public Student SelectOneStudent(long id)
        {
            return Execute(context => context.Students.Find(id));
        }

        public Subject SelectOneSubject(long id)
        {
            return Execute(context => context.Subjects.Find(id));
        }

        public Mark SelectOneMark(long id)
        {
            return Execute(context => context.Marks.Find(id));
        }

        public IEnumerable<Student> SelectStudents()
        {
            return Execute(context => context.Students.ToList());
        }

        public IEnumerable<Subject> SelectSubjects()
        {
            return Execute(context => context.Subjects.ToList());
        }

        public IEnumerable<Mark> SelectMarks()
        {
            return Execute(context => context.Marks.ToList());
        }

        public void InsertStudent(Student student)
        {
            Execute(context => context.Students.Add(new EfStudent(student)));
        }

        public void InsertSubject(Subject subject)
        {
            Execute(context => context.Subjects.Add(new EfSubject(subject)));
        }

        public void InsertMark(Mark mark)
        {
            Execute(context => context.Marks.Add(new EfMark(mark)));
        }

        public void UpdateStudent(Student student)
        {
            Execute(context => context.Students.Update<Student, EfStudent>(new EfStudent(student)));
        }

        public void UpdateSubject(Subject subject)
        {
            Execute(context => context.Subjects.Update<Subject, EfSubject>(new EfSubject(subject)));
        }

        public void UpdateMark(Mark mark)
        {
            Execute(context => context.Marks.Update<Mark, EfMark>(new EfMark(mark)));
        }

        public void DeleteStudent(Student student)
        {
            Execute(context => context.Students.Remove(context.Students.Single(item => item.StudentId == student.StudentId)));
        }

        public void DeleteSubject(Subject subject)
        {
            Execute(context => context.Subjects.Remove(context.Subjects.Single(item => item.SubjectId == subject.SubjectId)));
        }

        public void DeleteMark(Mark mark)
        {
            Execute(context => context.Marks.Remove(context.Marks.Single(item => item.MarkId == mark.MarkId)));
        }
    }
}
