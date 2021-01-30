using EF.Entities;
using Model;
using Model.Entities;
using System.Collections.Generic;

namespace EF
{
    internal class EfOperation : IOperateable
    {
        public Student SelectOneStudent(long id)
        {
            Student result;
            using (EfContext context = new EfContext())
                result = context.Students.Find(id);
            return result;
        }

        public Subject SelectOneSubject(long id)
        {
            Subject result;
            using (EfContext context = new EfContext())
                result = context.Subjects.Find(id);
            return result;
        }

        public Mark SelectOneMark(long id)
        {
            Mark result;
            using (EfContext context = new EfContext())
                result = context.Marks.Find(id);
            return result;
        }

        public IEnumerable<Student> SelectStudents()
        {
            IEnumerable<Student> result;
            using (EfContext context = new EfContext())
                result = context.Students;
            return result;
        }

        public IEnumerable<Subject> SelectSubjects()
        {
            IEnumerable<Subject> result;
            using (EfContext context = new EfContext())
                result = context.Subjects;
            return result;
        }

        public IEnumerable<Mark> SelectMarks()
        {
            IEnumerable<Mark> result;
            using (EfContext context = new EfContext())
                result = context.Marks;
            return result;
        }

        public void InsertStudent(Student student)
        {
            using (EfContext context = new EfContext())
                context.Students.Add(new EfStudent(student));
        }

        public void InsertSubject(Subject subject)
        {
            using (EfContext context = new EfContext())
                context.Subjects.Add(new EfSubject(subject));
        }

        public void InsertMark(Mark mark)
        {
            using (EfContext context = new EfContext())
                context.Marks.Add(new EfMark(mark));
        }

        public void UpdateStudent(Student student)
        {
            using (EfContext context = new EfContext())
                context.Students.Update(new EfStudent(student));
        }

        public void UpdateSubject(Subject subject)
        {
            using (EfContext context = new EfContext())
                context.Subjects.Update(new EfSubject(subject));
        }

        public void UpdateMark(Mark mark)
        {
            using (EfContext context = new EfContext())
                context.Marks.Update(new EfMark(mark));
        }

        public void DeleteStudent(Student student)
        {
            using (EfContext context = new EfContext())
                context.Students.Remove(new EfStudent(student));
        }

        public void DeleteSubject(Subject subject)
        {
            using (EfContext context = new EfContext())
                context.Subjects.Remove(new EfSubject(subject));
        }

        public void DeleteMark(Mark mark)
        {
            using (EfContext context = new EfContext())
                context.Marks.Remove(new EfMark(mark));
        }
    }
}
