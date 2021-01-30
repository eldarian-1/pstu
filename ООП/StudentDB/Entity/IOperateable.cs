using Model.Entities;
using System.Collections.Generic;

namespace Model
{
    public interface IOperateable
    {
        Student SelectOneStudent(long id);

        Subject SelectOneSubject(long id);

        Mark SelectOneMark(long id);

        IEnumerable<Student> SelectStudents();

        IEnumerable<Subject> SelectSubjects();

        IEnumerable<Mark> SelectMarks();

        void InsertStudent(Student student);

        void InsertSubject(Subject subject);

        void InsertMark(Mark mark);

        void UpdateStudent(Student student);

        void UpdateSubject(Subject subject);

        void UpdateMark(Mark mark);

        void DeleteStudent(Student student);

        void DeleteSubject(Subject subject);

        void DeleteMark(Mark mark);
    }
}
