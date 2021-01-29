using Model;
using Model.Entities;
using System.Collections.Generic;

namespace ADO
{
    public class AdoOperation : IOperateable
    {
        private EntityReader _Reader;
        private EntityWriter _Writer;

        private const string c_StudentTable = "";
        private const string c_SubjectTable = "";
        private const string c_MarkTable = "";

        public AdoOperation()
        {
            _Reader = new EntityReader();
            _Writer = new EntityWriter();
        }

        public Student SelectOneStudent(int id)
        {
            return _Reader.SelectOne(c_StudentTable, "student_id={id}", _Reader.ReadStudent);
        }

        public Subject SelectOneSubject(int id)
        {
            return _Reader.SelectOne(c_SubjectTable, "subject_id={id}", _Reader.ReadSubject);
        }

        public Mark SelectOneMark(int id)
        {
            return _Reader.SelectOne(c_MarkTable, "mark_id={id}", _Reader.ReadMark);
        }

        public IEnumerable<Student> SelectStudents()
        {
            return _Reader.SelectAll(c_StudentTable, _Reader.ReadStudent);
        }

        public IEnumerable<Subject> SelectSubjects()
        {
            return _Reader.SelectAll(c_SubjectTable, _Reader.ReadSubject);
        }

        public IEnumerable<Mark> SelectMarks()
        {
            return _Reader.SelectAll(c_MarkTable, _Reader.ReadMark);
        }

        public void InsertStudent(Student student)
        {
            _Writer.Insert(
                $"INSERT INTO {c_StudentTable} (first_name, last_name) VALUES (@first_name, @last_name)",
                student,
                _Writer.WriteStudent);
        }

        public void InsertSubject(Subject subject)
        {
            _Writer.Insert(
                $"INSERT INTO {c_SubjectTable} (name) VALUES (@name)",
                subject,
                _Writer.WriteSubject);
        }

        public void InsertMark(Mark mark)
        {
            _Writer.Insert(
                $"INSERT INTO {c_MarkTable} (subject_id, student_id, value) VALUES (@subject_id, @student_id, @value)",
                mark,
                _Writer.WriteMark);
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
