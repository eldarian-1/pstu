using System.Collections.Generic;

namespace Model.Entities
{
    public class Mark : AEntity
    {
        public virtual long MarkId { get; set; }

        public virtual long StudentId { get; set; }

        public virtual long SubjectId { get; set; }

        public virtual byte Value { get; set; }

        public sealed override IEnumerable<AEntity> SelectAll(IOperateable operation)
        {
            return operation.SelectMarks();
        }

        public sealed override AEntity SelectOne(IOperateable operation, int id)
        {
            return operation.SelectOneMark(id);
        }

        public sealed override void Insert(IOperateable operatorr)
        {
            operatorr.InsertMark(this);
        }

        public sealed override void Update(IOperateable operatorr)
        {
            operatorr.UpdateMark(this);
        }

        public sealed override void Delete(IOperateable operatorr)
        {
            operatorr.DeleteMark(this);
        }
    }
}
