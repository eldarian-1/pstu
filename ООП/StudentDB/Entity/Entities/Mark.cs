using System.Collections.Generic;

namespace Model.Entities
{
    public class Mark : IEntity<Mark>
    {
        public virtual long MarkId { get; set; }

        public virtual long StudentId { get; set; }

        public virtual long SubjectId { get; set; }

        public virtual byte Value { get; set; }

        public IEnumerable<Mark> SelectAll(IOperateable operation)
        {
            return operation.SelectMarks();
        }

        public Mark SelectOne(IOperateable operation, int id)
        {
            return operation.SelectOneMark(id);
        }

        public void Insert(IOperateable operatorr)
        {
            operatorr.InsertMark(this);
        }

        public void Update(IOperateable operatorr)
        {
            operatorr.UpdateMark(this);
        }

        public void Delete(IOperateable operatorr)
        {
            operatorr.DeleteMark(this);
        }
    }
}
