using System.Collections.Generic;

namespace Model.Entities
{
    public class MarkEntry : Mark, IEntity<MarkEntry>
    {
        public virtual string Student { get; }

        public virtual string Subject { get; }

        IEnumerable<MarkEntry> IEntity<MarkEntry>.SelectAll(IOperateable operation)
        {
            return operation.SelectMarks();
        }

        MarkEntry IEntity<MarkEntry>.SelectOne(IOperateable operation, int id)
        {
            return operation.SelectOneMark(id);
        }
    }
}
