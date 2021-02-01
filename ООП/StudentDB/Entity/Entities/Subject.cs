using System.Collections.Generic;

namespace Model.Entities
{
    public class Subject : AEntity<Subject>
    {
        public virtual long SubjectId { get; set; }

        public virtual string SubjectName { get; set; }

        internal override IEnumerable<Subject> SelectAll(IOperateable operation)
        {
            return operation.SelectSubjects();
        }

        internal override Subject SelectOne(IOperateable operation, long id)
        {
            return operation.SelectOneSubject(id);
        }

        internal override void Insert(IOperateable operatorr)
        {
            operatorr.InsertSubject(this);
        }

        internal override void Update(IOperateable operatorr)
        {
            operatorr.UpdateSubject(this);
        }

        internal override void Delete(IOperateable operatorr)
        {
            operatorr.DeleteSubject(this);
        }

        public override bool Equals(object obj)
        {
            return obj is Subject && (obj as Subject).SubjectId == SubjectId;
        }
    }
}
