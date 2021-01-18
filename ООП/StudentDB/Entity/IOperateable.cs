using Model.Entities;
using System.Collections.Generic;

namespace Model
{
    public interface IOperateable
    {
        void FillData(IList<AEntity> list);

        void InsertStudent(Student student);

        void UpdateStudent(Student student);

        void DeleteStudent(Student student);

        void InsertSubject(Subject subject);

        void UpdateSubject(Subject subject);

        void DeleteSubject(Subject subject);

        void InsertMark(Mark mark);

        void UpdateMark(Mark mark);

        void DeleteMark(Mark mark);
    }
}
