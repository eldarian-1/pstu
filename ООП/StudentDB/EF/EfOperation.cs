using Entity;
using Model;
using Model.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF
{
    public class EfOperation : IOperateable
    {
        private const string ConnectionString
            = "server=" + Const.Host
            + ";user=" + Const.User
            + ";password=" + Const.Password
            + ";database=" + Const.Database + ";";

        public EfOperation()
        {
            
        }

        public Student SelectOneStudent(int id)
        {
            return null;
        }

        public Subject SelectOneSubject(int id)
        {
            return null;
        }

        public MarkEntry SelectOneMark(int id)
        {
            return null;
        }

        public IEnumerable<Student> SelectStudents()
        {
            return null;
        }

        public IEnumerable<Subject> SelectSubjects()
        {
            return null;
        }

        public IEnumerable<MarkEntry> SelectMarks()
        {
            return null;
        }

        public void InsertStudent(Student student)
        {

        }

        public void InsertSubject(Subject subject)
        {

        }

        public void InsertMark(Mark mark)
        {

        }

        public void UpdateStudent(Student student)
        {

        }

        public void UpdateSubject(Subject subject)
        {

        }

        public void UpdateMark(Mark mark)
        {

        }

        public void DeleteStudent(Student student)
        {

        }

        public void DeleteSubject(Subject subject)
        {

        }

        public void DeleteMark(Mark mark)
        {

        }
    }
}
