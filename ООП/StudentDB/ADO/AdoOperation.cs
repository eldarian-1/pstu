using Entity;
using Model;
using Model.Entities;
using System.Collections.Generic;

namespace ADO
{
    public class AdoOperation : IOperateable
    {
        private const string ConnectionString
            = "Database=" + Const.Database
            + ";Datasource=" + Const.Host
            + ";User=" + Const.User
            + ";Password=" + Const.Password;

        public AdoOperation() { }

        public Student SelectOneStudent(int id)
        {
            return null;
        }

        public Subject SelectOneSubject(int id)
        {
            return null;
        }

        public Mark SelectOneMark(int id)
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

        public IEnumerable<Mark> SelectMarks()
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
