using System.Collections.Generic;

namespace Model.Entities
{
    public class Mark : AEntity<Mark>
    {
        public virtual long MarkId { get; set; }

        public virtual long StudentId { get; set; }

        public virtual long SubjectId { get; set; }

        public virtual byte MarkValue { get; set; }

        internal override IEnumerable<Mark> SelectAll(IOperateable operation)
        {
            return operation.SelectMarks();
        }

        internal override Mark SelectOne(IOperateable operation, long id)
        {
            return operation.SelectOneMark(id);
        }

        internal override void Insert(IOperateable operatorr)
        {
            operatorr.InsertMark(this);
        }

        internal override void Update(IOperateable operatorr)
        {
            operatorr.UpdateMark(this);
        }

        internal override void Delete(IOperateable operatorr)
        {
            operatorr.DeleteMark(this);
        }

        public override bool Equals(object obj)
        {
            return obj is Mark && (obj as Mark).MarkId == MarkId;
        }

        public override string ToString()
        {
            return MarkId + ". " + StudentId + " | " + SubjectId + " : " + MarkValue;
        }
    }
}
